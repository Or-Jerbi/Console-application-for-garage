namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum eFuelTypes
    {
        Soler = 0,
        Octan95,
        Octan96,
        Octan98
    }

    public class Fuel
    {
        private float m_CurrentFuelInLiters;
        private float m_MaxFuelInLiters;
        private eFuelTypes m_FuelType;

        public Fuel(float i_MaxFuelInLiters, eFuelTypes i_FuelType)
        {
            m_FuelType = i_FuelType;
            m_MaxFuelInLiters = i_MaxFuelInLiters;
        }

        public float CurrentFuelInLiters
        {
            get { return m_CurrentFuelInLiters; }
            set
            {
                if (value <= m_MaxFuelInLiters && value >= 0)
                {
                    m_CurrentFuelInLiters = value;
                }
                else
                {
                    Exception error = new Exception("Wrong fuel input");
                    throw new ValueOutOfRangeException(m_MaxFuelInLiters, 0f, error);
                }
            }
        }

        public float MaxFuelInLiters
        {
            get { return m_MaxFuelInLiters; }
        }

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
            set
            {
                if (Enum.IsDefined(typeof(eFuelTypes), value))
                {
                    m_FuelType = value;
                }
                else
                {
                    Exception error = new Exception("Out of range of options");
                    float lengthOfEnum = Enum.GetValues(typeof(eFuelTypes)).Length;
                    throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                }
            }
        }

        public void FillFuel(float i_FuelToFill, eFuelTypes i_FuelType)
        {
            if ((m_CurrentFuelInLiters + i_FuelToFill <= m_MaxFuelInLiters) && (i_FuelToFill >= 0) && (i_FuelType == m_FuelType))
            {
                m_CurrentFuelInLiters += i_FuelToFill;
            }
            else
            {
                Exception error = new Exception("Your input is out of range");
                throw new ValueOutOfRangeException(m_MaxFuelInLiters - m_CurrentFuelInLiters, 0f, error);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"The fuel have : {0} remaining liters
The maximum liters is  : {1}
The fuel type is : {2}",
m_CurrentFuelInLiters,
m_MaxFuelInLiters,
m_FuelType);
        }
    }
}