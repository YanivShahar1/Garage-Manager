namespace Ex03.GarageLogic
{
    public class ClientDetails
    {
        private string                  m_ClientName;
        private string                  m_PhoneNumber;
        private Garage.eVehicleState    m_VehicleState;

        public string ClientName
        {
            get
            {
                return m_ClientName;
            }
            set
            {
                m_ClientName = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
            set
            {
                m_PhoneNumber = value;
            }
        }
        internal Garage.eVehicleState VehicleState
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

        public ClientDetails(string i_ClientName, string i_PhoneNumber)
        {
            m_ClientName = i_ClientName;
            m_PhoneNumber = i_PhoneNumber;
        }
    }
}
