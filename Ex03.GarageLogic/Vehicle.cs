namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // $G$ DSN-001 (-10) This class should have been abstract.
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPrecent;
        private Wheel[] m_Wheels;
        // $G$ DSN-001 (-8) You should have create a class for Engine instead of using generic object.
        private object m_Engine;

        public Vehicle(string i_LicenseNumber, int i_NumOfWheels, float i_MaxPressure, object i_Engine)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = new Wheel[i_NumOfWheels];
            m_Engine = i_Engine;

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(i_MaxPressure);
            }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public object Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }

        public float EnergyPrecent
        {
            get { return m_EnergyPrecent; }
            set
            {
                if ((value <= 100) && (value >= 0))
                {
                    m_EnergyPrecent = value;
                }
                else
                {
                    Exception error = new Exception("Wrong energy precent input");
                    throw new ValueOutOfRangeException(100f, 0f, error);
                }
            }
        }

        public Wheel[] Wheels
        {
            get { return m_Wheels; }
        }

        public void SetWheelPressure(float i_WheelPressure)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = i_WheelPressure;
            }
        }

        public void SetWheelManufactureName(string i_ManufacturerName)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public void FillWheelAirToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.FillAirToMax();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"The license number is : {0}
Model name is : {1}
{2}
The vechile has {3} wheels,
The details about wheels is : 
{4}",
m_LicenseNumber,
m_ModelName,
 m_Engine.ToString(),
 m_Wheels.Length,
 m_Wheels[0].ToString());
        }
    }
}