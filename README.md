This project implements a wedding planner application using microservices architecture with four services:

   Event Service - Manages wedding events
   Guest Service - Manages guests and RSVPs
   Task Service - Manages wedding tasks
   API Gateway - Single entry point that routes requests and aggregates data

💻 Technologies

ASP.NET Core 8.0
Entity Framework Core (In-Memory Database)
Swagger/OpenAPI
C# 12

🚀 How to Run

Clone the repository
Open 4 terminal windows and run each service:
   cd EventService && dotnet run    # Port 5001
   cd GuestService && dotnet run    # Port 5002
   cd TaskService && dotnet run     # Port 5003
   cd ApiGateway && dotnet run      # Port 5000

Access Swagger UI: http://localhost:5000/swagger

🧪 Testing

Swagger UI: http://localhost:5000/swagger
HTML Test Page: Open wedding-test.html in browser
Summary Endpoint: GET /gateway/summary/{eventId} - Returns combined data from all services
