namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Garage
    {
        // $G$ DSN-999 (-3) This Dictionary should be readonly.
        private Dictionary<string, OwnerOfVehicle> m_ListOfVehicles = new Dictionary<string, OwnerOfVehicle> { };

        public Dictionary<string, OwnerOfVehicle> ListOfVehicles
        {
            get { return m_ListOfVehicles; }
            set { m_ListOfVehicles = value; }
        }

        public OwnerOfVehicle FindOwner(string i_VehicalNumber)
        {
            OwnerOfVehicle o_Costumer;
            ListOfVehicles.TryGetValue(i_VehicalNumber, out o_Costumer);
            return o_Costumer;
        }

        public bool IsExistInGarage(string i_VehicalNumber)
        {
            return ListOfVehicles.ContainsKey(i_VehicalNumber);
        }

        public void AddVehicleToList(string i_LicenseNumber, OwnerOfVehicle i_Customer)
        {
            m_ListOfVehicles.Add(i_LicenseNumber, i_Customer);
        }

        public bool ChangeStatus(string i_VehicalNumber, eVehicleStatus i_Status)
        {
            bool hasChanged = false;
            if (ListOfVehicles.ContainsKey(i_VehicalNumber))
            {
                OwnerOfVehicle o_Costumer;
                ListOfVehicles.TryGetValue(i_VehicalNumber, out o_Costumer);
                o_Costumer.VehicleStatus = i_Status;
                hasChanged = true;
            }

            return hasChanged;
        }

        public bool FillAir(string i_License)
        {
            bool fullFlag = false;
            if (IsExistInGarage(i_License))
            {
                FindOwner(i_License).VehicleType.FillWheelAirToMax();
                fullFlag = true;
            }

            return fullFlag;
        }

        public void FillFuel(string i_License, float i_LitterNunToFill, eFuelTypes i_FuelType)
        {
            Fuel fuellEngine = FindOwner(i_License).VehicleType.Engine as Fuel;
            if (fuellEngine is Fuel fuel)
            {
                fuellEngine.FillFuel(i_LitterNunToFill, i_FuelType);
            }
        }

        public void ChargeBattery(string i_License, float i_MinutesToCharge)
        {
            Electric electricEngine = FindOwner(i_License).VehicleType.Engine as Electric;
            if (electricEngine is Electric electric)
            {
                electricEngine.ChargeBattery((int)i_MinutesToCharge / 60 + i_MinutesToCharge % 60 / 100);
            }
        }

        public string PrintInfo(string i_License)
        {
            return FindOwner(i_License).ToString();
        }
    }
}