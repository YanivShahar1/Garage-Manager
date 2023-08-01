using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    class ElectricalMotorbike : ElectricalVehicle
    {
        private MotorbikeDetails        m_MotorbikeDetails;
        private static readonly int     sr_NumOfWheels = 2;
        private static readonly float   sr_MaxAirPressure = 31;
        private static readonly float   sr_MaxBatteryTimeInHours = 2.6f;

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

        public ElectricalMotorbike() : base(sr_NumOfWheels, sr_MaxAirPressure,
                                            sr_MaxBatteryTimeInHours)
        {
            BatteryRangeManager = new RangeManager(0, MaxBatteryTimeInHours);
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
