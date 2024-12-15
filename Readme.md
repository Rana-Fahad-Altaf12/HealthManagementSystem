```
# Hospital Management System (HMS)

## Overview
This project is a Hospital Management System (HMS) built with a React Frontend and a .NET 6 Backend using microservices. It enables the management of user appointments and user data, providing a structured and scalable architecture for healthcare-related services.

---

## Frontend - React

### Folder Structure
- **actions**
  - `Appointments` => `appointmentActions`
  - `User` => `authActions`
- **components**
  - `Appointments`
  - `User`
  - `Navbar`
  - `Pagination`
- **context**
- **hooks**
- **pages**
- **reducers**
- **routes**
- **styles**
- **utils**

### Key Features
- User authentication with secure token handling.
- Appointment scheduling with paginated views.
- Modular structure for scalability and maintainability.

---

## Backend - .NET 6 Microservices

### Microservices
1. **AppointmentService**
   - **Data**: Database context and configurations.
   - **DTOs**: Data transfer objects for API communication.
   - **Mapping**: AutoMapper profiles for object mappings.
   - **Models**: Core domain models.
   - **Repositories**:
     - `IAppointmentRepository`
     - `AppointmentRepository`
   - **Services**:
     - `IAppointmentService`
     - `AppointmentService`

2. **UserService**
   - Follows the same structure as `AppointmentService`.

### Key Features
- Microservices-based architecture for modularity.
- Entity Framework Core for data access.
- Secure authentication and authorization.
- Swagger for API documentation.

---

## Setup Instructions

### Prerequisites
- **Frontend**: Node.js
- **Backend**: .NET 6 SDK, SQL Server
- **Others**: Docker (optional), Postman (for API testing)

### Steps to Run

#### Frontend
1. Navigate to the `frontend/` directory.
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm start
   ```

#### Backend
1. Navigate to each service directory (`AppointmentService`, `UserService`).
2. Update `appsettings.json` with the correct database connection strings.
3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
4. Start the microservices:
   ```bash
   dotnet run
   ```

---

## Contribution Guidelines
1. Fork the repository.
2. Create a new branch for your feature:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Describe your changes"
   ```
4. Push your branch and submit a pull request for review.

---

## License
This project is open-source and available under the MIT License
```