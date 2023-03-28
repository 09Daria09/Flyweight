using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    abstract class MilitaryUnit
    {
        public string Image { get; set; }
        public int Speed { get; set; }
        public int Power { get; set; }

        public abstract void Show(int x, int y);
    }

    class LightInfantry : MilitaryUnit
    {
        public LightInfantry()
        {
            Image = "light_infantry.png";
            Speed = 20;
            Power = 10;
        }

        public override void Show(int x, int y)
        {
            Console.WriteLine($"Light Infantry ({x}, {y})");
        }
    }

    class TransportVehicle : MilitaryUnit
    {
        public TransportVehicle()
        {
            Image = "transport_vehicle.png";
            Speed = 70;
            Power = 0;
        }

        public override void Show(int x, int y)
        {
            Console.WriteLine($"Transport Vehicle ({x}, {y})");
        }
    }

    class HeavyGroundVehicle : MilitaryUnit
    {
        public HeavyGroundVehicle()
        {
            Image = "heavy_ground_vehicle.png";
            Speed = 15;
            Power = 150;
        }

        public override void Show(int x, int y)
        {
            Console.WriteLine($"Heavy Ground Vehicle ({x}, {y})");
        }
    }

    class LightGroundVehicle : MilitaryUnit
    {
        public LightGroundVehicle()
        {
            Image = "light_ground_vehicle.png";
            Speed = 50;
            Power = 30;
        }

        public override void Show(int x, int y)
        {
            Console.WriteLine($"Light Ground Vehicle ({x}, {y})");
        }
    }

    class Aircraft : MilitaryUnit
    {
        public Aircraft()
        {
            Image = "aircraft.png";
            Speed = 300;
            Power = 100;
        }

        public override void Show(int x, int y)
        {
            Console.WriteLine($"Aircraft ({x}, {y})");
        }
    }

    class MilitaryUnitFactory
    {
        private Dictionary<string, MilitaryUnit> units = new Dictionary<string, MilitaryUnit>();

        public MilitaryUnit GetUnit(string type)
        {
            if (units.ContainsKey(type))
            {
                return units[type];
            }
            else
            {
                MilitaryUnit unit;
                switch (type)
                {
                    case "light_infantry":
                        unit = new LightInfantry();
                        break;
                    case "transport_vehicle":
                        unit = new TransportVehicle();
                        break;
                    case "heavy_ground_vehicle":
                        unit = new HeavyGroundVehicle();
                        break;
                    case "light_ground_vehicle":
                        unit = new LightGroundVehicle();
                        break;
                    case "aircraft":
                        unit = new Aircraft();
                        break;
                    default:
                        throw new ArgumentException("Invalid unit type");
                }
                units.Add(type, unit);
                return unit;
            }
        }
    }

    class Map
    {
        private MilitaryUnitFactory factory = new MilitaryUnitFactory();

        public void AddUnit(string type, int x, int y)
        {
            MilitaryUnit unit = factory.GetUnit(type);
            unit.Show(x, y);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();

            map.AddUnit("light_infantry", 10, 10);
            map.AddUnit("light_ground_vehicle", 50, 50);
            map.AddUnit("heavy_ground_vehicle", 100, 100);
            map.AddUnit("transport_vehicle", 150, 150);
            map.AddUnit("aircraft", 200, 200);

            Console.ReadKey();
        }
    }
}
