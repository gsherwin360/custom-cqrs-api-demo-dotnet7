# Custom CQRS API Demo (.NET 7 with Clean Architecture)
This project is a hands-on demonstration of building a custom API using the Command Query Responsibility Segregation (CQRS) architectural pattern, combined with the principles of Clean Architecture, all within the context of .NET 7. The primary goal is to create an API that embraces CQRS principles and adheres to a clean and modular project structure, all without relying on third-party CQRS frameworks.

Features:

- CQRS Principles: Implement clear separation between command and query responsibilities using .NET 7, along with custom command and query buses.
- API Endpoints: Create API endpoints using .NET 7 that illustrate CQRS operations for creating, updating, and querying data.
- Clean Architecture: Structure the solution according to Clean Architecture principles in .NET 7, emphasizing layer separation and modularity.

## Docker Support

This project includes Docker support for containerization, which allows for easier deployment and management of the application.

### Building and Running with Docker

To build and run the application using Docker, follow these steps:

1. Install Docker on your machine if you haven't already: [Docker Installation Guide](https://docs.docker.com/get-docker/).
2. Navigate to the project directory in your terminal.
3. Build the Docker image:
   ```bash
   docker build . -t customers-api:0.1
4. Run the application in a Docker container:
    ```bash
   docker run -p 5000:80 customers-api:0.1
5. Access the API via [Swagger](http://localhost:5000/swagger/index.html)

For more detailed instructions and Docker usage examples, refer to the project's Dockerfile and .dockerignore file.