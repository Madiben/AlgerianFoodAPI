# 🇩🇿 Algerian Food API 🍽️

> **An open-source REST API providing traditional Algerian dishes, ingredients, and recipes!**

## 🚀 Live API Endpoint
🔗 [Algerian Food API on Railway](https://algerianfoodapi-production.up.railway.app/api/dishes) 
*(Replace with actual Railway deployment URL)*

---

## 📖 About the Project
The **Algerian Food API** allows users to fetch **traditional Algerian dishes**, their **ingredients**, and **recipes**.  
This API is designed for **Android, web apps, and food-related projects**.  

🔹 **Features:**
- 📌 **Get all Algerian dishes**
- 🎲 **Fetch a random dish**
- 🔍 **Search by dish name or origin**
- ➕ **Add new dishes (POST)**
- ✏️ **Update existing dishes (PUT)**
- ❌ **Delete dishes (DELETE)**

---

## 📌 API Endpoints

### 📝 **Get All Dishes**
```http
GET /api/dishes
```
**Response Example:**
```json
[
  {
    "id": "550e8400-e29b-41d4-a716-446655440000",
    "name": "Couscous",
    "origin": "Algeria (Nationwide)",
    "recipe": "Steam semolina, cook vegetables and meat separately, then mix with sauce and serve.",
    "ingredients": [
      {
        "name": "Semolina",
        "quantity": 250,
        "unit": "g"
      }
    ],
    "imageUrl": "https://upload.wikimedia.org/wikipedia/commons/3/3d/Couscous_01.jpg"
  }
]
```

---

### 🎲 **Get a Random Dish**
```http
GET /api/dishes/random
```
📌 Returns **one random dish** from the database.

---

### 🔍 **Get Dish by ID**
```http
GET /api/dishes/{id}
```
📌 **Replace `{id}`** with the actual dish ID.

---

### ➕ **Add a New Dish**
```http
POST /api/dishes
Content-Type: application/json
```
**Request Body Example:**
```json
{
  "name": "Chorba Frik",
  "origin": "Algeria (North & East)",
  "recipe": "Simmer meat, vegetables, and frik in broth for 45 minutes.",
  "ingredients": [
    {
      "name": "Meat",
      "quantity": 350,
      "unit": "g"
    },
    {
      "name": "Frik (Cracked Wheat)",
      "quantity": 120,
      "unit": "g"
    }
  ],
  "imageUrl": "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Chorba_Frik.jpg/800px-Chorba_Frik.jpg"
}
```

---

### ✏️ **Update a Dish**
```http
PUT /api/dishes/{id}
Content-Type: application/json
```
**Replace `{id}`** with the dish ID and send the updated dish object.

---

### ❌ **Delete a Dish**
```http
DELETE /api/dishes/{id}
```
📌 Deletes the dish with the given `{id}`.

---

## 📥 Installation & Setup

### **1️⃣ Clone the Repository**
```bash
git clone https://github.com/your-username/AlgerianFoodAPI.git
cd AlgerianFoodAPI
```

### **2️⃣ Install Dependencies**
```bash
dotnet restore
```

### **3️⃣ Apply Database Migrations**
```bash
dotnet ef database update
```

### **4️⃣ Run the API Locally**
```bash
dotnet run
```
📌 Now visit **`http://localhost:5196/swagger`** to test the API.

---

## 🌍 Deployment (Railway.app)
The API is hosted on **Railway** for free. To redeploy:
```bash
git push origin main
```
🚀 Railway will **automatically update the live API**.

---

## 🔧 Environment Variables
| **Variable** | **Value** |
|-------------|------------|
| `ASPNETCORE_ENVIRONMENT` | `Production` |
| `DATABASE_PROVIDER` | `sqlite` |

📌 **For local testing**, change `ASPNETCORE_ENVIRONMENT=Development`.

---

## 🏗️ Project Structure
```
/AlgerianFoodAPI
│── /Controllers
│   ├── DishesController.cs   # API Endpoints
│
│── /Models
│   ├── Dish.cs               # Dish Model
│   ├── Ingredient.cs         # Ingredients Model
│
│── /Data
│   ├── AlgerianFoodDbContext.cs  # Database Context
│
│── /Repositories
│   ├── IDishRepository.cs    # Interface
│   ├── DishRepository.cs     # Implementation
│
│── appsettings.json          # Configuration
│── launchSettings.json       # Development Settings
│── Program.cs                # Main API Startup
│── AlgerianFoodAPI.http      # HTTP Test Requests
│── README.md                 # API Documentation
```

---

## 📜 License
🔓 **MIT License** – Free to use and modify.

---

## 🤝 Contributing
Want to add more **Algerian dishes**?  
1. Fork the repo 🍴  
2. Create a new branch 🌿  
3. Submit a **Pull Request** ✅  

---

## 📞 Contact
👨‍💻 **Author:** Mahdi Bentaleb  
🌍 **GitHub:** [Madiben](https://github.com/Madiben)  
📧 **Email:** mehdibentaleb22@gmail.com

---

🚀 **Enjoy the Algerian Food API!** 🇩🇿✨
