namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Ex03.GarageLogic;

    public enum eOptions
    {
        NewCar = 1,
        ShowListOfVehicles,
        ChangeStatus,
        FillAir,
        FillGas,
        ChrageBattery,
        VehcileDetails
    }

    public class UI
    {
        // $G$ DSN-999 (-3) This Object should be readonly.
        private Garage m_Garage = new Garage();
        private eOptions m_UserOptions;

        // $G$ DSN-007 (-5) This method is too long.
        public void GetUserOption(eOptions i_UserOption, string i_LicenseInput)
        {
            switch (i_UserOption)
            {
                case eOptions.NewCar:
                    {
                        GetDetailsAboutVehicle(i_LicenseInput);
                        UserScreen();
                        break;
                    }

                case eOptions.ShowListOfVehicles:
                    {
                        Console.WriteLine("Choose which list you like to see");
                        PrintEnumValues<eVehicleStatus>();
                        string input = Console.ReadLine();
                        eVehicleStatus userOption = (eVehicleStatus)Convert.ToInt32(input);
                        foreach (string key in m_Garage.ListOfVehicles.Where(x => x.Value.VehicleStatus == userOption).Select(x => x.Key))
                        {
                            Console.WriteLine(key);
                        }

                        UserScreen();
                        break;
                    }

                case eOptions.ChangeStatus:
                    {
                        PrintEnumValues<eVehicleStatus>();
                        string input = Console.ReadLine();
                        eVehicleStatus userOption = (eVehicleStatus)Convert.ToInt32(input);
                        if (!m_Garage.ChangeStatus(i_LicenseInput, userOption))
                        {
                            Console.WriteLine("License number doesn't exist in the garage");
                        }
                        else
                        {
                            Console.WriteLine(m_Garage.FindOwner(i_LicenseInput).VehicleStatus);
                        }

                        UserScreen();
                        break;
                    }

                case eOptions.FillAir:
                    {
                        if (m_Garage.FillAir(i_LicenseInput))
                        {
                            Console.WriteLine("Wheels is full to max pressure");
                        }
                        else
                        {
                            Console.WriteLine("could't fill air in wheels");
                        }

                        UserScreen();
                        break;
                    }

                case eOptions.FillGas:
                    {
                        if (m_Garage.IsExistInGarage(i_LicenseInput))
                        {
                            float o_Fuel;
                            Console.WriteLine("Insert numbers of gass to fill");
                            float.TryParse(Console.ReadLine(), out o_Fuel);
                            Console.WriteLine("Insert number of gass type");
                            PrintEnumValues<eFuelTypes>();
                            string input = Console.ReadLine();
                            eFuelTypes userOption = (eFuelTypes)Convert.ToInt32(input);
                            m_Garage.FillFuel(i_LicenseInput, o_Fuel, userOption);
                        }
                        else
                        {
                            Console.WriteLine("License number don't exist in garage");
                        }

                        UserScreen();
                        break;
                    }

                case eOptions.ChrageBattery:
                    {
                        if (m_Garage.IsExistInGarage(i_LicenseInput))
                        {
                            int o_MinutesToCharge;
                            Console.WriteLine("Insert number of minutes you want to charge (for example 65 mintues)");
                            int.TryParse(Console.ReadLine(), out o_MinutesToCharge);
                            m_Garage.ChargeBattery(i_LicenseInput, o_MinutesToCharge);
                        }
                        else
                        {
                            Console.WriteLine("License number don't exist in garage");
                        }

                        UserScreen();
                        break;
                    }

                case eOptions.VehcileDetails:
                    {
                        if (m_Garage.IsExistInGarage(i_LicenseInput))
                        {
                            Console.WriteLine(m_Garage.PrintInfo(i_LicenseInput));
                        }
                        else
                        {
                            Console.WriteLine("License number don't exist in garage");
                        }

                        UserScreen();
                        break;
                    }
            }
        }

        public void GetDetailsAboutVehicle(string i_LicenseInput)
        {
            bool exceptionThrownFlag = true;
            while (exceptionThrownFlag)
            {
                if (m_Garage.IsExistInGarage(i_LicenseInput))
                {
                    Console.WriteLine("The Vehicle is in the garage");
                    break;
                }

                Vehicle newVehicle = AddToGarage(i_LicenseInput);
                try
                {
                    Console.WriteLine("Please insert current air wheel pressure");
                    newVehicle.SetWheelPressure(float.Parse(Console.ReadLine()));
                    Console.WriteLine("Please insert wheel's Manufacture Name");
                    newVehicle.SetWheelManufactureName(Console.ReadLine());
                    Console.WriteLine("Please insert current energy precent");
                    newVehicle.EnergyPrecent = float.Parse(Console.ReadLine());
                    if (newVehicle.Engine is Electric electric)
                    {
                        electric.RemainingHoursInBattery = newVehicle.EnergyPrecent;
                    }
                    else if (newVehicle.Engine is Fuel fuel)
                    {
                        fuel.CurrentFuelInLiters = newVehicle.EnergyPrecent;
                    }
                }
                catch (Exception error)
                {
                    if (error is ValueOutOfRangeException)
                    {
                        Console.WriteLine((error as ValueOutOfRangeException).InnerException.Message);
                    }
                    else if (error is FormatException)
                    {
                        Console.WriteLine("Error: " + error.InnerException.Message);
                    }

                    Console.WriteLine(error.InnerException.Message + "\nEnter your full details once again please\n");
                    GetDetailsAboutVehicle(i_LicenseInput);
                }

                Type vehicleType = newVehicle.GetType();
                PropertyInfo[] properties = vehicleType.GetProperties();
                try
                {
                    foreach (PropertyInfo property in properties)
                    {
                        if (property.CanWrite)
                        {
                            if (property.PropertyType.IsEnum)
                            {
                                string[] names = Enum.GetNames(property.PropertyType);

                                Console.WriteLine(@"Enter a value for {0} from the following options: ", property.Name);
                                for (int i = 0; i < names.Length; i++)
                                {
                                    Console.WriteLine(@"{0}. {1}", i, names[i]);
                                }

                                int enumIndex = int.Parse(Console.ReadLine());
                                float lengthOfEnum = Enum.GetValues(property.PropertyType).Length;

                                if (enumIndex < lengthOfEnum)
                                {
                                    object enumValue = Enum.Parse(property.PropertyType, names[enumIndex]);
                                    property.SetValue(newVehicle, enumValue);
                                }
                                else
                                {
                                    Exception error = new Exception("Out of range of options");
                                    throw new ValueOutOfRangeException(lengthOfEnum - 1, 0f, error);
                                }
                            }
                            else if (property.Name != "Engine" && property.Name != "Wheel" && property.Name != "LicenseNumber"
                                && property.Name != "EnergyPrecent")
                            {
                                Console.WriteLine(@"Enter a value for {0}: ", property.Name);
                                if (property.PropertyType == typeof(bool))
                                {
                                    Console.WriteLine("Please enter true or false");
                                }

                                string input = Console.ReadLine();
                                object value = Convert.ChangeType(input, property.PropertyType);
                                property.SetValue(newVehicle, value);
                            }
                        }
                    }

                    GetDetailsAboutOwner(newVehicle);
                    Console.WriteLine(newVehicle.ToString());
                    exceptionThrownFlag = false;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.InnerException.Message + "\nEnter your full details once again please\n");
                }
            }
        }

        public void GetDetailsAboutOwner(Vehicle i_Vehicle)
        {
            OwnerOfVehicle customer = new OwnerOfVehicle();
            Type detailsOfCustomer = customer.GetType();
            PropertyInfo[] properties = detailsOfCustomer.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    if (property.Name != "VehicleType" && property.Name != "VehicleStatus")
                    {
                        Console.WriteLine(@"Enter a value for owner {0}: ", property.Name);
                        string input = Console.ReadLine();
                        object value = Convert.ChangeType(input, property.PropertyType);
                        property.SetValue(customer, value);
                    }
                    else
                    {
                        customer.VehicleType = i_Vehicle;
                    }
                }
            }

            customer.VehicleStatus = eVehicleStatus.InRepair;
            m_Garage.ListOfVehicles.Add(i_Vehicle.LicenseNumber, customer);
        }

        public Vehicle AddToGarage(string i_License)
        {
            bool exceptionThrownFlag = true;

            while (exceptionThrownFlag)
            {
                try
                {
                    Factory factory = new Factory();
                    Console.WriteLine(string.Format(@"Which Vehicle would you like to repair in the garage"));
                    PrintEnumValues<eVehiclesTypes>();
                    string inputChoice = Console.ReadLine();
                    float lengthOfEnum = Enum.GetValues(typeof(eVehiclesTypes)).Length;
                    if (Convert.ToInt32(inputChoice) < lengthOfEnum && Convert.ToInt32(inputChoice) >= 0)
                    {
                        eVehiclesTypes userOption = (eVehiclesTypes)Convert.ToInt32(inputChoice);
                        Console.WriteLine(userOption);
                        exceptionThrownFlag = false;
                        return factory.NewVehicle(userOption, i_License);
                    }
                    else
                    {
                        Exception error = new Exception("Out of range of options\n");
                        throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.InnerException.Message);
                }
            }

            return null;
        }

        public void UserScreen()
        {
            bool exceptionThrownFlag = true;

            while (exceptionThrownFlag)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine(string.Format(
    @"Welcome to our garage !!!

What would you like to do ?
1. Enter a new vehicle to the garage
2. Show the list of number license
3. Change status of a vehcile in the garage
4. Fill air in a vehcile to maximum
5. Fill fuel in a vehcile
6. Chrage an electic vehicle
7. Show a full detials of vehcile by number license"));

                    string input = Console.ReadLine();
                    float lengthOfEnum = Enum.GetValues(typeof(eOptions)).Length;
                    if (Convert.ToInt32(input) <= lengthOfEnum && Convert.ToInt32(input) > 0)
                    {
                        eOptions userOption = (eOptions)Convert.ToInt32(input);
                        Console.WriteLine("Please insert Vehicle License");
                        string licenseInput = Console.ReadLine();
                        GetUserOption(userOption, licenseInput);
                        exceptionThrownFlag = false;
                    }
                    else
                    {
                        Exception error = new Exception("Out of range of options\n");
                        throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        public void PrintEnumValues<T>() where T : Enum
        {
            int index = 0;
            string text = string.Empty;
            foreach (string value in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine(index + ". " + value);
                index++;
            }
        }
    }
}