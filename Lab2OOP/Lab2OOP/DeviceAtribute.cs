using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    class DeviceAtribute : Attribute
    {
        public string NameDevice { get; set; }

        public DeviceAtribute() { }
        public DeviceAtribute(string nameDevice)
        {
            NameDevice = nameDevice;
        }

        public override string ToString()
        {
            return $"{NameDevice}";
        }
    }
}
