using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Lab2OOP
{
    public interface Serializer
    {
        void Serialize(List<Object> item);
        List<Object> Deserialize(List<Object> item);
        string FilePath { get; set; }

    }

    public class BinarySerializer : Serializer
    {
        public string FilePath { get; set; }

        public void Serialize(List<Object> itemList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(FilePath + ".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, itemList);
            }
        }

        public List<Object> Deserialize(List<Object> itemList)
        {
            if (FilePath.Substring(FilePath.Length - 3) == "dat")
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Object> buf = new List<object>();
                using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
                {
                    buf = (List<Object>)formatter.Deserialize(fs);
                }
                return buf;
            }
            return null;
        }
    }

    public class JSONSerializer : Serializer
    {
        public string FilePath { get; set; }

        public void Serialize(List<Object> itemList)
        {
            string jsonObject = JsonConvert.SerializeObject(itemList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
            using (StreamWriter fs = new StreamWriter(FilePath + ".json"))
            {
                fs.Write(jsonObject);
            }
        }

        public List<Object> Deserialize(List<Object> itemList)
        {
            if (FilePath.Substring(FilePath.Length - 4) == "json")
            {
                string jsonObject = String.Empty;

                using (StreamReader fs = new StreamReader(FilePath))
                {
                    jsonObject = fs.ReadToEnd();
                }

                object deserializedObject = JsonConvert.DeserializeObject<Object>(jsonObject, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.All
                });

                return (List<Object>)deserializedObject;
            }
            return null;
           
        }
    }

    public class TextSerializer: Serializer
    {
        public string FilePath { get; set; }

        public void Serialize(List<Object> itemList)
        {
            string info = String.Empty;
            TextFormatter textFormatter = new TextFormatter();
            info = textFormatter.GetInfo(itemList);
            using (StreamWriter streamWriter = new StreamWriter(FilePath + ".txt"))
            {
                streamWriter.Write(info);
            }
        }

        public List<Object> Deserialize(List<Object> itemList)
        {
            if (FilePath.Substring(FilePath.Length - 3) == "txt")
            {
                string info = String.Empty;
                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    info = streamReader.ReadToEnd();
                }
                TextParser textParser = new TextParser();
                object deserializedObj = textParser.GetObjects(info);
                return (List<Object>)deserializedObj;
            }
            return null;    
        }

    }
}

