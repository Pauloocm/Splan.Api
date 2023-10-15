# Splan API

A web api for the course completion work, for the Systems Development technical course

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

[Explain what your project is and what it does]

## Prerequisites

[Detail any prerequisites or system requirements]

## Installation

[Provide step-by-step installation instructions]

```bash
git clone https://github.com/yourusername/your-repo.git
cd your-repo
dotnet restore
dotnet build

## API Endpoints

## Add Employee

- **Endpoint:** `POST /Splan/Add`
- **Description:** Add a new employee.
- **Request Body:** JSON representing an `AddEmployeeCommand`.
- **Response:** Returns the ID of the newly added employee.

## Update Employee

- **Endpoint:** `PUT /Splan/Update`
- **Description:** Update an existing employee.
- **Request Body:** JSON representing an `UpdateEmployeeCommand`.
- **Response:** Returns a success status.

## Get All Employees

- **Endpoint:** `GET /Splan/Get`
- **Description:** Retrieve a list of all employees.
- **Response:** Returns a list of employees in JSON format.

## Get Employee by ID

- **Endpoint:** `GET /Splan/GetEmployeeById`
- **Description:** Retrieve an employee by their ID.
- **Query Parameter:** `employeeId` (Guid)
- **Response:** Returns the employee details in JSON format.

## Delete Employee

- **Endpoint:** `DELETE /Splan/Delete`
- **Description:** Delete an employee.
- **Request Body:** JSON representing a `DeleteEmployeeCommand`.
- **Response:** Returns a success status.

---

Feel free to use these endpoints to interact with the Splan API for employee management. Make sure you have the necessary request bodies and parameters in the correct format when making API requests.

For more details on how to use these endpoints, please refer to the respective controller and command classes in the source code.


