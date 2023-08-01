namespace Ex03.GarageLogic
{
    class FuelTruck : FuelVehicle
    {
        private TruckDetails                m_TruckDetails;
        private static readonly int         sr_NumOfWheels = 14;
        private static readonly float       sr_MaxAirPressure = 26f;
        private static readonly float       sr_MaxFuel = 135f;
        private static readonly eFuelType   sr_FuelType = eFuelType.Soler;

        public bool IsHazardousMaterials
        {
            get
            {
                return m_TruckDetails.IsHazardousMaterials;
            }
            set
            {
                m_TruckDetails.IsHazardousMaterials = value;
            }
        }
        public float LoadVolume
        {
            get
            {
                return m_TruckDetails.LoadVolume;
            }
            set
            {
                m_TruckDetails.LoadVolume = value;
            }
        }

        public FuelTruck() : base(sr_NumOfWheels, sr_MaxAirPressure, sr_MaxFuel, sr_FuelType)
        {
            FuelRangeManager = new RangeManager(0, MaxFuel);
        }
        public override Details GetUniqueDetails()
        {
            return m_TruckDetails;
        }
        public override void    SetUniqueDetails(Details i_Details)
        {
            m_TruckDetails = i_Details as TruckDetails;
        }
    }
}
