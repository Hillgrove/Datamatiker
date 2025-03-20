using System.Collections;
using System.Reflection;
using System.Text;

namespace MyJsonLib
{
    public static class MyJsonConverter
    {
        public static string Serialize<T>(T obj)
        {
            if (obj == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];

                if (prop.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                object? value = prop.GetValue(obj);
                sb.Append($"\"{prop.Name}\":");

                if (value is IEnumerable enumerable && !(value is string))
                {
                    // Handle collections (like lists or arrays)
                    sb.Append("[");
                    bool first = true;
                    foreach (var item in enumerable)
                    {
                        if (!first) sb.Append(",");
                        first = false;
                        sb.Append(IsSimpleType(item.GetType()) ? $"\"{item}\"" : Serialize(item));
                    }
                    sb.Append("]");
                }
                else if (IsSimpleType(prop.PropertyType))
                {
                    // Handle simple types
                    sb.Append(value is string ? $"\"{value}\"" : value?.ToString());
                }
                else
                {
                    // Handle nested objects recursively
                    sb.Append(Serialize(value));
                }

                if (i < properties.Length - 1)
                    sb.Append(",");
            }


            sb.Append("}");            

            return sb.ToString();
        }

        public static T Deserialize<T>(string json)
        {
            throw new NotImplementedException();
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive || type.IsEnum ||
                type == typeof(string) ||
                type == typeof(decimal) ||
                type == typeof(DateTime) ||
                type == typeof(Guid) ||
                type == typeof(TimeSpan);
        }
    }
}
