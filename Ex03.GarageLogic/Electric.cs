namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Electric
    {
        private float m_RemainingHoursInBattery;
        private float m_MaxBattery;

        public Electric(float i_MaxBattery)
        {
            m_MaxBattery = i_MaxBattery;
        }

        public float RemainingHoursInBattery
        {
            get { return m_RemainingHoursInBattery; }
            set
            {
                if (value <= m_MaxBattery && value >= 0)
                {
                    m_RemainingHoursInBattery = value;
                }
                else
                {
                    Exception error = new Exception("Wrong precent of battery input");
                    throw new ValueOutOfRangeException(m_MaxBattery, 0f, error);
                }
            }
        }

        public float MaxBattery
        {
            get { return m_MaxBattery; }
        }

        // $G$ DSN-012 (-7) Code duplication! This method, and the method inside the Fuel class are doing the same.
        // You should have create an abstract class represents Engine, with an abstract method for refill engine capacity,
        // and then you have a common functionality for both classes.
        public void ChargeBattery(float i_HoursToCharge)
        {
            if (m_RemainingHoursInBattery + i_HoursToCharge <= m_MaxBattery && i_HoursToCharge >= 0)
            {
                m_RemainingHoursInBattery += i_HoursToCharge;
            }
            else
            {
                Exception error = new Exception("Wrong charging hours input");
                throw new ValueOutOfRangeException(m_MaxBattery - m_RemainingHoursInBattery, 0f, error);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"The battery have : {0} remaining hours
The maximum hours of battery is  : {1}",
m_RemainingHoursInBattery,
m_MaxBattery);
        }
    }
}