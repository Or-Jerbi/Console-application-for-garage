namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set
            {
                if (value.All(char.IsLetter))
                {
                    m_ManufacturerName = value;
                }
                // $G$ NTT-999 (-5) You should have use: Environment.NewLine instead of "\n".
                else
                {
                    throw new FormatException("Name of Manufacturer have to contain letters only\n");
                }
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if ((value <= m_MaxAirPressure) && (value >= 0))
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    Exception error = new Exception("Wrong air pressure input");
                    throw new ValueOutOfRangeException(m_MaxAirPressure, 0f, error);
                }
            }
        }

        public void AddAirPressure(float i_AirPressure)
        {
            if (m_CurrentAirPressure + i_AirPressure <= m_MaxAirPressure && i_AirPressure >= 0)
            {
                m_CurrentAirPressure += i_AirPressure;
            }
            else
            {
                Exception error = new Exception("Wrong air pressure input");
                throw new ValueOutOfRangeException(m_MaxAirPressure - m_CurrentAirPressure, 0f, error);
            }
        }

        public void FillAirToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format(
@"The manufacturer name : {0}
The current air pressure : {1}
The max Air pressure is :{2} ",
m_ManufacturerName,
m_CurrentAirPressure,
m_MaxAirPressure);
        }
    }
}