using Example.DataAccess.Azure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Example.Business
{
    public class TableFinder
    {
        public object GetPersonTable()
        {
            var provider = ConfigurationManager.AppSettings["Provider"];
            Assembly assembly=null;
            Type type=null;
            switch (provider)
            {
                case "Azure":
                    assembly = Assembly.Load("Example.DataAccess.Azure");
                    type = assembly.GetType("Example.DataAccess.Azure.AzurePerson");
                    break;
                case "Sql":
                    assembly = Assembly.Load("Example.DataAccess");
                    type = assembly.GetType("Example.DataAccess.Person");
                    break;
                default:
                    break;
            }
            
            var inst = Activator.CreateInstance(type);           
            return inst;
        }
    }
}
