namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : System.Exception
    {
        private float   m_MaxValue;
        private float   m_MinValue;
        private string  m_ErrorMessage;

        public override string Message
        {
            get
            {
                return m_ErrorMessage;
            }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue,
                                        float i_CurrentValue, float i_ToAdd)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            m_ErrorMessage = string.Format(
                $"Current Value ({i_CurrentValue}) + Input ({i_ToAdd}) = {i_CurrentValue + i_ToAdd}" +
                $" Is Out Of Range ({m_MinValue} - {m_MaxValue}) !"
                );
        }
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue,
                                        float i_CurrentValue)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            m_ErrorMessage = string.Format(
                $"Current Value ({i_CurrentValue}) Is Out Of Range ({m_MinValue} - {m_MaxValue}) !"
                );
        }
    }
}