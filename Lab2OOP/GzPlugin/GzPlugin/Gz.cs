using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2OOP;
using System.IO;
using System.IO.Compression;


namespace Gz
{
    public class PluginGg
    {
        public void Compress(string FilePath, Stream stream)
        {
            using (FileStream targetStream = File.Create(FilePath + ".gz"))
            {
                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(compressionStream);
                }
            }
        }
        public void Decompress(string FilePath, Stream stream)
        {
            using (FileStream sourceStream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(stream);
                }
            }
        }
        public override string ToString()
        {
            return $"gz";
        }
    }
}
