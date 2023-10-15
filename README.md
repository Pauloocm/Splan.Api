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
