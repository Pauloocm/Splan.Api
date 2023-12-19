# SPLAN API

Just a simple project developed for the conclusion work of the Systems Development course at SENAI - Cimatec

[![.NET CI](https://github.com/Pauloocm/Splan.Api/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/Pauloocm/Splan.Api/actions/workflows/dotnet.yml)

## Table of Contents

- [Getting Started](#getting-started)
- [Contributors](#contributors)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [API Endpoints](#api-endpoints)


## Getting Started

Created with the aim of digitizing processes that were previously done manually, the expectation is to generate greater reliability, time savings and practicality for our client.

## Contributors

- [Anthony Sacramento](https://github.com/AnthonySacramento)
- [André Luis](https://github.com/AndreLuisT7)
- [Joao Manuel](https://github.com/JoaoSilvaDeveloper)
- [Filipe Silva](https://github.com/FilipeSS01)

## Prerequisites

.NET 8

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
### Get Dashboard

- **Endpoint:** `GET /Dashboard/{projectId}`
- **Description:** Endpoint allows users to retrieve dashboard information for a specified project.
- **Response:** 200 OK - Dashboard information retrieved successfully / 400 Bad Request - Invalid project ID / 404 Not Found - Project not found or no dashboard information available.
#### Example

  ```http
  GET /Dashboard/{projectId}
  Content-Type: application/json

{}
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
### Add Phase

- **Endpoint:** `POST /Phases/{projectId}`
- **Description:** Endpoint allows users to add a phase to a specified project.
- **Request Body:** JSON representing an `AddPhaseCommand`.
- **Response:** 200 OK - Phase added to the project successfully, returns the phase ID / 400 Bad Request - Invalid or missing phase details or project ID
#### Example

  ```http
  POST /Phases/{projectId}
  Content-Type: application/json

{
  "stage": "PhaseStage",
  "description": "PhaseDescription",
  "startDate": "2023-01-01",
  "endDate": "2023-12-31"
}
```
### Update Phase

- **Endpoint:** `PUT /Phases/{projectId}`
- **Description:** Endpoint allows users to update phase details within a specified project.
- **Request Body:** JSON representing an `UpdatePhaseCommand`.
- **Response:** 200 OK - Phase details updated successfully / 400 Bad Request - Invalid or missing phase details or project ID
#### Example

  ```http
  PUT /Phases/{projectId}
  Content-Type: application/json

{
  "PhaseId": "1",
  "stage": "PhaseStage",
  "description": "PhaseDescription",
  "startDate": "2023-01-01",
  "endDate": "2023-12-31"
}
```
### Update Phase

- **Endpoint:** `GET /ListPhases/{projectId}`
- **Description:** Endpoint allows users to retrieve a list of phases within a specified project.
- **Response:** 200 OK - List of phases retrieved successfully / 400 Bad Request - Invalid project ID / 404 - Not Found - Project not found.
#### Example

  ```http
  GET /ListPhases/{projectId}
  Content-Type: application/json

{}
```
### Delete Phase

- **Endpoint:** `DELETE /Phases/{projectId}`
- **Description:** Endpoint allows users to remove a phase from a specified project.
- **Request Body:** JSON representing an `DeletePhaseCommand`.
- **Response:** 200 OK - Phase deleted successfully / 400 Bad Request - Invalid or missing phase details or project ID
#### Example

  ```http
  DELETE /Phases/{projectId}
  Content-Type: application/json

{
  "PhaseId": "1",
}
```
### Add FinanceItem

- **Endpoint:** `POST /Finances/{projectId}`
- **Description:** Endpoint allows users to add a finance item to a specified project.
- **Request Body:** JSON representing an `AddFinanceItemCommand`.
- **Response:** 200 OK - Finance item added to the project successfully / 400 Bad Request - Invalid or missing phase details or project ID
#### Example

  ```http
  POST /Finances/{projectId}
  Content-Type: application/json

{
  "name": "ItemName",
  "date": "2023-01-01",
  "value": 100.0,
  "supplier": "SupplierName"
}
```
### Get FinanceItens

- **Endpoint:** `GET /Finances/{projectId}`
- **Description:** Endpoint allows users to retrieve a list of finance items within a specified project.
- **Response:** 200 OK - List of finance items retrieved successfully / 400 Bad Request - Invalid project ID / 404 Not Found - Project not found.
#### Example

  ```http
  GET /Finances/{projectId}
  Content-Type: application/json

{}
```
### Update FinanceItem

- **Endpoint:** `PUT /Finances/{projectId}`
- **Description:** Endpoint allows users to add a finance item to a specified project.
- **Request Body:** JSON representing an `UpdateFinanceItemCommand`.
- **Response:** 200 OK - Finance item details updated successfully / 400 Bad Request - Invalid or missing finance item details or project ID
#### Example

  ```http
  PUT /Finances/{projectId}
  Content-Type: application/json

{
  "financeItemId": "ItemID",
  "name": "UpdatedItemName",
  "date": "2023-01-01",
  "value": 150.0,
  "supplier": "UpdatedSupplierName"
}
```
### Update FinanceItem

- **Endpoint:** `DELETE /Finances/{projectId}`
- **Description:** Endpoint allows users to remove a finance item from a specified project.
- **Request Body:** JSON representing an `DeleteFinanceItemCommand`.
- **Response:** 200 OK - Finance item deleted successfully / 400 Bad Request - Invalid or missing finance item details or project ID
#### Example

  ```http
  DELETE /Finances/{projectId}
  Content-Type: application/json

{
  "financeItemId": "ItemID"
}
```
### Upload PDF

- **Endpoint:** `POST /UploadPdf`
- **Description:** Endpoint allows users to upload a PDF file.
- **Request Form:** PDF file
- **Request Body:** JSON representing an `AddPdfViewModel`.
- **Response:** 200 OK - File uploaded successfully, returns the PDF ID / 400 Bad Request - No file uploaded, invalid file format, or missing required 
#### Example

  ```http
  POST /UploadPdf
  Content-Type: application/json

{
  "name": "pdfName",
  "financeItemId": "1"
}
```
### Download PDF

- **Endpoint:** `GET /DownloadPdf`
- **Description:** Endpoint allows users to upload a PDF file.
- **Request Body:** JSON representing an `financeItemId`.
- **Response:** 200 OK - File downloaded successfully, returns the PDF file / 400 Bad Request - Invalid or missing ItemId / 404 Not Found - PDF file or associated item not found.
#### Example

  ```http
  GET /DownloadPdf
  Content-Type: application/json

{
  "financeItemId": "1"
}
```
### Add RhFinance

- **Endpoint:** `POST /Rhfinances/{projectId}`
- **Description:** Endpoint allows users to add finance information from an employee to a specified project.
- **Request Body:** JSON representing an `AddRhFinanceFromEmployee`.
- **Response:** 200 OK - File downloaded successfully, returns the PDF file / 400 Bad Request - Invalid or missing ItemId / 404 Not Found - PDF file or associated item not found.
#### Example

  ```http
  POST /Rhfinances/{projectId}
  Content-Type: application/json

{
  "employeeId": "1",
  "contractDateMonth": "2023-01-01",
  "valuePerHour": 25.0,
  "hoursWorkedMonth": 160
}
```
### Get RhFinances

- **Endpoint:** `GET /Rhfinances/{projectId}`
- **Description:** Endpoint allows users to list finance information related to employees in a specified project.
- **Response:** 200 OK -  Finance information related to employees listed successfully / 400 Bad Request - Invalid project ID / 404 Not Found - Project not found.
#### Example

  ```http
  GET /Rhfinances/{projectId}
  Content-Type: application/json

{}
```
### Update RhFinance

- **Endpoint:** `PUT /Rhfinances/{projectId}`
- **Description:** Endpoint allows users to update finance information related to employees in a specified project.
- **Request Body:** JSON representing an `UpdateRhFinanceCommand`.
- **Response:** 200 OK -  Finance information related to employees updated successfully / 400 Bad Request - Invalid project ID / 404 Not Found - Project not found.
#### Example

  ```http
  PUT /Rhfinances/{projectId}
  Content-Type: application/json

{
  "employeeId": "1",
  "contractDateMonth": "2023-01-01",
  "valuePerHour": 30.0,
  "hoursWorkedMonth": 180
}
```
