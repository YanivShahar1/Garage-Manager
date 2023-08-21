namespace Ex03.GarageLogic
{
    public class CarDetails : Details
    {
        public enum eColor
        {
            White,
            Black,
            Yellow,
            Red
        }
        public enum eNumOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five,
        }
        private eColor      m_Color;
        private eNumOfDoors m_NumOfDoors;

        public eColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
        public eNumOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                m_NumOfDoors = value;
            }
        }

        public override string ToString()
        {
            return $"Car Details: Color = {Color}, NumOfDoors = {NumOfDoors}";
        }
    }
}
