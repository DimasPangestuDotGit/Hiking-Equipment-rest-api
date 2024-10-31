# Hiking Equipment API

A simple RESTful API built with ASP.NET Core that provides information about various hiking equipment.

## Features
- **CRUD Operations**: Create, Read, Update, and Delete hiking equipment entries.
- **Microservices Architecture**: Implemented by separating the API and service, where the API is responsible for handling client requests and forwarding them to the appropriate service. The service then manages the business logic and interacts with the database to return the required responses, facilitating the management and development of various aspects of hiking equipment management.
- **Relational Database**: Uses Azure SQL Database for storing data related to hiking equipment.
