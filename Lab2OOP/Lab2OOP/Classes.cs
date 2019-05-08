using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    public enum manufacturer
    {
        Apple,
        Samsung,
        Xiaomi,
        Huawei,
        Asus
    }
    [Serializable]
    public abstract class Device
    {
        int cost;
        int warranty;
        public Owner Owner { get; set; }

        public int Warranty
        {
            get
            {
                return warranty;
            }
            set
            {
                warranty = value;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        public manufacturer Manufacturer { get; set; }
    }

    public enum cpu
    {
        IntelCorei9,
        IntelCorei7,
        IntelCorei5,
        IntelCorei3,
        IntelCorem3,
        IntelCorem5,
        IntelCorem7,

    }
    [DeviceAtribute("Computer")]
    [Serializable]
    public class Computer : Device
    {
        int ram;
        int displaysize;
        public int Ram
        {
            get
            {
                return ram;
            }
            set
            {
                ram = value;
            }
        }

        public int Displaysize
        {
            get
            {
                return displaysize;
            }
            set
            {
                displaysize = value;
            }
        }
        public cpu Cpu { get; set; }
    }

    public enum floppyDisk
    {
        yes,
        no
    }
    [DeviceAtribute("Laptop")]
    [Serializable]
    public class Laptop : Computer
    {
        Double weight;
        public Double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public floppyDisk FloppyDisk { get; set; }

    }

    public enum bodyLight
    {
        yes,
        no
    }
    [DeviceAtribute("PersonalComputer")]
    [Serializable]
    public class PersonalComputer : Computer
    {
        int powerSupply;
        public int PowerSupply
        {
            get
            {
                return powerSupply;
            }
            set
            {
                powerSupply = value;
            }
        }
        public bodyLight BodyLight { get; set; }
    }

    public enum bluetooth
    {
        yes,
        no
    }
    [DeviceAtribute("SmartDevice")]
    [Serializable]
    public class SmartDevice : Device
    {
        int battery;
        public int Battery
        {
            get
            {
                return battery;
            }
            set
            {
                battery = value;
            }
        }
        public bluetooth Bluetooth { get; set; }
    }

    public enum headphoneOutput
    {
        type_Jack,
        type_miniJack,
        type_microJack,
        no
    }
    public enum wirelessCharging
    {
        yes,
        no
    }
    [DeviceAtribute("Smartphone")]
    [Serializable]
    public class Smartphone : SmartDevice
    {
        public headphoneOutput HeadphoneOutput { get; set; }
        public wirelessCharging WirelessCharging { get; set; }
    }

    public enum alarm
    {
        yes,
        no
    }
    public enum pulseMonitor
    {
        yes,
        no
    }
    public enum pedometr
    {
        yes,
        no
    }
    [DeviceAtribute("SmartWatch")]
    [Serializable]
    public class SmartWatch : SmartDevice
    {
        public alarm Alarm { get; set; }
        public pulseMonitor PulseMonitor { get; set; }
        public pedometr Pedometr { get; set; }

    }

    public enum screen3d
    {
        yes,
        no
    }
    public enum accessSIM
    {
        mini,
        micro,
        nano,
        no
    }

    [DeviceAtribute("Tablet")]
    [Serializable]
    public class Tablet : SmartDevice
    {
        public screen3d Screen3D { get; set; }
        public accessSIM AccessSIM { get; set; }
    }

    [DeviceAtribute("Owner")]
    [Serializable]
    public class Owner
    {
        string nameOwner;
        int ageOwner;
        int capitalOwner;
        public override string ToString()
        {
            return nameOwner;
        }
        public string NameOwner
        {
            get
            {
                return nameOwner;
            }
            set
            {
                nameOwner = value;
            }
        }
        public int AgeOwner
        {
            get
            {
                return ageOwner;
            }
            set
            {
                ageOwner = value;
            }
        }
        public int CapitalOwner
        {
            get
            {
                return capitalOwner;
            }
            set
            {
                capitalOwner = value;
            }
        }
    }
}
