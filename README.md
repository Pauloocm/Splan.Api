```csharp
public class MyClass
{
    public string MyProperty { get; set; }
}

```csharp
## Endpoints

### Add Employee

- **Endpoint:** `POST /Splan/Add`
- **Description:** Add a new employee.
- **Request Body:** JSON representing an `AddEmployeeCommand`.
- **Response:** Returns the ID of the newly added employee.

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

