namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        public enum eFuelType
        {
            Soler,
            Octan95, 
            Octan96,
            Octan98
        }
        private RangeManager        m_FuelRangeManager;
        private readonly eFuelType  r_FuelType;
        private readonly float      r_MaxFuel;

        protected RangeManager FuelRangeManager
        {
            get
            {
                return m_FuelRangeManager;
            }
            set
            {
                m_FuelRangeManager = value;
            }
        }
        protected eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
        protected float MaxFuel
        {
            get
            {
                return r_MaxFuel;
            }
        }

        public FuelVehicle(int i_NumOfWheels, float i_MaxAirPressure,
                           float i_MaxFuel, eFuelType i_FuelType)
                           : base(i_NumOfWheels, i_MaxAirPressure) 
        {
            r_MaxFuel = i_MaxFuel;
            r_FuelType = i_FuelType;
        }

        public void             Refuel(float i_NumOfLiters, eFuelType i_FuelType)
        {
            if (r_FuelType == i_FuelType)
            {
                if (i_NumOfLiters >= 0)
                {
                    m_FuelRangeManager.Add(i_NumOfLiters);
                }
                else
                {
                    throw new System.ArgumentException(string.Format(
                    $"Num Of Liters ({i_NumOfLiters}) Cannot Be Negative !")
                    );
                }
            }
            else
            {
                throw new System.ArgumentException(string.Format(
                    $"Fuel Type ({i_FuelType}) Is Not Matching To {r_FuelType}!")
                    );
            }
        }
        public override string  GetEnergyData()
        {
            return $"Current fuel: {FuelRangeManager.Current}, Fuel type: {FuelType}";
        }
        public override void    InitializeEnergy(float i_Energy)
        {
            Refuel(i_Energy, r_FuelType);
        }
    }
}
