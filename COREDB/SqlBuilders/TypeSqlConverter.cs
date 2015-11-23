using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COREDB.SqlBuilders
{
    public static class TypeSqlConverter
    {
        public static string GetSqlType(Type type)
        {
            string typeName = type.Name;
            switch (typeName)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                    return "int";

                case "String":
                    return "ntext";

            }
            return null;
        }
    }
}
