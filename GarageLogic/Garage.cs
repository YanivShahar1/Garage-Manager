using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleState
        {
            Repairing,
            Repaired,
            Paid
        }

        private readonly Dictionary<string, Vehicle>        r_LicenseToVehiclesDictionary = new Dictionary<string, Vehicle>();
        private readonly Dictionary<string, ClientDetails>  r_LicenseToClientDictionary = new Dictionary<string, ClientDetails>();

        public void                 InsertVehicleToGarage(string i_License, Vehicle i_VehicleToAdd,
                                                          ClientDetails i_ClientDetails)
        {
            if (IsVehicleInGarage(i_License))
            {
                r_LicenseToClientDictionary[i_License].VehicleState = eVehicleState.Repairing;
            }
            else
            {
                r_LicenseToVehiclesDictionary.Add(i_License, i_VehicleToAdd);
                i_ClientDetails.VehicleState = eVehicleState.Repairing;
                r_LicenseToClientDictionary.Add(i_License, i_ClientDetails);
            }
        }
        public bool                 IsVehicleInGarage(string i_License)
        {
            return r_LicenseToVehiclesDictionary.ContainsKey(i_License);
        }
        public List<string>         GetLicensesOfVehiclesInGarage(List<eVehicleState> i_VehicleState)
        {
            List<string> licenses;
            if (i_VehicleState.Count == 0)
            {
                licenses = new List<string>(r_LicenseToClientDictionary.Keys);
            }
            else 
            {
                licenses = new List<string>();
                foreach (var licenseAndClient in r_LicenseToClientDictionary)
                {
                    foreach (eVehicleState vehicleState in i_VehicleState)
                    {
                        if (licenseAndClient.Value.VehicleState == vehicleState)
                        {
                            licenses.Add(licenseAndClient.Key);
                            break;
                        }
                    }
                }
            }
            return licenses;
        }
        public void                 UpdateVehicleState(string i_License, eVehicleState i_VehicleState)
        {
            checkIfVehicleInGarage(i_License);
            r_LicenseToClientDictionary[i_License].VehicleState = i_VehicleState;
        }
        public void                 InflateWheelsToMax(string i_License)
        {
            checkIfVehicleInGarage(i_License);
            Vehicle vehicleToInflate = r_LicenseToVehiclesDictionary[i_License];
            foreach(Wheel wheel in vehicleToInflate.WheelsList)
            {
                wheel.Inflate(vehicleToInflate.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }
        public void                 RefuelVehicle(string i_License, FuelVehicle.eFuelType i_FuelType,
                                                  float i_AmountToFuel)
        {
            checkIfVehicleInGarage(i_License);
            Vehicle vehicleToRefuel = r_LicenseToVehiclesDictionary[i_License];
            FuelVehicle fuelVehicleToRefuel = vehicleToRefuel as FuelVehicle;
            if (fuelVehicleToRefuel != null)
            {
                fuelVehicleToRefuel.Refuel(i_AmountToFuel, i_FuelType);
            }
            else
            {
                throw new System.FormatException($"{i_License} Is Not A Fuel Vehicle !");
            }
        }
        public void                 ChargeBatteryOfVehicle(string i_License, float i_AmountOfMinutesToCharge)
        {
            checkIfVehicleInGarage(i_License);
            Vehicle vehicleToCharge = r_LicenseToVehiclesDictionary[i_License];
            ElectricalVehicle electricalVehicleToCharge = vehicleToCharge as ElectricalVehicle;
            if (electricalVehicleToCharge != null)
            {
                electricalVehicleToCharge.ChargeBattery(i_AmountOfMinutesToCharge / 60f);
            }
            else
            {
                throw new System.FormatException($"{i_License} Is Not An Electrical Vehicle !");
            }
        }
        public DTOVehicleDetails    GetFullDetailsOfVehicle(string i_License)
        {
            checkIfVehicleInGarage(i_License);
            DTOVehicleDetails fullVehicleDetails = new DTOVehicleDetails();
            fullVehicleDetails.License = i_License;
            Vehicle vehicle = r_LicenseToVehiclesDictionary[i_License];
            ClientDetails client = r_LicenseToClientDictionary[i_License];
            fullVehicleDetails.ModelName = vehicle.ModelName;
            fullVehicleDetails.OwnerName = client.ClientName;
            List<WheelDetails> wheelDetailsList = getWheelDetailsListOfVehicle(vehicle);
            fullVehicleDetails.WheelDetailsList = wheelDetailsList;
            fullVehicleDetails.VehicleState = client.VehicleState;
            fullVehicleDetails.EnergyData = vehicle.GetEnergyData();
            fullVehicleDetails.UniqueDetails = vehicle.GetUniqueDetails();
            return fullVehicleDetails;
        }
        private List<WheelDetails>  getWheelDetailsListOfVehicle(Vehicle i_Vehicle)
        {
            List<WheelDetails> wheelDetailsList = new List<WheelDetails>(i_Vehicle.NumOfWheels);
            foreach (Wheel wheel in i_Vehicle.WheelsList)
            {
                WheelDetails wheelDetails = new WheelDetails(wheel.ManufacturerName, wheel.CurrentAirPressure);
                wheelDetailsList.Add(wheelDetails);
            }
            return wheelDetailsList;
        }
        private void                checkIfVehicleInGarage(string i_License)
        {
            if (!IsVehicleInGarage(i_License))
            {
                throw new System.ArgumentException(string.Format($"License {i_License} is not in garage !"));
            }
        }
    }
}