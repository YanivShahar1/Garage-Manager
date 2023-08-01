using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string              m_LicenseNumber;
        private Factory.eVehicles   m_ModelName;
        private float               m_CurrentEnergyLevel;
        private List<Wheel>         m_WheelsList;
        private readonly int        r_NumOfWheels;
        private readonly float      r_MaxAirPressure;

        public string LicenseNumber
        {
            get 
            {
                return m_LicenseNumber; 
            }
            set 
            { 
                m_LicenseNumber = value; 
            }
        }
        public Factory.eVehicles ModelName
        {
            get 
            {
                return m_ModelName; 
            }
            set 
            { 
                m_ModelName = value; 
            }
        }
        public float CurrentEnergyLevel
        {
            get 
            { 
                return m_CurrentEnergyLevel; 
            }
            set 
            { 
                m_CurrentEnergyLevel = value; 
            }
        }
        public List<Wheel> WheelsList
        {
            get 
            { 
                return m_WheelsList; 
            }
            set 
            { 
                m_WheelsList = value; 
            }
        }
        public int NumOfWheels
        {
            get
            {
                return r_NumOfWheels;
            }
        }
        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        protected Vehicle(int i_NumOfWheels, float i_MaxAirPressure)
        {
            r_NumOfWheels = i_NumOfWheels;
            r_MaxAirPressure = i_MaxAirPressure;
            InitWheelsList();
        }

        public void             InitWheelsList()
        {
            WheelsList = new List<Wheel>(NumOfWheels);
            for (int i = 0; i < NumOfWheels; i++)
            {
                WheelsList.Add(new Wheel(MaxAirPressure));
            }
        }
        public abstract string  GetEnergyData();
        public abstract Details GetUniqueDetails();
        public abstract void    SetUniqueDetails(Details i_Details);
        public void             UpdateWheelsListBasedOnWheelsDetails(List<WheelDetails> i_WheelDetailsList)
        {
            List<Wheel> clonedWheelsList = new List<Wheel>(WheelsList);
            int i = 0;
            if (clonedWheelsList.Count != i_WheelDetailsList.Count)
            {
                throw new System.ArgumentException("WheelDetailsList is not appropriate !");
            }
            foreach (Wheel wheel in clonedWheelsList)
            {
                wheel.ManufacturerName = i_WheelDetailsList[i].ManufacturerName;
                wheel.CurrentAirPressure = i_WheelDetailsList[i].CurrentAirPressure;
                i++;
            }
            m_WheelsList = clonedWheelsList;
        }
        public abstract void    InitializeEnergy(float i_Energy);
    }
}
