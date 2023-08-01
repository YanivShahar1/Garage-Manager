using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    // Data Transfer Object
    public class DTOVehicleDetails
    {
        private string                  m_License;
        private string                  m_OwnerName;
        private Factory.eVehicles       m_ModelName;
        private Garage.eVehicleState    m_VehicleState;
        private List<WheelDetails>      m_WheelDetailsList;
        private string                  m_EnergyData;
        Details                         m_UniqueDetails;

        public string License
        {
            get
            {
                return m_License;
            }
            set
            {
                m_License = value;
            }
        }
        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
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
        public Garage.eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }
            set
            {
                m_VehicleState = value;
            }
        }
        public List<WheelDetails> WheelDetailsList
        {
            get
            {
                return m_WheelDetailsList;
            }
            set
            {
                m_WheelDetailsList = value;
            }
        }
        public string EnergyData
        {
            get
            {
                return m_EnergyData;
            }
            set
            {
                m_EnergyData = value;
            }
        }
        public Details UniqueDetails
        {
            get
            {
                return m_UniqueDetails;
            }
            set
            {
                m_UniqueDetails = value;
            }
        }
    }
}
