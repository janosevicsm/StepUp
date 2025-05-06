# StepUp Web Application

## Description

This is a simple application for tracking workouts. It allows users to log their training sessions and monitor their progress over time.

## Features

### 1. Login and Registration

- Users can register and log in using a basic authentication mechanism.

### 2. Workout Logging

Users can create records of their workout sessions with the following details:

- **Type of exercise** (cardio, weight-lifting, flexibility)
- **Duration** of the workout
- **Calories burned**
- **Workout intensity** (on a scale from 1 to 10)
- **Fatigue level** (on a scale from 1 to 10)
- **Additional notes**
- **Date and time** of the training session

### 3. Progress Tracking

Users can select a month and view weekly progress metrics, including:

- Total workout duration for each week
- Number of workout sessions
- Average intensity rating per week
- Average fatigue level per week

These metrics help users analyze their training habits and consistency.

## Demo
[![StepUp Demo](https://img.youtube.com/vi/3LrgFWpneIY/maxresdefault.jpg)](https://youtu.be/3LrgFWpneIY?si=-sZN3g3ANf9C_0M9) 

## Tech Stack
### Angular <img align="left" alt="Angular" width="26px" src="https://angular.io/assets/images/logos/angular/angular.svg" style="padding-right:10px;" />
### .NET Core <img align="left" alt="dotNet" width="26px" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/dotnetcore/dotnetcore-original.svg" style="padding-right:10px;" />
### Microsoft SQL Server <img align="left" alt="dotNet" width="26px" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/microsoftsqlserver/microsoftsqlserver-original-wordmark.svg" style="padding-right:10px;" />
### Docker <img align="left" alt="dotNet" width="26px" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/docker/docker-original-wordmark.svg" style="padding-right:10px;" />
<br/>

## Setup

Follow the steps below to run the application locally. The project consists of a `.NET 9.0` backend and an `Angular 18` frontend, along with a SQL Server database running in Docker.

### Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download)
- [Node.js (LTS version)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [Docker](https://www.docker.com/)

### 1. Clone the repository

```bash
git clone https://github.com/janosevicsm/StepUp.git
cd StepUp
```

### 2. Start SQL Server using Docker
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Your_password123" \
   -p 1433:1433 --name sql_server \
   -d mcr.microsoft.com/mssql/server:2022-latest
```
### 3. Run the Backend
```bash
cd Backend
dotnet restore
dotnet ef database update
dotnet run
```

### 4. Run the Frontend
```bash
cd ../Frontend
npm install
ng serve
```

### 5. Access the app
Open your browser and navigate to: http://localhost:4200

## Author
### [Marko Janošević](https://github.com/janosevicsm) 
