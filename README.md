# SPLAN API

Just a simple project developed for the conclusion work of the Systems Development course at SENAI - Cimatec

[![.NET CI](https://github.com/Pauloocm/Splan.Api/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/Pauloocm/Splan.Api/actions/workflows/dotnet.yml)

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)

## Getting Started

[Explain what your project is and what it does]

## Prerequisites

[Detail any prerequisites or system requirements]

## Installation

```shell
   git clone https://github.com/Pauloocm/Splan.Api.git
```

## API Endpoints
This documentation provides details about the endpoints available in the Splan API.
### Register

- **Endpoint:** `POST /Authentication/Register`
- **Description:** Endpoint allows users to register with a valid email and password.
- **Request Body:** JSON representing an `AdminLoginCommand`.
- **Response:** 200 OK - Registration successful. / 400 Bad Request - Invalid email or password.
#### Example

  ```http
  POST /Authentication/Register
  Content-Type: application/json

  {
    "email": "jessePinkman@gmail.com",
    "password": "Pinkman123"
  }
```
### Login

- **Endpoint:** `POST /Authentication`
- **Description:** Endpoint allows users to log in with a valid email and password..
- **Request Body:** JSON representing an `AdminLoginCommand`.
- **Response:** 200 OK - Login successful / 400 Bad Request - Invalid email or password.
#### Example

  ```http
  POST /Authentication
  Content-Type: application/json

  {
    "email": "jessePinkman@gmail.com",
    "password": "Pinkman123"
  }
```
### Add Project

- **Endpoint:** `POST /Add`
- **Description:** Endpoint allows users to add a project using a provided command.
- **Request Body:** JSON representing an `AddProjectCommand`.
- **Response:** 200 OK - Project added successfully, returns the project ID / 400 Bad Request - Invalid or missing project details
#### Example

  ```http
  POST /Add
  Content-Type: application/json

  {
    "name": "ProjectName",
    "company": "CompanyName",
    "startDate": "2023-01-01",
    "expirationDate": "2023-12-31",
    "status": true
  }
```
### Update Project

- **Endpoint:** `PUT /Update`
- **Description:** Endpoint allows users to update a project using a provided command.
- **Request Body:** JSON representing an `UpdateProjectCommand`.
- **Response:** 200 OK - Project updated successfully / 400 Bad Request - Invalid or missing project details
#### Example

  ```http
  PUT /Update
  Content-Type: application/json

  {
    "id": 1,
    "name": "UpdatedProjectName",
    "company": "UpdatedCompanyName",
    "startDate": "2023-01-01",
    "expirationDate": "2023-12-31",
    "status": true
  }
```
### List Projects

- **Endpoint:** `GET`
- **Description:** Endpoint allows users to retrieve a list of projects.
- **Response:** 200 OK - List of projects retrieved successfully / 204 No Content - No projects found
#### Delete Project

- **Endpoint:** `DELETE`
- **Description:** Endpoint allows users to delete a project using a provided command.
- **Request Body:** JSON representing an `DeleteProjectCommand`.
- **Response:** 200 OK - Project deleted successfully / 400 Bad Request - Invalid or missing project ID
#### Example

  ```http
  DELETE
  Content-Type: application/json

  {
    "id": 1
  }
```
### Add Employee

- **Endpoint:** `POST /Employees/{projectId}`
- **Description:** Endpoint allows users to add an employee to a project using a provided command and project ID.
- **Request Body:** JSON representing an `AddEmployeeCommand`.
- **Response:** 200 OK - Employee added to the project successfully, returns the employee key / 400 Bad Request - Invalid or missing employee details or project ID
#### Example

  ```http
  POST /Employees/{projectId}
  Content-Type: application/json

  {
    "name": "EmployeeName",
    "function": "Developer",
    "educationDegree": "Bachelor",
    "hiringRegimeId": 1,
    "isCoordinator": false,
    "classification": "Junior"
}
```
### Update Employee

- **Endpoint:** `PUT /Employees`
- **Description:** Endpoint allows users to update employee details in a project using a provided command and project ID.
- **Request Body:** JSON representing an `UpdateEmployeeCommand`.
- **Response:** 200 OK - Employee details updated successfully / 400 Bad Request - Invalid or missing employee details or project ID
#### Example

  ```http
  PUT /Employees
  Content-Type: application/json

  {
  "employeeId": "EmployeeId",
  "name": "UpdatedEmployeeName",
  "function": "UpdatedDeveloper",
  "educationDegree": "Master",
  "hiringRegimeId": 2,
  "isCoordinator": true,
  "classification": "Senior"
}
```

### Get Employee by ID

- **Endpoint:** `GET /GetById/{projectId}/{employeeId}`
- **Description:** Endpoint allows users to return a employee by project Id and their ID.
- **Query Parameter:** `employeeId` (Guid)
- **Response:** 200 OK - Return employee successfully / 400 Bad Request - Invalid emplyoee ID or project ID
#### Example

  ```http
  GET /GetById/{projectId}/{employeeId}
  Content-Type: application/json

  {
    "employeeId": "1"
  }
```

### Get All Employees

- **Endpoint:** `GET /Employees/{projectId}`
- **Description:** Endpoint allows users to retrieve a list of employees within a specified project.
- **Response:** 200 OK - List of employees retrieved successfully / 400 Bad Request - Invalid project ID / 404 Not Found - Project not found
#### Example

  ```http
  GET /Employees/{projectID}
  Content-Type: application/json
  ```

### Delete Employee

- **Endpoint:** `DELETE /Employees/{projectId}`
- **Description:** Endpoint allows users to remove an employee from a specified project.
- **Request Body:** JSON representing a `DeleteEmployeeCommand`.
- **Response:** 200 OK - Employee deleted successfully / 400 Bad Request - Invalid employee ID or project ID

#### Example

  ```http
  DELETE /Employees/{projectId}
  Content-Type: application/json

  {
    "EmployeeId": "1"
  }
```

