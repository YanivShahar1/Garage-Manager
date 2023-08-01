namespace Ex03.GarageLogic
{
    public class Factory
    {
        public enum eVehicles
        {
            FuelMotorbike,
            ElectricalMotorbike,
            FuelCar,
            ElectricalCar,
            Truck
        }

        public static Vehicle CreateVehicle(eVehicles i_Vehicle)
        {
            Vehicle newVehicle = new FuelMotorbike();
            switch (i_Vehicle)
            {
                case eVehicles.FuelMotorbike:
                    newVehicle = new FuelMotorbike();
                    break;
                case eVehicles.ElectricalMotorbike:
                    newVehicle = new ElectricalMotorbike();
                    break;
                case eVehicles.FuelCar:
                    newVehicle = new FuelCar();
                    break;
                case eVehicles.ElectricalCar:
                    newVehicle = new ElectricalCar();
                    break;
                case eVehicles.Truck:
                    newVehicle = new FuelTruck();
                    break;
                default:
                    throw new System.ArgumentException(
                        string.Format($"{i_Vehicle} Is Not Supported !")
                        );
            }
            return newVehicle;
        }
    }
}
