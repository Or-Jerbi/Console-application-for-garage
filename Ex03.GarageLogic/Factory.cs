namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum eVehiclesTypes
    {
        ElectricCar = 0,
        RegularCar,
        ElectricMotorcycle,
        RegularMotorcycle,
        Truck
    }

    public class Factory
    {
        public eVehiclesTypes VehiclesFactory
        {
            get { return VehiclesFactory; }
            set
            {
                if (Enum.IsDefined(typeof(eVehiclesTypes), value))
                {
                    VehiclesFactory = value;
                }
                else
                {
                    Exception error = new Exception("Out of range of options");
                    float lengthOfEnum = Enum.GetValues(typeof(eVehiclesTypes)).Length;
                    throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                }
            }
        }

        public Vehicle NewVehicle(eVehiclesTypes i_WantedVehicle, string i_LicenseNumber)
        {
            switch (i_WantedVehicle)
            {
                case eVehiclesTypes.ElectricCar:
                    {
                        return CreateElectricCar(i_LicenseNumber);
                        break;
                    }

                case eVehiclesTypes.ElectricMotorcycle:
                    {
                        return CreateElectricMotorcycle(i_LicenseNumber);
                        break;
                    }

                case eVehiclesTypes.RegularCar:
                    {
                        return CreateRegularCar(i_LicenseNumber);
                        break;
                    }

                case eVehiclesTypes.RegularMotorcycle:
                    {
                        return CreateRegularMotorcycle(i_LicenseNumber);
                        break;
                    }

                case eVehiclesTypes.Truck:
                    {
                        return CreateTruck(i_LicenseNumber);
                        break;
                    }

                default:
                    {
                        return null;
                    }
            }
        }

        public Car CreateElectricCar(string i_LicenseNumber)
        {
            Electric O_Engine = new Electric(4.7f);
            Car electricCar = new Car(i_LicenseNumber, O_Engine);

            return electricCar;
        }

        public Car CreateRegularCar(string i_LicenseNumber)
        {
            Fuel O_Engine = new Fuel(50f, eFuelTypes.Octan95);
            Car regularCar = new Car(i_LicenseNumber, O_Engine);

            return regularCar;
        }

        public Motorcycle CreateElectricMotorcycle(string i_LicenseNumber)
        {
            Electric O_Engine = new Electric(1.6f);
            Motorcycle electricMotorcycle = new Motorcycle(i_LicenseNumber, O_Engine);

            return electricMotorcycle;
        }

        public Motorcycle CreateRegularMotorcycle(string i_LicenseNumber)
        {
            Fuel O_Engine = new Fuel(6f, eFuelTypes.Octan98);
            Motorcycle regularMotorcycle = new Motorcycle(i_LicenseNumber, O_Engine);

            return regularMotorcycle;
        }

        public Truck CreateTruck(string i_LicenseNumber)
        {
            Fuel O_Engine = new Fuel(120f, eFuelTypes.Soler);
            Truck truck = new Truck(i_LicenseNumber, O_Engine);

            return truck;
        }

        public override string ToString()
        {
            int index = 1;
            string text = string.Empty;
            foreach (string name in Enum.GetNames(typeof(eVehiclesTypes)))
            {
                text += "\n" + index + ". " + name;
                index++;
            }

            return text;
        }
    }
}