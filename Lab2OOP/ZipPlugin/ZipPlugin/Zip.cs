using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

using Lab2OOP;

namespace Zip
{
    public class PluginZip
    {
        public  void Compress(string FilePath, Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            using (ZipArchive archive = ZipFile.Open(FilePath + ".zip",ZipArchiveMode.Create))
            {
                ZipArchiveEntry zipArchiveEntry = archive.CreateEntry(FilePath.Substring(FilePath.LastIndexOf('\\') + 1));
                using(Stream enStream = zipArchiveEntry.Open())
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(enStream);
                }
            }
           
        }
        public void Decompress(string FilePath, Stream stream)
        {
             using (ZipArchive archive = ZipFile.OpenRead(FilePath))
             {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    using (Stream enStream = entry.Open())
                    {
                    //    stream.Seek(0, SeekOrigin.Begin);
                        enStream.CopyTo(stream);
                    }


                }
             }
        }
        public override string ToString()
        {
            return $"zip";
        }
    }
    
}
