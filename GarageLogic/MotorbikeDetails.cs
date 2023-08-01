namespace Ex03.GarageLogic
{
    public class MotorbikeDetails : Details
    {
        public enum eLicenseType
        {
            A1, 
            A2, 
            AA, 
            B1
        }
        private eLicenseType    m_LicenseType;
        private int             m_EngineVolume;

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }
        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }
        }

        public override string ToString()
        {
            return $"Motorbike Details: LicenseType = {LicenseType}, EngineVolume = {EngineVolume}";
        }
    }
}
