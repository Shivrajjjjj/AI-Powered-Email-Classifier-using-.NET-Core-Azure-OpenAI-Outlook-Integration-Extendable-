
# 📧 AI-Powered Email Classifier

A smart AI-based email classifier built using ASP.NET Core and Gemini (Google) API. Automatically categorizes emails as **Sales**, **Support**, **Urgent**, **Spam**, etc.

🚀 Designed with a clean, responsive Outlook-style UI.

---

## 🛠 Tech Stack

- ASP.NET Core 8 (Web API)
- Gemini API (Google Generative Language)
- HTML, CSS, JavaScript (Vanilla)
- Local Storage (for classification history)
- Swagger (OpenAPI)
- User Secrets (.NET) for API key security

---

## 📦 Features

- 🧠 Classify email subject & body with AI
- 📜 View recent classification history
- 💾 Stores results using localStorage
- 🧪 Swagger UI for testing the API
- 💻 Fully responsive dashboard UI
- 🔄 Ready for Microsoft Graph/Outlook integration

---

## ⚙️ Setup Instructions

### 1. 📁 Clone this repo

```bash
git clone https://github.com/your-username/AI-PoweredEmailClassifier.git
cd AI-PoweredEmailClassifier
````

### 2. 📌 Install .NET Dependencies

Make sure you have .NET 8 SDK installed.
Then run:

```bash
dotnet restore
dotnet build
```

---

## 🔑 Configure Gemini API Key

### 3.1 ✅ Initialize user-secrets

```bash
dotnet user-secrets init
```

### 3.2 ✅ Set your Gemini API Key (get it from [Google AI Studio](https://makersuite.google.com/app))

```bash
dotnet user-secrets set "Gemini:ApiKey" "YOUR_GEMINI_API_KEY"
```

---

## ▶️ Run the Application

```bash
dotnet run
```

> The app will start at:

* 🌐 Swagger UI: `https://localhost:5001/swagger`
* 📨 Web UI: `https://localhost:5001/`

If your port differs, check `Properties/launchSettings.json`.

---

## 🧪 Sample API Request

**POST** `/api/EmailClassifier`

```json
{
  "subject": "Meeting request for pricing details",
  "body": "Hi team, can we schedule a meeting to discuss pricing and product offerings?"
}
```

**Response:**

```json
{
  "category": "Sales"
}
```

---

## 🌐 Project Structure

```
AI-PoweredEmailClassifier/
├── Controllers/
│   └── EmailClassifierController.cs
├── Services/
│   └── GeminiEmailClassifier.cs
├── wwwroot/
│   ├── index.html         # Main UI
│   ├── styles.css         # Shared styles
│   └── app.js             # JS logic
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 📚 Future Improvements

* 📨 Microsoft Outlook / Exchange Integration via Graph API
* 🗂️ Multi-label classification support
* 📊 Dashboard analytics
* ☁️ Save results to database or cloud storage
* 🎨 Light/Dark Theme toggle

---

