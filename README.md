# SPLAN API

Just a simple project developed for the conclusion work of the Systems Development course at SENAI - Cimatec

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)

## Getting Started

[Explain what your project is and what it does]

## Prerequisites

[Detail any prerequisites or system requirements]

## Installation

```shell
   git clone https://github.com/pauloocm/splan.api.git
```
This documentation provides details about the endpoints available in the Splan API.

## API Endpoints

### Add Employee

- **Endpoint:** `POST /Splan/Add`
- **Description:** Add a new employee.
- **Request Body:** JSON representing an `AddEmployeeCommand`.
- **Response:** Returns the ID of the newly added employee.
#### Example

  ```http
  POST /Employees/Add
  Content-Type: application/json

  {
    "Name": "John Doe",
    "Position": "Manager",
    "EducationalBackground": "Bachelor's in Computer Science",
    "ContractingRegime": 1,
    "Coordinator": false,
    "RhClassification": "A"
  }
```
### Update Employee

- **Endpoint:** `PUT /Splan/Update`
- **Description:** Update an existing employee.
- **Request Body:** JSON representing an `UpdateEmployeeCommand`.
- **Response:** Returns a success status.
#### Example

  ```http
  POST /Employees/Add
  Content-Type: application/json

  {
    "EmployeeId": "12345",
    "Name": "Anthony",
    "Position": "Trainee",
    "EducationalBackground": "Bachelor's in Computer Science",
    "ContractingRegime": 1,
    "Coordinator": false,
    "RhClassification": "A"
  }
```

### Get Employee by ID

- **Endpoint:** `GET /Splan/GetEmployeeById`
- **Description:** Retrieve an employee by their ID.
- **Query Parameter:** `employeeId` (Guid)
- **Response:** Returns the employee details in JSON format.
#### Example

  ```http
  GET /Employees/GetById
  Content-Type: application/json

  {
    "EmployeeId": "12345"
  }
```

### Get All Employees

- **Endpoint:** `GET /Splan/Get`
- **Description:** Retrieve a list of all employees.
- **Response:** Returns a list of employees in JSON format.
#### Example

  ```http
  GET /Employees/GetAll
  Content-Type: application/json
  ```

### Delete Employee

- **Endpoint:** `DELETE /Splan/Delete`
- **Description:** Delete an employee.
- **Request Body:** JSON representing a `DeleteEmployeeCommand`.
- **Response:** Returns a success status.

#### Example

  ```http
  POST /Employees/Delete
  Content-Type: application/json

  {
    "EmployeeId": "12345"
  }
```

