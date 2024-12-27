using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace XmlFormattingAssignment
{
    public static class XmlFormatter
    {
        public static string Convert(object obj)
        {
            StringBuilder xml = new StringBuilder();
            ConvertObjectToXml(obj, xml);
            return xml.ToString();
        }

        private static void ConvertObjectToXml(object obj, StringBuilder xml)
        {
            if (obj == null)
            {
                return;
            }

            Type objType = obj.GetType();
            xml.AppendLine($"<{objType.Name}>");

            foreach (var property in objType.GetProperties())
            {
                if (property.CanRead)
                {
                    try
                    {
                        var propertyValue = property.GetValue(obj);
                        if (propertyValue != null)
                        {
                            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                            {
                                xml.AppendLine($"  <{property.Name}>");
                                ConvertObjectToXml(propertyValue, xml);
                                xml.AppendLine($"  </{property.Name}>");
                            }
                            else if (propertyValue is DateTime dateTimeValue)
                            {
                                xml.AppendLine($"  <{property.Name}>{dateTimeValue.ToString("MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}</{property.Name}>");
                            }
                            else if (propertyValue is Array || propertyValue is IList)
                            {
                                xml.AppendLine($"  <{property.Name}>");
                                foreach (var item in (IEnumerable)propertyValue)
                                {
                                    xml.AppendLine("    <Item>");
                                    ConvertObjectToXml(item, xml);
                                    xml.AppendLine("    </Item>");
                                }
                                xml.AppendLine($"  </{property.Name}>");
                            }
                            else
                            {
                                xml.AppendLine($"  <{property.Name}>{propertyValue}</{property.Name}>");
                            }
                        }
                        else
                        {
                            xml.AppendLine($"  <{property.Name}/>");
                        }
                    }
                    catch (Exception ex)
                    {
                        xml.AppendLine($"  <{property.Name} Error>{ex.Message}</{property.Name}>");
                    }
                }
            }

            xml.AppendLine($"</{objType.Name}>");
        }
    }
}
