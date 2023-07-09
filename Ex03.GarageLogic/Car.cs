namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum eColor
    {
        Red = 0,
        Blue,
        White,
        Grey
    }

    public enum eNumOfDoors
    {
        Two = 0,
        Three,
        Four,
        Five
    }

    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_DoorNumber;

        public Car(string i_LicenseNumber, object i_Engine) : base(i_LicenseNumber, 5, 32, i_Engine)
        {
        }

        public eColor Color
        {
            get { return m_Color; }
            set
            {
                if (Enum.IsDefined(typeof(eColor), value))
                {
                    m_Color = value;
                }
                else
                {
                    Exception error = new Exception("Out of range of options");
                    float lengthOfEnum = Enum.GetValues(typeof(eColor)).Length;
                    throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                }
            }
        }

        public eNumOfDoors DoorNumber
        {
            get { return m_DoorNumber; }
            set
            {
                if (Enum.IsDefined(typeof(eNumOfDoors), value))
                {
                    m_DoorNumber = value;
                }
                else
                {
                    Exception error = new Exception("Out of range of options");
                    float lengthOfEnum = Enum.GetValues(typeof(eNumOfDoors)).Length;
                    throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Number of doors : {1}
The color is : {2}",
base.ToString(),
m_DoorNumber,
m_Color);
        }
    }
}