# 🏥 ClinicApp – WPF Medical Management System

ClinicApp is a modern desktop application for managing patient appointments, medical visits, and doctors in a small clinic. Built with **WPF (.NET 8)**, **Entity Framework Core**, and **Material Design**, it provides a user-friendly interface and powerful features for daily clinic operations.

---

## 🧰 Features

- 👨‍⚕️ Doctor login, registration (restricted to super admin)
- 👤 Patient list with search and edit capabilities
- 📅 Appointment management (create, view, handle)
- 🗂️ Medical visit records with attachments and tests
- 📄 Export visit detail to PDF (with multi-language support)
- 🛠 Super admin system (secure creation of new doctors)
- ❌ Define unavailable time slots for appointments
- 📦 PostgreSQL + EF Core 9.0 as backend
- 🎨 Modern UI with Material Design

---

## 📦 Tech Stack

| Layer          | Technology                          |
|----------------|-------------------------------------|
| Frontend       | WPF (.NET 8)                        |
| Backend        | Entity Framework Core 9             |
| Database       | PostgreSQL (via Npgsql), SQLite     |
| PDF Export     | QuestPDF                            |
| Styling        | MaterialDesignThemes                |


---

## 🚀 Getting Started

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- PostgreSQL (version 12+ recommended)

### 📥 Clone the Repository

```bash
git clone https://github.com/TonyisHero01/ClinicApp.git
cd ClinicApp
```

## ⚙️ Configuration

### 1. Database

This application uses **Entity Framework Core** and supports two database engines:

- **PostgreSQL** (via `Npgsql`) — used for **remote appointment records**, such as online bookings.

  > ⚠ The remote database connection string must be configured in:  
  > `ClinicApp/Config/DbConfig.cs`   

### 🧩 PostgreSQL Remote Schema

This is the table structure used by the remote PostgreSQL instance (`clinic_system`):

#### 📅 `appointment`
```sql
CREATE TABLE appointment (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    date DATE NOT NULL,
    time TIME(0) WITHOUT TIME ZONE NOT NULL,
    reason TEXT NOT NULL,
    notified BOOLEAN NOT NULL DEFAULT FALSE,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    handled BOOLEAN NOT NULL DEFAULT FALSE,
    email VARCHAR(255),
    phone VARCHAR(50),
    reminder_sent BOOLEAN DEFAULT FALSE
);

CREATE OR REPLACE FUNCTION notify_appointment_change()
RETURNS TRIGGER AS $$
BEGIN
    PERFORM pg_notify('appointment_changed', '');
    RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER appointment_notify_trigger
AFTER INSERT OR DELETE OR UPDATE ON appointment
FOR EACH STATEMENT
EXECUTE FUNCTION notify_appointment_change();
```

#### ⛔ `unavailable_periods`
```sql
CREATE TABLE unavailable_periods (
    id SERIAL PRIMARY KEY,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    start_time TIME WITHOUT TIME ZONE NOT NULL,
    end_time TIME WITHOUT TIME ZONE NOT NULL,
    reason TEXT
);

```

---

These tables are required for:

- Managing appointment data (used by `AppointmentListWindow`, `AppointmentDetailWindow`)
- Handling unavailable time blocks (used by `SetUnavailableTimeWindow`)


- **SQLite** — used **locally** to store **doctors, patients, visits, and other internal data**.  
  It is preconfigured and requires no additional setup.
For creating SQLite database please use NuGet Package Manager Console to run: 
    ```bash
    Add-Migration <Migration-file-name>
    Update-Database
    ```
---
### 2. Email Configuration

To enable automatic email sending, configure the SMTP settings in:
ClinicApp/emailsettings.json:

```json
{
    "SmtpServer": "<your_smtp_server>",
    "SmtpPort": "<your_port>",
    "SenderEmail": "<your_email_address>",
    "SenderPassword": "<your_app_password>"
}
```
Notes:

For Gmail, you must enable App Passwords or allow less secure apps.

This file is copied to the output directory automatically (see .csproj config).

Keep this file private — never commit it to version control.

---

### 3. API Configuration

Some features, like marking appointments as handled, rely on communication with a remote API.

API configuration is defined in:
ClinicApp/Config/ApiConfig.cs
```csharp
namespace ClinicApp.Config
{
    public static class ApiConfig
    {
        public const string BASE_URL = "<your-url>:<your-port>/";
        public const string API_TOKEN = "<your-api-token>";
    }
}
```
📌 Important:

BASE_URL should point to the server where your appointment API is hosted.

API_TOKEN must match the token expected by the backend.

Never expose real tokens in public repositories.

