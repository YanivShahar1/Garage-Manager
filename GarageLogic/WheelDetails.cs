namespace Ex03.GarageLogic
{
    public struct WheelDetails
    {
        private string  m_ManufacturerName;
        private float   m_CurrentAirPressure;

        public string ManufacturerName
        {
            get 
            { 
                return m_ManufacturerName; 
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public WheelDetails(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }
    }
}
