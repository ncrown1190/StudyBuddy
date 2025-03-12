# Study Buddy App

## Overview
This project is a **Flashcard App** built using **Angular and .NET Core**. It allows users to browse, favorite, and remove questions from their personalized list. The app features a dynamic UI with interactive elements, such as a flip-card design and a favorite (star) toggle system.

## Technologies Used
### Frontend:
- **Angular** (Component-based architecture, TypeScript)
- **RxJS** (Observables & Subscription handling)
- **HTML/CSS** (Grid-based layout, responsive design, animations)

### Backend:
- **.NET Core Web API** (RESTful API development)
- **Entity Framework Core** (Database interactions, querying, and CRUD operations)
- **SQL Server** (Data persistence for questions & favorites)

## Features & Skills Demonstrated
### **1️⃣ Dynamic Data Fetching & State Management**
- Utilizes **Angular services (`ApiService`)** to fetch and manipulate data.
- Uses **RxJS Observables (`subscribe()`)** to handle asynchronous API requests.
- Implements a **favorites system**, allowing users to toggle favorite questions with a star icon.

### **2️⃣ Component-Based UI & Interactive Features**
- **`FavoritesListComponent` & `QuestionsComponent`** dynamically render lists using `*ngFor`.
- **Flip-card animation**: Questions flip on hover to reveal answers.
- **Conditional UI rendering**: Star icons visually change based on favorite status.

### **3️⃣ API Integration & CRUD Operations**
- `GET /Qas` → Fetches the list of questions from the backend.
- `GET /UserFavorites` → Retrieves the user’s favorited questions.
- `POST /UserFavorites` → Adds a question to the user's favorites.
- `DELETE /UserFavorites/{id}` → Removes a question from the favorites list.

### **4️⃣ TypeScript Best Practices & Interface Usage**
- Defines clear **TypeScript interfaces (`FavoriteQAInterface`, `QuestionAnswerInterface`)**.
- Implements **strict typing** to improve maintainability and prevent runtime errors.
- Uses **Angular’s dependency injection** to manage services efficiently.

## How to Run the Project
### **Backend (.NET Core API)**
1. Clone the repository.
2. Navigate to the API project directory.
3. Run `dotnet restore` to install dependencies.
4. Use `dotnet run` to start the server.

### **Frontend (Angular App)**
1. Navigate to the Angular project directory.
2. Run `npm install` to install dependencies.
3. Use `ng serve` to start the development server.
4. Open `http://localhost:4200/` in your browser.

## Future Enhancements
- Implement authentication for user-specific favorites.
- Improve UI interactions (e.g., click-to-flip instead of hover-based).
- Optimize API calls with caching strategies.

---
This project showcases **full-stack development skills**, including API integration, Angular component interaction, and interactive UI/UX design. 🚀

