# Satnusa Task Manager

A simple yet robust Task Management System built with .NET 8 and C#, following Clean Architecture principles.

## Overview

This project demonstrates how to build a scalable and maintainable application using modern software engineering practices. It strictly follows the principles of Clean Architecture, separating concerns into distinct layers:

-   **`Domain`**: Contains the core business logic, entities, and repository interfaces. It has no dependencies on other layers.
-   **`Application`**: Contains application-specific logic, services, and use cases. It orchestrates the domain layer and depends only on `Domain`.
-   **`Infrastructure`**: Contains implementations for external concerns like databases, logging, and other services. It depends on the `Application` and `Domain` layers.
-   **`Application.Tests`**: Contains a suite of unit and integration tests to ensure the system's correctness and stability.

## Prerequisites

To build and run this project, you will need the following installed on your machine:

-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/wandewana/SatnusaTaskManager
    cd SatnusaTaskManager
    ```

2.  **Restore dependencies:**

    Navigate to the root directory and run the following command to restore all the necessary packages for the solution:
    ```bash
    dotnet restore
    ```

## How to Run Tests

To run the full suite of unit and integration tests, execute the following command from the root directory:

```bash
dotnet test
```

This command will discover and run all tests in the `Application.Tests` project, verifying that the business logic, repository implementations, and dependency injection are all functioning correctly.

## Key Libraries & Frameworks

This project utilizes several key libraries and frameworks:

-   **.NET 8**: The underlying platform for building the application.
-   **xUnit**: A modern, flexible, and community-focused unit testing tool for .NET.
-   **Moq**: The most popular and friendly mocking library for .NET, used for isolating dependencies in unit tests.
-   **Microsoft.Extensions.DependencyInjection**: A lightweight and extensible dependency injection container used to manage the application's services.

## Project Structure

The solution is organized as follows:

```
.
├── Application/         # Application layer (services, use cases)
├── Application.Tests/   # Unit and integration tests
├── Domain/              # Domain layer (entities, interfaces)
├── Infrastructure/      # Infrastructure layer (repositories, logging)
└── SatnusaTaskManager.sln
```

This structure enforces a clean separation of concerns, making the codebase easy to navigate, maintain, and extend.
