namespace Ex03.GarageLogic
{
    public class RangeManager
    {
        private float m_Min;
        private float m_Max;
        private float m_Current = 0f;

        public float Min
        {
            get 
            { 
                return m_Min; 
            }
        }
        public float Max
        {
            get 
            { 
                return m_Max; 
            }
        }
        public float Current
        {
            get 
            { 
                return m_Current; 
            }
            set
            {
                if (value > m_Max || value < m_Min)
                {
                    throw new ValueOutOfRangeException(Min, Max, value);
                }
                m_Current = value;
            }
        }

        public RangeManager(float i_Min, float i_Max)
        {
            m_Min = i_Min;
            m_Max = i_Max;
            m_Current = i_Min;
        }

        public void Add(float i_ToAdd)
        {
            if (m_Current + i_ToAdd <= m_Max)
            {
                m_Current += i_ToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(Min, Max, Current, i_ToAdd);
            }
        }
    }
}
