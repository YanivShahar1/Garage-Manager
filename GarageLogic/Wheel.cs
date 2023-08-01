namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private RangeManager    m_AirPressureRangeManager;
        private string          m_ManufacturerName;

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_AirPressureRangeManager.Current;
            }
            set
            {
                m_AirPressureRangeManager.Current = value;
            }
        }

        public Wheel(float i_MaxAirPressure)
        {
            m_AirPressureRangeManager = new RangeManager(0, i_MaxAirPressure);
        }

        public void Inflate(float i_AmountOfAirPressureToAdd)
        {
            if (i_AmountOfAirPressureToAdd >= 0)
            {
                m_AirPressureRangeManager.Add(i_AmountOfAirPressureToAdd);
            }
            else
            {
                throw new System.ArgumentException(string.Format(
                    $"Amount Of Air Pressure ({i_AmountOfAirPressureToAdd}) Cannot Be Negative !")
                    );
            }
        }
    }
}
