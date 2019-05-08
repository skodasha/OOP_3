using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    public interface ICreator
    {
        object Create();
    }

    public class ComputerCreator : ICreator
    {
        public object Create()
        {
            return new Computer();
        }
    }

    public class LaptopCreator : ICreator
    {
        public object Create()
        {
            return new Laptop();
        }
    }


    public class PerconalCreator : ICreator
    {
        public object Create()
        {
            return new PersonalComputer();
        }
    }

    public class SmartCreator : ICreator
    {
        public object Create()
        {
            return new SmartDevice();
        }
    }

    public class SmartphoneCreator : ICreator
    {
        public object Create()
        {
            return new Smartphone();
        }
    }

    public class SmartWatchCreator : ICreator
    {
        public object Create()
        {
            return new SmartWatch();
        }
    }


    public class TabletCreator : ICreator
    {
        public object Create()
        {
            return new Tablet();
        }
    }
    public class OwnerCreator : ICreator
    {
        public object Create()
        {
            return new Owner();
        }
    }
}
