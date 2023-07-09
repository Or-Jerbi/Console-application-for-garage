namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // $G$ CSS-999 (-5) Every Class/Enum/Struct which is not nested should be in a separate file.
    public enum eDriverLicense
    {
        A = 0,
        A1,
        AA,
        B
    }

    public class Motorcycle : Vehicle
    {
        private eDriverLicense m_DriverLicense;
        private int m_EngineCapacity;

        public Motorcycle(string i_LicenseNumber, object i_Engine) : base(i_LicenseNumber, 2, 28, i_Engine)
        {
        }

        public eDriverLicense DriverLiecense
        {
            get { return m_DriverLicense; }
            set
            {
                if (Enum.IsDefined(typeof(eDriverLicense), value))
                {
                    m_DriverLicense = value;
                }
                else
                {
                    Exception error = new Exception("Out of range of options");
                    float lengthOfEnum = Enum.GetValues(typeof(eDriverLicense)).Length;
                    throw new ValueOutOfRangeException(lengthOfEnum, 1f, error);
                }
            }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set
            {
                if (value >= 0)
                {
                    m_EngineCapacity = value;
                }
                else
                {
                    throw new ArgumentException("Wrong capacity engine input");
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The driver license type is : {1}
The engine capcity is : {2} ",
base.ToString(),
m_DriverLicense,
m_EngineCapacity);
        }
    }
}