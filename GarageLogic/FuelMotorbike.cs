using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    class FuelMotorbike : FuelVehicle
    {
        private MotorbikeDetails            m_MotorbikeDetails;
        private static readonly int         sr_NumOfWheels = 2;
        private static readonly float       sr_MaxAirPressure = 31f;
        private static readonly float       sr_MaxFuel = 6.4f;
        private static readonly eFuelType   sr_FuelType = eFuelType.Octan98;

        public MotorbikeDetails.eLicenseType LicenseType
        {
            get
            {
                return m_MotorbikeDetails.LicenseType;
            }
            set
            {
                m_MotorbikeDetails.LicenseType = value;
            }
        }
        public int EngineVolume
        {
            get
            {
                return m_MotorbikeDetails.EngineVolume;
            }
            set
            {
                m_MotorbikeDetails.EngineVolume = value;
            }
        }
        
        public FuelMotorbike() : base(sr_NumOfWheels, sr_MaxAirPressure, sr_MaxFuel, sr_FuelType)
        {
            FuelRangeManager = new RangeManager(0, MaxFuel);
        }
        public override Details GetUniqueDetails()
        {
            return m_MotorbikeDetails;
        }
        public override void    SetUniqueDetails(Details i_Details)
        {
            m_MotorbikeDetails = i_Details as MotorbikeDetails;
        }
    }
}
