using System.Collections.Generic;
using System.Reflection;

namespace OOP_Task.Interfaces
{
    interface IEntity
    {
        int Id { get; set; }
        
        string FormatToFile(List<PropertyInfo> propInfos);

        void PrintProperties(List<PropertyInfo> propInfos);
    }
}
