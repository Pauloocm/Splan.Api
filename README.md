## Examples

Here are example requests to help you get started:

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
Content-Type: application/json

{
  "employeeId": "12345",
  "firstName": "UpdatedJohn",
  "lastName": "UpdatedDoe"
}


