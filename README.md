# Splan Web API Documentation

Welcome to the documentation for the Splan Web API. This API provides endpoints to manage employee information.

```markdown
## Endpoints

### Add Employee

- **Endpoint:** `POST /Splan/Add`
- **Description:** Add a new employee.
- **Request Body:** JSON representing an `AddEmployeeCommand`.
- **Response:** Returns the ID of the newly added employee.

### Update Employee

- **Endpoint:** `PUT /Splan/Update`
- **Description:** Update an existing employee.
- **Request Body:** JSON representing an `UpdateEmployeeCommand`.
- **Response:** Returns a success status.

### Get All Employees

- **Endpoint:** `GET /Splan/Get`
- **Description:** Retrieve a list of all employees.
- **Response:** Returns a list of employees in JSON format.

### Get Employee by ID

- **Endpoint:** `GET /Splan/GetEmployeeById`
- **Description:** Retrieve an employee by their ID.
- **Query Parameter:** `employeeId` (Guid)
- **Response:** Returns the employee details in JSON format.

### Delete Employee

- **Endpoint:** `DELETE /Splan/Delete`
- **Description:** Delete an employee.
- **Request Body:** JSON representing a `DeleteEmployeeCommand`.
- **Response:** Returns a success status.

## Getting Started

To interact with these endpoints, you can use your preferred API client or tool. Ensure that you format your requests and responses according to the specified data structures.

## Examples

Here are some example requests to help you get started:

#### Adding a New Employee

```http
POST /Splan/Add
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com"
}

PUT /Splan/Update
Content-Type: applicationjson

{
  "employeeId": "12345",
  "firstName": "UpdatedJohn",
  "lastName": "UpdatedDoe"
}

For more details and advanced use cases, please refer to the respective controller and command classes in the source code.

## License

This project is licensed under the [Your License] - see the [LICENSE.md](LICENSE.md) file for details.

Feel free to explore and utilize the Splan API for your employee management needs.


