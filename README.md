Cashier MVC - .NET Core

A simple cashier system built using ASP.NET Core MVC with Entity Framework Core and PostgreSQL. This project simulates a basic transaction system where users can add items to a cart, store inventory, process purchases, and track transactions.

🚀 Features
	•	Storage Management: Add, view, and delete items from the inventory.
	•	Cart System: Add items to the cart and process purchases.
	•	Transaction Management: View past transactions and their details.
	•	ASP.NET Core MVC: Follows the Model-View-Controller pattern.
	•	Entity Framework Core: Handles database interactions.
	•	PostgreSQL: Database management system.
	•	Bootstrap UI: Responsive UI using Bootstrap.

📂 Project Structure

Cashier/
│-- Controllers/          # Handles application logic
│   ├── HomeController.cs
│-- Data/                # Database context and migrations
│-- Models/              # Data models
│   ├── Item.cs
│   ├── Purchase.cs
│   ├── StorageViewModel.cs
│   ├── TransactionViewModel.cs
│-- Views/               # Frontend pages (Razor views)
│   ├── Home/
│   ├── Storage/
│   ├── Transaction/
│-- wwwroot/             # Static files (CSS, JS, images)
│-- appsettings.json      # Configuration file (database connection)
│-- Program.cs           # Application entry point
│-- Cashier.csproj       # Project definition file
│-- .gitignore           # Files to ignore in version control

⚙️ Installation & Setup

1️⃣ Clone the repository

git clone https://github.com/omaar414/cashier-mvc-dotnetcore.git
cd cashier-mvc-dotnetcore

2️⃣ Configure the Database
	•	Make sure you have PostgreSQL installed.
	•	Set up environment variables for database credentials:

export DB_USERNAME="your_username"
export DB_PASSWORD="your_password"


"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=cashierdb;Username={DB_USERNAME};Password={DB_PASSWORD}"
}



3️⃣ Apply Migrations & Seed the Database

Run the following commands in the project root:

dotnet ef migrations add init
dotnet ef database update

4️⃣ Run the Application

dotnet run


### 📸 Screenshots

#### 📍 Home View
![Home View](https://github.com/user-attachments/assets/5ec68341-9469-4db9-b875-68d0a9a0e705)

#### 📍 Storage View
![Storage View](https://github.com/user-attachments/assets/68919dcc-38b4-468d-b81b-72f23a22272d)

#### 📍 Transaction View
![Transaction View](https://github.com/user-attachments/assets/fec3148e-a24c-4a6b-997b-9e74e0ee6337)


🛠 Technologies Used
	•	ASP.NET Core MVC (Backend Framework)
	•	Entity Framework Core (ORM)
	•	PostgreSQL (Database)
	•	Bootstrap 5 (Frontend UI)
	•	C# (Programming Language)

📜 License

This project is open-source under the MIT License.

📌 Future Improvements
	•	Add user authentication & role-based access control.
	•	Improve UI/UX with better styling.
	•	Implement AJAX for a smoother user experience.

