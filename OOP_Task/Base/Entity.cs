using System;
using System.Collections.Generic;
using System.Reflection;
using OOP_Task.Interfaces;

namespace OOP_Task.Entities
{
    public class Entity : IEntity
    {
        #region Properties

        #region Id
        private int _Id { get; set; }
        public int Id
        {
            get { return _Id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Entity ID must be greater than 0.");
                }
                _Id = value;
            }
        }
        #endregion

        #endregion

        #region Constructors
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
        #endregion

        #region Methods

        #region Format To File
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
        #endregion

        #region Print Properties
        public void PrintProperties(List<PropertyInfo> propInfos)
        {
            foreach (PropertyInfo propinfo in propInfos)
            {
                System.Console.WriteLine($"{propinfo.Name}: {propinfo.GetValue(this)}");
            }
        }
        #endregion

        #endregion
    }
}
