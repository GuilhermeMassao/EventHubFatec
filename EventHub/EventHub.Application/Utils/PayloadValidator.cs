
using System.Reflection;

namespace EventHub.Application.Utils
{
    public class PayloadValidator
    {
        private PayloadValidator() { }
        public static bool ValidateObject(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
