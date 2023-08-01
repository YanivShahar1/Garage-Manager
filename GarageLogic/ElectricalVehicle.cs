namespace Ex03.GarageLogic
{
    abstract class ElectricalVehicle : Vehicle
    {
        private RangeManager    m_BatteryRangeManager;
        private readonly float  r_MaxBatteryTimeInHours;

        protected RangeManager BatteryRangeManager
        {
            get
            {
                return m_BatteryRangeManager;
            }
            set
            {
                m_BatteryRangeManager = value;
            }
        }
        protected float MaxBatteryTimeInHours
        {
            get
            {
                return r_MaxBatteryTimeInHours;
            }
        }

        protected ElectricalVehicle(int i_NumOfWheels, float i_MaxAirPressure,
                                    float i_MaxBatteryTimeInHours)
                                    : base(i_NumOfWheels, i_MaxAirPressure)
        {
            r_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
        }

        public void             ChargeBattery(float i_NumOfHoursToAdd)
        {
            if (i_NumOfHoursToAdd >= 0)
            {
                m_BatteryRangeManager.Add(i_NumOfHoursToAdd);
            }
            else
            {
                throw new System.ArgumentException(string.Format(
                    $"Num Of Hours ({i_NumOfHoursToAdd}) Cannot Be Negative !")
                    );
            }
        }
        public override string  GetEnergyData()
        {
            return $"Current Battery: {BatteryRangeManager.Current}";
        }
        public override void    InitializeEnergy(float i_Energy)
        {
            ChargeBattery(i_Energy);
        }
    }
}