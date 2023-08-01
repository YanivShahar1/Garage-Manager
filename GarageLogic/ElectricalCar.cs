namespace Ex03.GarageLogic
{
    class ElectricalCar : ElectricalVehicle
    {
        private CarDetails              m_CarDetails;
        private static readonly int     sr_NumOfWheels = 5;
        private static readonly float   sr_MaxAirPressure = 33f;
        private static readonly float   sr_MaxBatteryTimeInHours = 5.2f;

        public CarDetails.eColor Color
        {
            get
            {
                return m_CarDetails.Color;
            }
            set
            {
                m_CarDetails.Color = value;
            }
        }
        public CarDetails.eNumOfDoors NumOfDoors
        {
            get
            {
                return m_CarDetails.NumOfDoors;
            }
            set
            {
                m_CarDetails.NumOfDoors = value;
            }
        }

        public ElectricalCar() : base(sr_NumOfWheels, sr_MaxAirPressure, sr_MaxBatteryTimeInHours)
        {
            BatteryRangeManager = new RangeManager(0, MaxBatteryTimeInHours);
        }
        public override Details GetUniqueDetails()
        {
            return m_CarDetails;
        }
        public override void    SetUniqueDetails(Details i_Details)
        {
            m_CarDetails = i_Details as CarDetails;
        }
    }
}
