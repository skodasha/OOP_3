using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab2OOP
{
    public interface IPlugin
    {
        void Compress(string FilePath);
        void Decompress(string FilePath);
        
    }


}
