using System;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;
using System.Collections.Generic;
namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        private Garage                          m_Garage = new Garage();
        private readonly int                    m_MainMenuLength = 8;
        private readonly Factory.eVehicles[]    m_VehicleTypes = (Factory.eVehicles[])Factory.eVehicles.GetValues(typeof(Factory.eVehicles));

        public void                         StartMainMenu()
        {
            bool toQuit = false;
            while (!toQuit)
            {
                Console.Clear();
                displayWelcomeMessage();
                displayMainMenuToUser();
                int userChoice = getUserMainMenuOptionChoice();
                switch (userChoice)
                {
                    case 1:
                        insertVehicleToGarage();
                        break;
                    case 2:
                        filterLicenseNumbersByVehicelState();
                        break;
                    case 3:
                        updateVehicleState();
                        break;
                    case 4:
                        inflateVehicleWheelsToMax();
                        break;
                    case 5:
                        refuelAFuelVehicle();
                        break;
                    case 6:
                        chargeAnElectricalVehicle();
                        break;
                    case 7:
                        displayFullDetailsOfVehicle();
                        break;
                    case 8:
                        toQuit = true;
                        break;
                }
                if (userChoice != 8)
                {
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Thank you ! Bye !");
        }
        private void                        displayMainMenuToUser()
        {
            Console.WriteLine("1. Insert a new vehicle to garage");
            Console.WriteLine("2. Display a list of license numbers of all vehicles in garage");
            Console.WriteLine("3. Update vehicle's state in garage");
            Console.WriteLine("4. Inflate the wheels of a vehicle to the maximum");
            Console.WriteLine("5. Refuel a fuel vehicle");
            Console.WriteLine("6. Charge an electrical vehicle");
            Console.WriteLine("7. Display full details of a vehicle");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Choose one of the options (enter a number) and press Enter: ");
        }
        private bool                        isValidRangeMainMenuOptionChoice(int i_MainMenuOptionChoice)
        {
            return i_MainMenuOptionChoice >= 1 && i_MainMenuOptionChoice <= m_MainMenuLength;
        }
        private void                        displayWelcomeMessage()
        {
            Console.WriteLine("Welcome To Our Garage !");
        }
        private int                         getUserMainMenuOptionChoice()
        {
            bool isValidChoice = false;
            int choiceInt;
            do
            {
                string userChoice = Console.ReadLine();
                if (!int.TryParse(userChoice, out choiceInt))
                {
                    Console.WriteLine("Wrong Format !");
                }
                else if (!isValidRangeMainMenuOptionChoice(choiceInt))
                {
                    Console.WriteLine("Wrong Input !");
                }
                else
                {
                    isValidChoice = true;
                }
            } while (!isValidChoice);
            Console.Clear();
            return choiceInt;
        }
        private void                        displayFullDetailsOfVehicle()
        {
            string license = getLicenseFromUser();
            try
            {
                DTOVehicleDetails vehicleFullDetails = m_Garage.GetFullDetailsOfVehicle(license);
                Console.WriteLine("The full details of the vehicle:");
                Console.WriteLine(string.Format($"License: {vehicleFullDetails.License}"));
                Console.WriteLine(string.Format($"Model:   {vehicleFullDetails.ModelName}"));
                Console.WriteLine(string.Format($"Owner:   {vehicleFullDetails.OwnerName}"));
                Console.WriteLine(string.Format($"State:   {vehicleFullDetails.VehicleState}"));
                Console.WriteLine(vehicleFullDetails.EnergyData);
                displayWheelsDetails(vehicleFullDetails.WheelDetailsList);
                Console.WriteLine(vehicleFullDetails.UniqueDetails);
            }
            catch (System.ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private void                        displayWheelsDetails(List<WheelDetails> i_WheelDetailsList)
        {
            Console.WriteLine("Wheels:");
            int i = 1;
            foreach (WheelDetails wheelDetails in i_WheelDetailsList)
            {
                Console.WriteLine(string.Format($"{i}. Manufacturer: {wheelDetails.ManufacturerName}, Current Air Pressure: {wheelDetails.CurrentAirPressure}"));
                i++;
            }
        }
        private void                        chargeAnElectricalVehicle()
        {
            string license = getLicenseFromUser();
            float numOfMinutesToCharge = getNumOfMinutesToChargeFromUser();
            try
            {
                m_Garage.ChargeBatteryOfVehicle(license, numOfMinutesToCharge);
                Console.WriteLine("Vehicle battery charged successfully !");
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (System.ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private float                       getNumOfMinutesToChargeFromUser()
        {
            Console.WriteLine("Enter the number of minutes to charge: ");
            float numOfminutesToCharge = getValidFloatFromUser();
            return numOfminutesToCharge;
        }
        private void                        refuelAFuelVehicle()
        {
            string license = getLicenseFromUser();
            FuelVehicle.eFuelType fuelType = getUserChoiceFromEnum<FuelVehicle.eFuelType>("Fuel Types:");
            float amountToFuel = getAmountOfFuelFromUser();
            try
            {
                m_Garage.RefuelVehicle(license, fuelType, amountToFuel);
                Console.WriteLine("Vehicle refueled successfully !");
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (System.ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private float                       getAmountOfFuelFromUser()
        {
            Console.WriteLine("Enter amount of fuel (liters): ");
            float amountOfFuel = getValidFloatFromUser();
            return amountOfFuel;
        }
        private void                        inflateVehicleWheelsToMax()
        {
            string license = getLicenseFromUser();
            try
            {
                m_Garage.InflateWheelsToMax(license);
                Console.WriteLine("Vehicle wheels inflated to max successfully !");
            }
            catch(ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (System.ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private void                        updateVehicleState()
        {
            string license = getLicenseFromUser();
            Garage.eVehicleState newVehicleState = getUserChoiceFromEnum<Garage.eVehicleState>("Vehicle States:");
            try
            {
                m_Garage.UpdateVehicleState(license, newVehicleState);
                Console.WriteLine("Vehicle state updated successfully !");
            }
            catch(System.ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private void                        filterLicenseNumbersByVehicelState()
        {
            List<Garage.eVehicleState> vehicleStates = new List<Garage.eVehicleState>();
            if (theAnswerOfTheQuestionIsYes("Do you want to choose filters?"))
            {
                displayEnumMenu<Garage.eVehicleState>("Vehicle state in garage:");
                vehicleStates = getVehicleStatesFromUser();
            }
            List<string> licenses = m_Garage.GetLicensesOfVehiclesInGarage(vehicleStates);
            displayLicenseList(licenses);
        }
        private void                        displayLicenseList(List<string> i_Licenses)
        {
            int i = 1;
            if (i_Licenses.Count > 0)
            {
                Console.WriteLine("Licenses List:");
            }
            else
            {
                Console.WriteLine("No licenses match your filters.");
            }
            foreach (string license in i_Licenses)
            {
                Console.WriteLine(string.Format($"{i}. {license}"));
                i++;
            }
        }
        private List<Garage.eVehicleState>  getVehicleStatesFromUser()
        {
            Garage.eVehicleState[] vehicleStatesEnum = (Garage.eVehicleState[])Enum.GetValues(typeof(Garage.eVehicleState));
            List<Garage.eVehicleState> vehicleStates = new List<Garage.eVehicleState>();
            string[] choices;
            int choiceInt;
            bool isValidchoices = false;
            List<int> choicesIntList;
            do
            {
                choicesIntList = new List<int>();
                choices = Console.ReadLine().Split();
                if (choices.Length > vehicleStatesEnum.Length)
                {
                    Console.WriteLine("Too many states !");
                    isValidchoices = false;
                }
                else
                { 
                    foreach (string choice in choices)
                    {
                        if (!int.TryParse(choice, out choiceInt))
                        {
                            Console.WriteLine("Wrong Format !");
                            isValidchoices = false;
                            break;
                        }
                        if (choiceInt < 1 || choiceInt > vehicleStatesEnum.Length)
                        {
                            Console.WriteLine("Wrong Input !");
                            isValidchoices = false;
                            break;
                        }
                        choicesIntList.Add(choiceInt);
                        if (choicesIntList.Count == choices.Length)
                        {
                            isValidchoices = true;
                        }
                    }
                }
            } while (!isValidchoices);
            foreach (int choice in choicesIntList)
            {
                vehicleStates.Add(vehicleStatesEnum[choice - 1]);
            }
            return vehicleStates;
        }
        private void                        insertVehicleToGarage()
        {
            string license = getLicenseFromUser();
            if (m_Garage.IsVehicleInGarage(license))
            {
                Console.WriteLine(string.Format($"Vehicle licensed {license} is already in garage."));
            }
            else
            {
                Factory.eVehicles vehicleTypeToInsert = getVehicleTypeFromUser();
                Vehicle vehicleToInsert = Factory.CreateVehicle(vehicleTypeToInsert);
                vehicleToInsert.ModelName = vehicleTypeToInsert;
                ClientDetails clientDetails = getClientDetailsFromUser();
                updateVehicleWheelsBasedOnClientWheelsDetails(vehicleToInsert);
                updateEnergyToVehicleFromUser(vehicleToInsert);
                updateUniqueDetailsOfVehicle(vehicleTypeToInsert, vehicleToInsert);
                m_Garage.InsertVehicleToGarage(license, vehicleToInsert, clientDetails);
                Console.WriteLine("Vehicle Added successfully !");
            }
        }
        private void                        updateUniqueDetailsOfVehicle(Factory.eVehicles i_VehicleType, Vehicle i_Vehicle)
        {
            Details details;
            switch (i_VehicleType)
            {
                case Factory.eVehicles.ElectricalCar:
                case Factory.eVehicles.FuelCar:
                    details = getCarDetailsFromUser();
                    break;
                case Factory.eVehicles.ElectricalMotorbike:
                case Factory.eVehicles.FuelMotorbike:
                    details = getMotorbikeDetailsFromUser();
                    break;
                case Factory.eVehicles.Truck:
                    details = getTruckDetailsFromUser();
                    break;
                default:
                    throw new Exception("Wrong Vehicle Type !");
            }
            i_Vehicle.SetUniqueDetails(details);
        }
        private TruckDetails                getTruckDetailsFromUser()
        {
            TruckDetails truckDetails = new TruckDetails();
            truckDetails.IsHazardousMaterials = theAnswerOfTheQuestionIsYes("Is Hazardous Materials?");
            truckDetails.LoadVolume = getTruckLoadVolume();
            return truckDetails;
        }
        private float                       getTruckLoadVolume()
        {
            Console.WriteLine("Enter load volume: ");
            float loadVolume = getValidFloatFromUser();
            return loadVolume;
        }
        private MotorbikeDetails            getMotorbikeDetailsFromUser()
        {
            MotorbikeDetails motorbikeDetails = new MotorbikeDetails();
            motorbikeDetails.LicenseType = getUserChoiceFromEnum<MotorbikeDetails.eLicenseType>("Motorbike License Types:");
            motorbikeDetails.EngineVolume = getEngineVolumeFromUser();
            return motorbikeDetails;
        }
        private int                         getEngineVolumeFromUser()
        {
            int o_EngineVolumeInt;
            bool isValidEngineVolume = false;
            string engineVolume;
            Console.WriteLine("Enter engine volume: ");
            do
            {
                engineVolume = Console.ReadLine();
                if (!int.TryParse(engineVolume, out o_EngineVolumeInt))
                {
                    Console.WriteLine("Wrong Format !");
                }
                else if (o_EngineVolumeInt < 0)
                {
                    Console.WriteLine("Wrong Input !");
                }
                else
                {
                    isValidEngineVolume = true;
                }
            } while (!isValidEngineVolume);
            return o_EngineVolumeInt;
        }
        private CarDetails                  getCarDetailsFromUser()
        {
            CarDetails carDetails = new CarDetails();
            carDetails.Color = getUserChoiceFromEnum<CarDetails.eColor>("Car Colors:");
            carDetails.NumOfDoors = getUserChoiceFromEnum<CarDetails.eNumOfDoors>("Car Num Of Doors:");
            return carDetails;
        }
        private T                           getUserChoiceFromEnum<T>(string i_Headline)
        {
            T[] TEnum = (T[])Enum.GetValues(typeof(T));
            displayEnumMenu<T>(i_Headline);
            bool isValidChoice = false;
            int choiceInt;
            do
            {
                string userChoice = Console.ReadLine();
                if (!int.TryParse(userChoice, out choiceInt))
                {
                    Console.WriteLine("Wrong Format !");
                }
                else if (!isValidChoiceInEnumRange<T>(choiceInt))
                {
                    Console.WriteLine("Wrong Input !");
                }
                else
                {
                    isValidChoice = true;
                }
            } while (!isValidChoice);
            return TEnum[choiceInt - 1];
        }
        private bool                        isValidChoiceInEnumRange<T>(int i_Choice)
        {
            T[] TEnum = (T[])Enum.GetValues(typeof(T));
            return i_Choice >= 1 && i_Choice <= TEnum.Length;
        }
        private void                        displayEnumMenu<T>(string i_Headline)
        {
            Console.WriteLine(i_Headline);
            T[] TEnum = (T[])Enum.GetValues(typeof(T));
            int i = 1;
            foreach (T t in TEnum)
            {
                Console.WriteLine(string.Format($"{i}. {t}"));
                i++;
            }
            Console.WriteLine("Enter choice number: ");
        }
        private void                        updateEnergyToVehicleFromUser(Vehicle i_Vehicle)
        {
            bool isValidWheelsDetailsInput = false;
            float energy;
            do
            {
                if (i_Vehicle is FuelVehicle)
                {
                    energy = getEnergyFromUser("Enter Num of liters (fuel): ");
                }
                else
                {
                    energy = getEnergyFromUser("Enter Num of Hours (battery charging): ");
                }
                try
                {
                    i_Vehicle.InitializeEnergy(energy);
                    isValidWheelsDetailsInput = true;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (System.ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (System.Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (!isValidWheelsDetailsInput);
        }
        private float                       getEnergyFromUser(string i_AmountOfEnergyRequest)
        {
            Console.WriteLine(i_AmountOfEnergyRequest);
            float energy = getValidFloatFromUser();
            return energy;
        }
        private void                        updateVehicleWheelsBasedOnClientWheelsDetails(Vehicle i_Vehicle)
        {
            bool isValidWheelsDetailsInput = false;
            do
            {
                List<WheelDetails> wheelDetailsList = new List<WheelDetails>(i_Vehicle.NumOfWheels);
                if (theAnswerOfTheQuestionIsYes("Do you want to insert details for all wheels at once?"))
                {
                    string manufacturerName = getManufacturerNameFromUser();
                    float airPressure = getAirPressureFromUser();
                    for (int i = 0; i < i_Vehicle.NumOfWheels; i++)
                    {
                        wheelDetailsList.Add(new WheelDetails(manufacturerName, airPressure));
                    }
                }
                else
                {
                    for (int i = 0; i < i_Vehicle.NumOfWheels; i++)
                    {
                        wheelDetailsList.Add(
                            new WheelDetails(
                                getManufacturerNameFromUser(), getAirPressureFromUser()
                                ));
                    }
                }
                try
                {
                    i_Vehicle.UpdateWheelsListBasedOnWheelsDetails(wheelDetailsList);
                    isValidWheelsDetailsInput = true;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (System.ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (System.Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (!isValidWheelsDetailsInput);
        }
        private string                      getManufacturerNameFromUser()
        {
            Console.WriteLine("Enter manufacturer name: ");
            return Console.ReadLine();
        }
        private float                       getValidFloatFromUser()
        {
            string input;
            bool isValidInput= false;
            float o_Float;
            do
            {
                input = Console.ReadLine();
                if (!float.TryParse(input, out o_Float))
                {
                    Console.WriteLine("Wrong Format !");
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);
            return o_Float;
        }
        private float                       getAirPressureFromUser()
        {
            Console.WriteLine("Enter Air Pressure: ");
            float airPressure = getValidFloatFromUser();
            return airPressure;
        }
        private bool                        theAnswerOfTheQuestionIsYes(string i_Question)
        {
            Console.WriteLine(i_Question + " (Y/N).");
            string answer;
            bool validAnswer = false;
            do
            {
                answer = Console.ReadLine().ToUpper();
                validAnswer = isValidYesOrNoAnswer(answer);
                if (!validAnswer)
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
            } while (!validAnswer);
            return answer == "Y";
        }
        private bool                        isValidYesOrNoAnswer(string i_Answer)
        {
            i_Answer.ToUpper();
            return i_Answer == "Y" || i_Answer == "N";
        }
        private ClientDetails               getClientDetailsFromUser()
        {
            Console.WriteLine("Enter client name: ");
            string clientName = Console.ReadLine();
            string phoneNumber = getPhoneNumberFromUser();
            return new ClientDetails(clientName, phoneNumber);
        }
        private string                      getPhoneNumberFromUser()
        {
            Console.WriteLine("Enter phone number: ");
            string phoneNumber = Console.ReadLine();
            while (!isValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Wrong Format !");
                phoneNumber = Console.ReadLine();
            }
            return phoneNumber;
        }
        private bool                        isValidPhoneNumber(string i_PhoneNumber)
        {
            return int.TryParse(i_PhoneNumber, out int result);
        }
        private Factory.eVehicles           getVehicleTypeFromUser()
        {
            displayVehicleTypeMenu();
            bool isValidChoice = false;
            int choiceInt;
            do
            {
                string userChoice = Console.ReadLine();
                if (!int.TryParse(userChoice, out choiceInt))
                {
                    Console.WriteLine("Wrong Format !");
                }
                else if (!isValidRangeVehicleTypeMenu(choiceInt))
                {
                    Console.WriteLine("Wrong Input !");
                }
                else
                {
                    isValidChoice = true;
                }
            } while (!isValidChoice);
            return m_VehicleTypes[choiceInt - 1];
        }
        private bool                        isValidRangeVehicleTypeMenu(int i_VehicleTypeMenuOptionChoice)
        {
            return i_VehicleTypeMenuOptionChoice >= 1 && i_VehicleTypeMenuOptionChoice <= m_VehicleTypes.Length;
        }
        private void                        displayVehicleTypeMenu()
        {
            int i = 1;
            foreach (Factory.eVehicles vehicleType in m_VehicleTypes)
            {
                Console.WriteLine(string.Format($"{i}. {vehicleType}"));
                i++;
            }
            Console.WriteLine("Choose the type of your vehicle (enter a number): ");
        }
        private string                      getLicenseFromUser()
        {
            Console.WriteLine("Enter license number: ");
            string license = Console.ReadLine();
            while (!isValidLicenseNumber(license))
            {
                Console.WriteLine("Wrong Format !");
                license = Console.ReadLine();
            }
            return license;
        }
        private bool                        isValidLicenseNumber(string input)
        {
            Regex regex = new Regex("^[a-zA-Z0-9-]+$");
            return regex.IsMatch(input);
        }
    }
}