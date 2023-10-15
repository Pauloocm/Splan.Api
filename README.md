## Examples

Here are example requests to help you get started:

### Endpoints

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

  PUT /Employees/Update
  Content-Type: application/json

  {
    "EmployeeId": "12345"
    "Name": "John Doe",
    "Position": "Manager",
    "EducationalBackground": "Bachelor's in Computer Science",
    "ContractingRegime": 1,
    "Coordinator": false,
    "RhClassification": "A"
  }


