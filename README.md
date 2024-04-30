# Quick-E-APIs

Quick-E-APIs is a versatile API solution developed using ASP.NET, providing a streamlined approach for managing game data. This project allows users to perform various operations such as adding, updating, deleting, and retrieving game information through a RESTful API.

## Features

- **Game Management**: Easily add, update, delete, and retrieve game information.
- **RESTful API**: Follows REST architectural principles for predictable URL structures and HTTP methods.
- **ASP.NET Core**: Built using ASP.NET Core, a cross-platform, high-performance framework for building modern, cloud-based web applications.

## Technologies Used

- ASP.NET Core
- C#
- Entity Framework Core (EF Core)
- RESTful API design principles

## Getting Started

To get started with Quick-E-APIs, follow these steps:

1. **Clone the Repository**:
   git clone https://github.com/josephtossi/quick-e-apis.git

2. **Navigate to the Project Directory**:

3. **Run the Application**:
   Open the project in Visual Studio or your preferred IDE and run the application. Alternatively, you can run the following command in the terminal:
   dotnet run

4. **Explore the API**:
   Once the application is running, you can explore the API endpoints using tools like Postman or curl. The base URL for the API is `https://localhost:5001`

## API Endpoints

- `GET /api/games`: Get all games.
- `GET /api/games/{id}`: Get a specific game by ID.
- `POST /api/games`: Add a new game.
- `PUT /api/games/{id}`: Update an existing game.
- `DELETE /api/games/{id}`: Delete a game.

For detailed documentation on each endpoint, refer to the API documentation or Swagger UI (not available now).

## Contributing

Contributions are welcome! If you'd like to contribute to Quick-E-APIs, please follow these steps:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Create a new Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
