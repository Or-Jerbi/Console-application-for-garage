# Garage Management Console Application

A C# console-based application designed to manage a garage's vehicles, including electric and fuel-based vehicles, maintenance status, and more. Built as part of a software engineering course exercise or personal learning project.

## Overview

This console application simulates a garage management system where users can:
- Insert new vehicles
- Update vehicle statuses
- Inflate tires
- Refuel or recharge vehicles
- Display vehicle information

The system is object-oriented and designed to demonstrate core OOP concepts like inheritance, interfaces, and polymorphism in C#.

## Features

- Supports multiple vehicle types (Cars, Motorcycles, Trucks)
- Handles both fuel-based and electric engines
- Enforces validation for license numbers, energy levels, etc.
- Displays detailed information for each vehicle
- Manages vehicle statuses (InRepair, Fixed, Paid)

## Technologies

- **Language**: C#
- **Platform**: .NET Framework
- **Type**: Console Application
- **Paradigm**: Object-Oriented Programming (OOP)

## Usage

The console will prompt you with a menu to:

- Add a vehicle
- View list of vehicles (optionally filtered by status)
- Change a vehicle's status
- Inflate tires to max pressure
- Refuel or recharge vehicles
- View full details of a vehicle by license number

All user inputs are validated. Invalid inputs will trigger prompts to retry.


## How To Run

1. Clone the repository:
   ```bash
   git clone https://github.com/Or-Jerbi/Console-application-for-garage.git
   
2. Open Ex03.GarageLogic.sln in Visual Studio (or any other C# IDE that supports .NET Framework projects).
3. Set Ex03.ConsoleUI as the startup project.
4. Build and run the solution.

## Project Structure
   ```bash
   Console-application-for-garage/
   |
   ├── Ex03.ConsoleUI/        # Console user interface
   ├── Ex03.GarageLogic/      # Core business logic and domain models
   ├── Ex03.GarageLogic.sln   # Solution file
   └── README.md              # Project documentation



