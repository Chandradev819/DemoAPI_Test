# Product API

This project is a .NET 8.0 Web API that interacts with a mock API to:
- Retrieve products with optional filtering and pagination.
- Add new products to the mock API.
- Delete products by ID.

## Project Structure
```
📂 DemoAPI
├── 📂 Controllers
│   └── ProductController.cs
├── 📂 Models
│   ├── Product.cs
│   └── ProductData.cs
├── 📂 Services
│   └── ProductService.cs
├── DemoAPI.csproj
└── Program.cs
```

## Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or later / VS Code
- Internet connection (to access the mock API)

## Setup Instructions
1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd DemoAPI
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Navigate to:
   ```
   https://localhost:5001/swagger
   ```
   to access the Swagger UI for testing the API.

## API Endpoints
| Method | Endpoint                 | Description                         |
|---------|--------------------------|-------------------------------------|
| GET     | `/api/products`         | Retrieve products with optional filter and pagination |
| POST    | `/api/products`         | Add a new product                   |
| DELETE  | `/api/products/{id}`    | Delete a product by ID              |

### Query Parameters (GET `/api/products`)
- `filter`: (Optional) Filters products by name (substring match).
- `page`: (Optional) Page number for pagination (default is 1).
- `pageSize`: (Optional) Number of items per page (default is 10).

### Example Usage:
**GET Request:**
```
GET /api/products?filter=Apple&page=1&pageSize=5
```

**POST Request:**
```json
POST /api/products
{
  "name": "Apple MacBook Air",
  "data": {
    "color": "Silver",
    "capacity": "512 GB",
    "price": 999.99
  }
}
```

**DELETE Request:**
```
DELETE /api/products/3
```

## Error Handling
- 500 Internal Server Error for unexpected issues.
- 400 Bad Request for validation errors.
- 404 Not Found when a product does not exist.

## License
This project is licensed under the MIT License.
