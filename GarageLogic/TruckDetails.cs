namespace Ex03.GarageLogic
{
    public class TruckDetails : Details
    {
        private bool    m_IsHazardousMaterials;
        private float   m_LoadVolume;

        public bool IsHazardousMaterials
        {
            get
            {
                return m_IsHazardousMaterials;
            }
            set
            {
                m_IsHazardousMaterials = value;
            }
        }
        public float LoadVolume
        {
            get
            {
                return m_LoadVolume;
            }
            set
            {
                m_LoadVolume = value;
            }
        }

        public override string ToString()
        {
            return $"Truck Details: Is Hazardous Materials = {IsHazardousMaterials}, Load Volume = {LoadVolume}";
        }
    }
}
