# Condo Space Reservation API

This repository contains the backend API for the Condo Space Reservation application, built using .NET Web API. The API is designed to handle user authentication, data storage, and retrieval, and it connects to a MongoDB database.

## Main Features

- **User Authentication**: The API includes endpoints for user registration and authentication using email and password.
- **Data Storage**: The API is connected to a MongoDB database for storing reservation data and user information.
- **Docker Support**: The API uses Docker to set up the MongoDB database with a persistent volume.

## Installation

To get started with the project, follow these steps:

1. **Clone the Repository**:
```bash
   git clone https://github.com/your-username/condo-space-reservation-api.git
   cd condo-space-reservation-api
```

2. Install Dependencies:
```bash
dotnet restore
```

3. Set Up MongoDB with Docker:
Use the provided docker-compose.yml file to set up a MongoDB container with a persistent volume.
```bash
docker-compose up -d
```

4. Configure the API:
Update the appsettings.json file with the appropriate MongoDB connection string.
```bash
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017/condo-space-reservation"
  }
}
```

5. Run the API:
```bash
dotnet run
```