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
        void Serialize(List<Object> item, Stream stream);
        List<Object> Deserialize(List<Object> item, Stream stream);
    }

    public class BinarySerializer : Serializer
    {
        public override string ToString()
        {
            return $".dat";
        }

        public void Serialize(List<Object> itemList, Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, itemList);
        }

        public List<Object> Deserialize(List<Object> itemList, Stream stream)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Object> buf = new List<object>();
                buf = (List<Object>)formatter.Deserialize(stream);
                return buf;
            }
            catch
            {
                return null;
            }
            
        }
    }

    public class JSONSerializer : Serializer
    {
        public override string ToString()
        {
            return $".json";
        }

        public void Serialize(List<Object> itemList, Stream stream)
        {
            string jsonObject = JsonConvert.SerializeObject(itemList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.WriteLine(jsonObject);
            streamWriter.Flush();
        }

        public List<Object> Deserialize(List<Object> itemList, Stream stream)
        {
            try
            {
                StreamReader streamReader = new StreamReader(stream);
                string jsonObject = streamReader.ReadToEnd();
                streamReader.Close();
                object deserializedObject = JsonConvert.DeserializeObject<Object>(jsonObject, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.All
                });

                return (List<Object>)deserializedObject;
            }
            catch
            {
                return null;
            }
        }
    }

    public class TextSerializer: Serializer
    {
        public override string ToString()
        {
            return $".txt";
        }

        public void Serialize(List<Object> itemList, Stream stream)
        {
            string info = String.Empty;
            TextFormatter textFormatter = new TextFormatter();
            info = textFormatter.GetInfo(itemList);
            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.WriteLine(info);
            streamWriter.Flush();
        }

        public List<Object> Deserialize(List<Object> itemList, Stream stream)
        {
            try
            {
                StreamReader streamReader = new StreamReader(stream);
                string info = streamReader.ReadToEnd();
                streamReader.Close();
                TextParser textParser = new TextParser();
                object deserializedObj = textParser.GetObjects(info);
                return (List<Object>)deserializedObj;
            }
            catch
            {
                return null;
            }
                
        }

    }
}

