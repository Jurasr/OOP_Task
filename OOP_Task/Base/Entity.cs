using System.Collections.Generic;
using System.Reflection;
using OOP_Task.Interfaces;

namespace OOP_Task.Entities
{
    class Entity : IEntity
    {
        public int Id { get; set; }

        public Entity() { }

        public Entity(int id)
        {
            Id = id;
        }

        public Entity(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos)
        {
            foreach (PropertyInfo prop in propInfos)
            {
                prop.SetValue(this, propValues[prop.Name]);
            }
        }

        public string FormatToFile(List<PropertyInfo> propInfos)
        {
            string output = "";

            for (int i = 0; i < propInfos.Count; i++)
            {
                output += this.GetType().GetProperty(propInfos[i].Name).GetValue(this);

                if (i != propInfos.Count - 1)
                {
                    output += ',';
                }
            }

            return output;
        }

        public void PrintProperties(List<PropertyInfo> propInfos)
        {
            foreach (PropertyInfo propinfo in propInfos)
            {
                System.Console.WriteLine($"{propinfo.Name}: {propinfo.GetValue(this)}");
            }
        }
    }
}
