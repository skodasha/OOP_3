using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Lab2OOP
{
    class TextFormatter
    {
        private int idCount = 0;
        private List<Element> elementsList = new List<Element>();

        public char openArray = '[';
        public char closeArray = ']';
        public char openObject = '{';
        public char closeObject = '}';
        public char delimiterObject = ',';
        public char delimiterList = ';';
        public string arrayAttribute = "$values";
        public string typeAttribute = "$type";
        public string idAttribute = "$id";
        public string referenceAttribute = "$ref";

        public string ReferenceFormatter(int idObj)
        {
            StringBuilder textSerializer = new StringBuilder();

            textSerializer.AppendLine("" + openObject);
            textSerializer.AppendLine("    " + referenceAttribute + ':' + "  " + idObj + delimiterObject);
            textSerializer.Append("   " + closeObject);

            return textSerializer.ToString();
        }

        public int FindObj(object obj)
        {
            if (elementsList.Count > 0)
            {
                for (int i = 0; i < elementsList.Count; i++)
                {
                    if (elementsList[i].element.Equals(obj))
                        return elementsList[i].id;
                }
            }
            return -1;
        }

        public string ObjFormatter(object obj)
        {
            int idObj = FindObj(obj);
            if (idObj != -1)
            {
                return ReferenceFormatter(idObj);
            }
            else
            {
                elementsList.Add(new Element(obj, idCount));

                StringBuilder objBuilder = new StringBuilder();
                objBuilder.AppendLine("" + openObject);
                objBuilder.AppendLine("  " + '"' + idAttribute + '"' + ':' + "  " + (idCount++).ToString() + delimiterObject);
                objBuilder.AppendLine("  " + '"' + typeAttribute + '"' + ':' + "  " + obj.GetType().ToString() + delimiterObject);
                foreach (var property in obj.GetType().GetProperties())
                {
                    objBuilder.AppendLine("  " + '"' + property.Name + '"' + ':' + "  ");
                    if (property.PropertyType.IsClass && (property.PropertyType != typeof(string)))
                    {
                        objBuilder.Append("   " + ObjFormatter(property.GetValue(obj)));
                    }
                    else
                    {
                        if (property.PropertyType.IsEnum)
                        {
                            objBuilder.Append("   " + ((int)property.GetValue(obj)).ToString() + delimiterObject);
                        }
                        else
                            objBuilder.Append("   " + property.GetValue(obj).ToString() + delimiterObject);

                    }
                    objBuilder.AppendLine();
                }
                objBuilder.AppendLine("" + closeObject);
                return objBuilder.ToString();
            }

        }
        public string GetInfo(List<object> objList)
        {
            StringBuilder textSerializer = new StringBuilder();
            textSerializer.AppendLine("" + openObject);
            textSerializer.AppendLine("  " + '"' + typeAttribute + '"' + ':' + "  " + objList.GetType().ToString() + delimiterList);
            textSerializer.AppendLine("  " + '"' + arrayAttribute + '"' + ":" + "  " + openArray);
            foreach (object obj in objList)
            {
                textSerializer.AppendLine(ObjFormatter(obj));                
            }
            textSerializer.AppendLine("" + closeArray + delimiterList);
            textSerializer.AppendLine("" + closeObject);
            return textSerializer.ToString();
        }
    }

    public class Element
    {
        public int id;
        public object element;
        public Element(object obj,int id)
        {
            this.element = obj;
            this.id = id;
        }
        public Element()
        {

        }
    }
}
