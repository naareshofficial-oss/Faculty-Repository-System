# VP_PBE – FYP & Academic Resource Management System

A Windows desktop application (C# WinForms) for managing **Final Year Projects (FYP)** and academic resources at **Universiti Selangor (UNISEL)**. It supports three user roles — **Student**, **Teacher (Lecturer)** and **Admin** — and stores all data in a **MySQL** database.

---

## Features

### Student
- Register and log in
- Search available FYP titles
- Submit a project proposal
- Upload project documents
- Check supervisor assignment
- Check submission deadlines
- View project status
- Browse lecture materials
- Download past-year exam papers
- Student repository
- Update personal information

### Teacher / Lecturer
- **FYP Management** – add, edit and manage FYP project titles
- **Supervision** – record progress notes and feedback per student
- **Grading** – enter marks and grades for student projects
- **Resource Management** – upload learning resources
- **Past Questions** – upload and manage past-year papers
- **Question Bank** – maintain questions and answers by subject

### Admin
- **Manage Users** – add, edit and manage accounts
- **Assign Roles** (credentials) – change user roles
- **Reset Password** – reset any user's password
- **Approve Submissions** – FYP project approval
- **Manage Categories** – categorise learning resources
- **System Logs** – audit trail (logins, registrations)
- **Export Data** – export reports to **PDF** (iTextSharp) or **CSV**

### General
- Role-based redirect after login
- SHA-256 password hashing
- Login and registration events written to a `Logs` table
- Account status check (only `Active` accounts can log in)

---

## Tech Stack

| Component | Details |
|---|---|
| Language | C# |
| UI | Windows Forms (WinExe) |
| Framework | .NET Framework 4.7.2 |
| Database | MySQL (`MySql.Data` 9.6.0) |
| PDF export | iTextSharp 5.5.13.5 |
| IDE | Visual Studio 2022+ (solution file: `VP_PBE.slnx`) |
| Package management | NuGet (`packages.config`) |

---

## Project Structure

```
VP_PBE/
├── VP_PBE.slnx                  # Solution file
├── packages/                    # NuGet packages
└── VP_PBE/
    ├── Program.cs               # Entry point (opens the Register form)
    ├── App.config               # DB connection string
    ├── DatabaseConnection/      # MySQL connection helper
    ├── Services/
    │   ├── AuthenticationService.cs   # Login, password hashing, login logging
    │   ├── RegistrationService.cs     # Registration & validation
    │   └── SessionManager.cs          # Current user session
    ├── Student/                 # Student-facing forms (+ Login & Register)
    ├── Lecture/                 # Teacher-facing forms
    ├── Admin/                   # Admin-facing forms
    ├── Properties/
    ├── Resources/               # Logos / images
    └── uploads/                 # Sample uploaded PDFs
```

---

## Prerequisites

- Windows 10/11
- Visual Studio with the **.NET desktop development** workload
- .NET Framework 4.7.2 targeting pack
- MySQL Server 8.x (running locally)

---

## Setup

### 1. Clone / extract the project
Open `VP_PBE.slnx` in Visual Studio and restore NuGet packages (right-click solution → **Restore NuGet Packages**).

### 2. Create the database
Create a MySQL database named `VP_PBE`:

```sql
CREATE DATABASE VP_PBE;
```

The source code expects these tables (inferred from the queries; no SQL script is included in the project):

| Table | Purpose |
|---|---|
| `Users` | `user_id`, `role`, `username`, `password`, `email`, `status` |
| `Students` | `student_id`, `user_id`, `program`, `semester`, `cgpa` |
| `Teachers` | `teacher_id`, `user_id`, `department`, `specialization` |
| `FYP_Projects` | `project_id`, `title`, `description`, `status` |
| `supervisor_assignment` | links `student_id` ↔ `teacher_id` |
| `student_supervision` | `supervision_id`, `student_name`, `progress_notes`, `feedback`, `last_updated` |
| `student_grading` | `student_name`, `project_title`, `marks`, `grade` |
| `submission_deadlines` | submission deadlines |
| `learning_resources` | `resource_id`, `title`, `category`, `subject`, `file_path` |
| `resource_categories` | `category_id`, `category_name`, `category_type` |
| `past_questions` | `question_id`, `subject`, `semester`, `year`, `faculty`, `program`, `file_path` |
| `question_bank` | `q_id`, `subject`, `question`, `answer` |
| `Logs` | `user_id`, `action`, `description`, `ip_address`, `timestamp` |

> Column lists are approximate — check the queries in the source if something doesn't match.

### 3. Configure the connection string
Edit `VP_PBE/App.config`:

```xml
<connectionStrings>
  <add name="MySQLConnection"
       connectionString="Server=localhost;Database=VP_PBE;Uid=YOUR_USER;Pwd=YOUR_PASSWORD;"
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

### 4. Build and run
Set **VP_PBE** as the startup project, then press **F5** (or build and run `bin/Debug/VP_PBE.exe`).

On launch the app opens the **Register** form; existing users can go to **Login** from there.

---

## User Roles

| Role value | Dashboard |
|---|---|
| `Student` | Student Dashboard |
| `Teacher` | Lecturer Dashboard |
| `Admin` | Admin Dashboard |

New accounts are created with status `Active`. Passwords must be at least 6 characters.

---

## Known Issues & Security Notes

Worth fixing before any real deployment:

1. **Hard-coded DB credentials** – `App.config` contains the root username and password. Use a dedicated low-privilege MySQL user and keep credentials out of version control.
2. **Open role selection at registration** – the Register form offers **Admin** as a role, so anyone can self-register as an administrator. Restrict this to Student/Teacher and have admins grant elevated roles.
3. **Unsalted SHA-256 passwords** – use a slow, salted hash such as bcrypt or PBKDF2 instead.
4. **Generic form names** – several forms are named `Form2`, `Form3`, `Form6`, `Form7`, etc., and `UploadProjectDocument.cs` declares a second `SessionManager` class. Renaming them would make the code easier to maintain.
5. **Files stored by path** – uploaded files are referenced by file path in the database, so paths must be reachable from every machine that uses the app.
6. **Committed build artefacts** – `bin/`, `obj/`, `.vs/` (including Copilot chat/index data) and `packages/` are in the archive. Add a `.gitignore` for them.

---

## Suggested `.gitignore`

```
.vs/
bin/
obj/
packages/
*.user
*.suo
```

---

## License

No license specified. Note that **iTextSharp 5.x** is licensed under **AGPL v3**, which may affect how you can distribute this application.

## Author

*Add your name, student ID and course/supervisor details here.*
