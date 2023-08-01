# Garage-Management-System

### Overview
This console-based application simulates a garage management system. It showcases the use of object-oriented principles and various design patterns.

### Features

#### Vehicle Management
Handles different types of vehicles including cars, motorbikes, and trucks. Each vehicle can be either a fuel-based or an electric-based vehicle.

#### Inheritance and Polymorphism
Demonstrates the use of inheritance and polymorphism. All vehicles inherit from a base `Vehicle` class and are further specialized into `FuelVehicle` and `ElectricalVehicle` classes. Each specific type of vehicle (e.g., `FuelCar`, `ElectricalMotorbike`, `FuelTruck`) is a subclass of these.

#### Factory Design Pattern
The `Factory` class creates instances of different types of vehicles. This allows for a flexible design that can be easily extended to support new types of vehicles in the future.

#### Exception Handling
Includes custom exception classes to handle various error conditions, demonstrating good error handling practices.

#### User Interaction
Interacts with the user through a console-based interface. It includes a main menu that allows the user to perform various operations such as inserting a new vehicle into the garage, displaying a list of vehicles, updating a vehicle's state, inflating a vehicle's wheels, refueling a vehicle, and charging a vehicle's battery.

### Usage

To use the system, run the `ConsoleUI` class. This will display the main menu and prompt the user to choose an option. The user can then interact with the system by entering their choices and information into the console.

### Future Improvements

#### Extend Vehicle Types
The system can be easily extended to support new types of vehicles by adding new subclasses of `Vehicle` and updating the `Factory` class.

#### Improve User Interface
The user interface could be improved by adding more detailed prompts and error messages, and by implementing a graphical user interface.

#### Add More Features
Additional features could be added such as the ability to schedule maintenance appointments, track the cost of repairs, or manage a waiting list for the garage.

### Conclusion

This project demonstrates a solid understanding of object-oriented design and programming. It shows the ability to design a system with a clear structure and to write clean, maintainable code. It also shows the ability to think critically about design decisions and to choose the best design based on the specific requirements of a project.

