```csharp
public class MyClass
{
    public string MyProperty { get; set; }
}

```markdown
## Endpoints

### Add Employee

- **Endpoint:** `POST /Splan/Add`
- **Description:** Add a new employee.
- **Request Body:** JSON representing an `AddEmployeeCommand`.
- **Response:** Returns the ID of the newly added employee.
