using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OOP_Task.Entities;

namespace OOP_Task.Collections
{
    public class FileCollection<TEntity> where TEntity : Entity
    {
        private string FileName = typeof(TEntity).Name.ToLower() + ".csv";

        private List<TEntity> Items = new List<TEntity>();

        private List<PropertyInfo> Properties;

        public FileCollection()
        {
            
            Properties = GetEntityProperties();
            
            if (File.Exists(FileName))
            {
                LoadData();
            }
            else
            {
                File.Create(FileName);
            }
            
        }

        public List<TEntity> GetAll()
        {
            return Items;
        }

        public TEntity GetOne(int id)
        {
            TEntity item = Items.Find(x => x.Id == id);

            if (item == null)
            {
                throw new ArgumentException($"There is no {typeof(TEntity).Name} with ID of {id}");
            }

            return item;
        }

        public void Add(TEntity newItem)
        {
            if (newItem.Id == 0)
            {
                newItem.Id = GenerateNewID();
            }
            else if (IsIdAvailable(newItem.Id) == false)
            {
                throw new ArgumentException($"{typeof(TEntity).Name} with ID of {newItem.Id} is already taken");
            }

            Items.Add(newItem);

            WriteData();
        }

        private bool IsIdAvailable(int id)
        {
            TEntity item = Items.Find(x => x.Id == id);

            if (item == null)
            {
                return true;
            }

            return false;
        }

        int GenerateNewID()
        {
            int id = 0;

            id = Items.Max(x => x.Id) + 1;

            return id;
        }

        public void Remove(int id)
        {
            TEntity item = GetOne(id);

            Items.RemoveAll(x => x == item);

            WriteData();
        }

        public void Update(TEntity updatedItem)
        {
            TEntity item = GetOne(updatedItem.Id);

            Items[Items.FindIndex(x => x.Id.Equals(updatedItem.Id))] = updatedItem;

            WriteData();
        }

        void LoadData()
        {
            using (StreamReader collectionFile = new StreamReader(FileName))
            {
                string line = null;

                while ((line = collectionFile.ReadLine()) != null)
                {
                    Items.Add(ParseFromFile(line));
                }
            }
        }

        void WriteData()
        {
            using (StreamWriter writer = new StreamWriter(FileName, false))
            {
                foreach (TEntity item in Items)
                {
                    writer.WriteLine(item.FormatToFile(Properties));
                }
            }
        }


        TEntity ParseFromFile(string line)
        {
            string[] entityProps = line.Split(',');

            if (entityProps.Length != Properties.Count)
            {
                throw new Exception();
            }

            Dictionary<string, dynamic> parsedProps = new Dictionary<string, dynamic>();

            for (int i = 0; i < Properties.Count; i++)
            {
                parsedProps[Properties[i].Name] = ParseProp(Properties[i], entityProps[i]);
            };

            return CreateInstance(parsedProps);
        }

        public List<PropertyInfo> GetEntityProperties(IEntity instance = null)
        {
            List<PropertyInfo> props = typeof(IEntity).GetProperties().ToList();

            if (instance == null)
            {
                props = props.Concat(typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList()).ToList();
            }
            else
            {
                props = props.Concat(instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList()).ToList();
            }

            return props;
        }

        TEntity CreateInstance(Dictionary<string, dynamic> props)
        {
            TEntity instance = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] { props, Properties });

            return instance;
        }


        dynamic ParseProp(PropertyInfo propInfo, string propValue)
        {
            dynamic output = null;

            switch (propInfo.PropertyType.Name)
            {
                case "String":
                    output = propValue;
                    break;
                case "Char":
                    output = char.Parse(propValue);
                    break;
                case "Int32":
                    output = int.Parse(propValue);
                    break;
                case "Double":
                    output = double.Parse(propValue);
                    break;
                case "Decimal":
                    output = decimal.Parse(propValue);
                    break;
                case "List`1":
                    output = ParseListProp(propInfo, Array.ConvertAll(propValue.Split('.'), s => int.Parse(s)));
                    break;
                default:
                    output = ParseClassProp(propInfo, int.Parse(propValue));
                    break;
            }

            return output;
        }

        IEntity ParseClassProp(PropertyInfo propInfo, int id)
        {
            string[] entityProps = { };

            using (StreamReader instanceFile = new StreamReader(propInfo.PropertyType.Name.ToLower() + ".csv"))
            {
                string line = null;

                while ((line = instanceFile.ReadLine()) != null)
                {
                    if (int.Parse(line.Split(',')[0]) == id)
                    {
                        entityProps = line.Split(',');
                    }
                }
            }

            if (entityProps.Length == 0)
            {
                throw new Exception();
            }

            string fullClassName = propInfo.PropertyType.FullName;

            Type classType = Type.GetType(fullClassName);

            var dummyInstance = (IEntity)Activator.CreateInstance(classType);

            List<PropertyInfo> classProperties = GetEntityProperties(dummyInstance);

            Dictionary<string, dynamic> parsedProps = new Dictionary<string, dynamic>();
            for (int i = 0; i < entityProps.Length; i++)
            {
                parsedProps[classProperties[i].Name] = ParseProp(classProperties[i], entityProps[i]);
            }

            var instance = (IEntity)Activator.CreateInstance(classType, parsedProps, classProperties);

            return instance;

        }

        object ParseListProp(PropertyInfo propInfo, int[] ids)
        {
            string listGenericClassName = propInfo.PropertyType.GetGenericArguments()[0].Name;

            List<string> entityProps = new List<string>();

            using (StreamReader instanceFile = new StreamReader(listGenericClassName.ToLower() + ".csv"))
            {
                string line = null;

                while ((line = instanceFile.ReadLine()) != null)
                {
                    if (ids.Contains(int.Parse(line.Split(',')[0])))
                    {
                        entityProps.Add(line);
                    }
                }
            }

            if (entityProps.Count == 0)
            {
                throw new Exception();
            }

            string fullClassName = propInfo.PropertyType.GetGenericArguments()[0].FullName;

            Type classType = Type.GetType(fullClassName);

            IEntity dummyInstance = (IEntity)Activator.CreateInstance(classType);

            List<PropertyInfo> classProperties = GetEntityProperties(dummyInstance);

            List<Dictionary<string, dynamic>> parsedProps = new List<Dictionary<string, dynamic>>();


            
            for (int i = 0; i < entityProps.Count; i++)
            {
                string[] lineProps = entityProps[i].Split(',');
                Dictionary<string, dynamic> instanceParsedProps = new Dictionary<string, dynamic>();

                for (int j = 0; j < lineProps.Length; j++)
                {
                    instanceParsedProps[classProperties[j].Name] = ParseProp(classProperties[j], lineProps[j]);
                }

                parsedProps.Add(instanceParsedProps);
            }

            var instances = new object[entityProps.Count];

            for (int i = 0; i < instances.Length; i++)
            {
                var instance = (IEntity)Activator.CreateInstance(classType, parsedProps[i], classProperties);
                instances[i] = instance;
            }
   

            MethodInfo method = GetType().GetMethod("BuildListHelper");

            method = method.MakeGenericMethod(new Type[] { dummyInstance.GetType() });

            object abc = method.Invoke(this, new object[] { instances });

            return abc;
        }

        public IList<T> BuildListHelper<T>(object[] args)
        {
            List<T> list = new List<T>();

            foreach (object arg in args)
            {
                list.Add((T)arg);
            }

            return list;
        }
    }
}