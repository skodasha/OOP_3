using System;
using HSLibrary;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Lab2OOP
{
    class TextParser
    {
        private List<Element> elementsList = new List<Element>();
        public char delimiter = ';';

        public object GetObjects(string info)
        {
            string objInfo = info;
            return SetObj(ref objInfo);
        }

        public object SetObj(ref string objInfo)
        {
            string objString = StrInfo(ref objInfo, '{', '}');
            Element element = new Element();
            while (objString.Length != 0)
            {
                string token = CutStrInfo(ref objString, delimiter);
                string property = CutStrInfo(ref token, ':').Trim('"');
                property = property.Trim('"');
                SetObjectProperties(ref element, property, token, ref objString);
            }
            elementsList.Add(element);

            return element.element;
        }
            
       

        public void SetObjectProperties(ref Element element,string property,string token, ref string objString)
        {
            switch (property)
            {
                case "$id":
                    element.id = Convert.ToInt32(token);
                    break;
                case "$type":
                    element.element = Activator.CreateInstance(Type.GetType(token));
                    break;
                case "$ref":
                    element = FindRef(Convert.ToInt32(token));
                    break;
                case "$values":
                    ArrayObj(ref element.element, token);
                    break;
                default:
                    if(token[0] == '{')
                    {
                        token = token + ',' + objString;
                        SetObjectValue(element.element, property, SetObj(ref token));
                        objString = token;
                    }
                    else
                        SetObjectValue(element.element, property, token);
                    break;
            }
        }
        public void ArrayObj(ref object obj,string token)
        {
            var list = (IList)obj;
            if (list != null)
            {
                string objString = StrInfo(ref token, '[', ']');
                int len = objString.Length;
                int j = 1;
                while (j != len)
                {
                    delimiter = ',';
                    list.Add(SetObj(ref objString));
                   
                    j = len - objString.Length;
                }

            }
            obj = list;
        }
        public void SetObjectValue(object obj,string propName,object propValue)
        {
            if (obj == null)
                return;
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propName);
            if (propValue.GetType().ToString() == "Lab2OOP."+propName)
                propertyInfo.SetValue(obj,propValue);
            else
            {
                try
                {
                    propertyInfo.SetValue(obj, Convert.ChangeType(propValue, propertyInfo.PropertyType));
                }
                catch
                {
                    Debug.WriteLine("Bad value: " + propValue + " for property " + propName);
                }
            }
            
            
        }

        public Element FindRef(int id)
        {
            if (elementsList.Count > 0)
            {
                for (int i = 0; i <elementsList.Count; i++)
                {
                    if (elementsList[i].id == id)
                        return elementsList[i];
                }
            }
            return null;
        }

        public string StrInfo(ref string info,char open,char close)
        {
            string result;

            if (info == null || info.Length <= 1)
               return "";

            Stack<char> stack = new Stack<char>();
            int i = 0;
            while (i < info.Length)
            {
                if (info[i] == open)
                    stack.Push(open);
                if (info[i] == close)
                    stack.Pop();
                if (stack.Count == 0)
                    break;
               i++;
            }
            result = info.Substring(1, i - 1).Trim();
            if (i != info.Length)
                info = info.Substring(i + 1).Trim();
            return result;
        }


        public string CutStrInfo(ref string str, char separator)
        {
            if (str == "")
                return "";

            int i = 0;
            while ((str[i] != separator) && (i < str.Length))
            {
                i++;
            }
            string result;
            result = str.Substring(0, i).Trim();
            str = str.Substring(i + 1).Trim();
            return result;
            

        }
    }
    
}
