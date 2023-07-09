namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // $G$ CSS-999 (-5) Every Class/Enum/Struct which is not nested should be in a separate file.
    public enum eVehicleStatus
    {
        InRepair = 0,
        Repaired,
        Paid
    }

    public class OwnerOfVehicle
    {
        private string m_Name;
        private string m_PhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_VehicleType;

        public OwnerOfVehicle()
        {
        }

        public OwnerOfVehicle(Vehicle i_vehicle)
        {
            m_VehicleType = i_vehicle;
        }

        public string Name
        {
            get { return m_Name; }
            set
            {
                if (value.All(char.IsLetter))
                {
                    m_Name = value;
                }
                // $G$ NTT-999 (-5) You should have use: Environment.NewLine instead of "\n".
                else
                {
                    throw new FormatException("Name have to contain letters only\n");
                }
            }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set
            {
                if (value.All(char.IsDigit) && value.LongCount() == 10)
                {
                    m_PhoneNumber = value;
                }
                else
                {
                    string text = "Phone number must contain 10 numbers without digits\n";
                    throw new FormatException(text);
                }
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set
            {
                if (Enum.IsDefined(typeof(eVehicleStatus), value))
                {
                    m_VehicleStatus = value;
                }
                else
                {
                    Exception error = new Exception("Out of range of options");
                    float lengthOfEnum = Enum.GetValues(typeof(eVehicleStatus)).Length;
                    throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                }
            }
        }

        public Vehicle VehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }

        public override string ToString()
        {
            return string.Format(
@"The owner name is : {0}
The phone number is  : {1}
Vehcile type is : {2}
Vehcile status in the garage is : {3} ",
m_Name,
m_PhoneNumber,
m_VehicleType.ToString(),
m_VehicleStatus);
        }
    }
}