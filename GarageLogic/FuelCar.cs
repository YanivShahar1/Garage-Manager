namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private CarDetails                  m_CarDetails;
        private static readonly int         sr_NumOfWheels = 5;
        private static readonly float       sr_MaxAirPressure = 33f;
        private static readonly float       sr_MaxFuel = 46f;
        private static readonly eFuelType   sr_FuelType = eFuelType.Octan95;

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
                m_CarDetails.NumOfDoors= value;
            }
        }

        public FuelCar() : base(sr_NumOfWheels, sr_MaxAirPressure, sr_MaxFuel, sr_FuelType)
        {
            FuelRangeManager = new RangeManager(0, MaxFuel);
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
