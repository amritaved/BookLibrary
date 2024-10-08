# Book Library API
This project is a simple Book Library API implemented in C# using .NET 6.

## Prerequisites
- .NET 6 SDK or later

## How to Run
1. Clone the repository.
2. Navigate to the project directory.
3. Run the following command to start the project:
   ```sh
   dotnet run --project LibraryManagement
   ```
4. The API will be available at 'https://localhost:7078/swagger'

## API Endpoints
- `GET /api/books` - Retrieve all books.
- `GET /api/books/{id}` - Retrieve a specific book by ID.
- `POST /api/books` - Add a new book.
- `PUT /api/books/{id}` - Update an existing book.
- `DELETE /api/books/{id}` - Delete a book by ID.

## Testing
This project includes basic endpoints to demonstrate CRUD operations. You can use tools like Swagger to test the endpoints.

## Unit Tests
Unit tests are implemented using the MSTest framework.
