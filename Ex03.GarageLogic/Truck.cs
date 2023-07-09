namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Truck : Vehicle
    {
        private bool m_HasToxicMaterial;
        private int m_CargoCapacity;

        public Truck(string i_LicenseNumber, Fuel i_Engine) : base(i_LicenseNumber, 14, 34, i_Engine)
        {
        }

        public bool HasToxicMaterial
        {
            get { return m_HasToxicMaterial; }
            set { m_HasToxicMaterial = value; }
        }

        public int CargoCapacity
        {
            get { return m_CargoCapacity; }
            set
            {
                if (value >= 0)
                {
                    m_CargoCapacity = value;
                }
                else
                {
                    throw new ArgumentException("Cargo capacity cannot be negative\n");
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The truck has toxic  material ? :  {1}
The cargo capcity is : {2} ",
base.ToString(),
m_HasToxicMaterial,
m_CargoCapacity);
        }
    }
}