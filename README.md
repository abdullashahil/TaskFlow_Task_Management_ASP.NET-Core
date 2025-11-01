# 🧩 TaskFlow — Task Management Web API

TaskFlow is a simple Task Management Web API built using **ASP.NET Core**, **C#**, and **Entity Framework Core**.  
It allows users to create, read, update, and delete tasks efficiently while learning the core concepts of the .NET ecosystem.

---

## 🚀 Features
- Create, update, delete, and view tasks  
- Filter tasks by completion status  
- Built with clean architecture using Controllers, Models, DTOs, and DbContext  
- Integrated **Swagger UI** for API testing  
- Lightweight **SQLite** database for easy setup  

---

## 🛠️ Tech Stack
- **Backend:** ASP.NET Core 8 (C#)
- **Database:** SQLite (via EF Core)
- **ORM:** Entity Framework Core
- **API Docs:** Swagger
- **IDE:** Visual Studio Code / Visual Studio for Mac

---

## ⚙️ Installation & Setup

1. **Clone this repository**
   ```bash
   git clone https://github.com/abdullashahil/TaskFlow_Task_Management_ASP.NET-Core.git
   cd TaskFlow
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**
   - Open your browser and navigate to: `http://localhost:5198/swagger`

---

## 📋 API Endpoints

### Task Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/tasks` | Get all tasks |
| `GET` | `/api/tasks/{id}` | Get task by ID |
| `GET` | `/api/tasks?isCompleted=true` | Get all completed/pending tasks |
| `POST` | `/api/tasks` | Create a new task |
| `PUT` | `/api/tasks/{id}` | Update an existing task |
| `DELETE` | `/api/tasks/{id}` | Delete a task |

### Health Check

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/health` | Check API health status |

---

## 📦 Project Structure

```
TaskFlow/
├── Controllers/
│   └── TasksController.cs       # API endpoints for task operations
├── Data/
│   └── AppDbContext.cs          # EF Core database context
├── DTOs/
│   ├── TaskCreateDto.cs         # DTO for creating tasks
│   └── TaskUpdateDto.cs         # DTO for updating tasks
├── Migrations/                  # EF Core migrations
├── Models/
│   └── TaskItem.cs              # Task entity model
├── Properties/
│   └── launchSettings.json      # Launch configuration
├── Program.cs                   # Application entry point
├── appsettings.json             # Configuration settings
├── TaskFlow.csproj              # Project file
└── taskflow.db                  # SQLite database file
```

---

## 🧪 Example Usage

### Create a Task (POST)
```json
POST /api/tasks
Content-Type: application/json

{
  "title": "Complete ASP.NET Core tutorial",
  "description": "Learn about controllers, models, and EF Core",
  "dueDate": "2025-11-10T00:00:00"
}
```

### Update a Task (PUT)
```json
PUT /api/tasks/1
Content-Type: application/json

{
  "title": "Updated task title",
  "description": "Updated description",
  "isCompleted": true
}
```

### Get All Tasks (GET)
```bash
GET /api/tasks
```

**Response:**
```json
[
  {
    "id": 1,
    "title": "Complete ASP.NET Core tutorial",
    "description": "Learn about controllers, models, and EF Core",
    "dueDate": "2025-11-10T00:00:00",
    "isCompleted": false,
    "createdAt": "2025-11-01T18:51:49"
  }
]
```

---

## 🔧 Configuration

The database connection string is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=taskflow.db"
  }
}
```

---

## 🎓 Learning Objectives

This project helps beginners understand:
- **RESTful API design** principles
- **ASP.NET Core** minimal API and controllers
- **Entity Framework Core** for database operations
- **Data Transfer Objects (DTOs)** for clean API contracts
- **Dependency Injection** in .NET
- **SQLite** database integration
- **Swagger/OpenAPI** documentation

---

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

---

## 👨‍💻 Author

**Abdulla Shahil**
- GitHub: [@abdullashahil](https://github.com/abdullashahil)

---

## 🙏 Acknowledgments

- Built as a learning project for ASP.NET Core beginners

---

**Happy Coding! 🚀**
