using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BasicFramework.Framework.Models;
using LumenWorks.Framework.IO.Csv;

namespace BasicFramework.Framework
{
    public static class Utils
    {
        public static List<User> GetUsersFromCSV()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\users.csv");
            
            List<User> users = new List<User>();
            using (CsvReader csv = new CsvReader(new StreamReader(filePath), true))
            {
                while (csv.ReadNextRecord())
                {
                    users.Add(new User() { Login = csv[0], Password = csv[1], FirstName = csv[2], LastName = csv[3] });
                }
            }

            return users;
        }
    }
}