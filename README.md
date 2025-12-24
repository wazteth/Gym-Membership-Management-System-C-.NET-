# Gym-Membership-Management-System
A desktop-based management application built using **C#** and the **.NET Framework**. This system streamlines gym operations, allowing members to register and enroll in classes while providing administrators with full control over user data, trainers, and class schedules.

## 🚀 Features
<br>
For Members

- **Self-Registration**: New users can create accounts directly through the application.

- **Class Enrolment**: Browse available gym classes and enroll in them.

- **Secure Login**: Access personal accounts via a secure login interface with validation checks.

For Administrators

- **Account Management**: Create, update, and delete member accounts.

- **Data Oversight**: Manage tables for **Trainers**, **Gym Classes**, and **Enrolments**.

- **Security**: Dedicated Admin login portal to ensure restricted access to sensitive data.

## 📊 Database Architecture
The system utilizes a relational database (`GymMember.mdf`) to ensure data integrity. The core entities include:

- **Login Data**: Stores credentials and user roles.

- **Trainers**: Details of gym instructors.

- **Gym Classes**: Information on schedules and class types.

- **Enrolment**: Maps members to specific classes.

<img width="946" height="217" alt="ERDiagram" src="https://github.com/user-attachments/assets/6d5504f1-112c-4449-8448-5402cc9c27ef" />

## 🛠 Tech Stack
- **Language**: C#

- **Framework**: .NET Framework (Windows Forms)

- **Database**: Microsoft SQL Server (MDF file)

- **Modeling**: MySQL Workbench (EER Diagram)

## 📋 Prerequisites
To run or modify this project, you will need:

- **Visual Studio** (2019 or later recommended)

- **.NET Desktop Development** workload installed

- **SQL Server Express** or LocalDB to attach the `.mdf` database file

## ⚙️ Installation & Setup
1. **Clone the Repository**:

```Bash

git clone https://github.com/wazteth/Gym-Membership-Management-System-C-.NET-.git
```
2. **Database Setup**:

    - Ensure `GymMember.mdf` and `GymMember_log.ldf` are in the project directory.

    - Update the `connectionString` in your `App.config` or database helper class to point to your local path.

3. **Build and Run**:

    - Open the solution file in Visual Studio.

    - Press `F5` to build and launch the application.

## 🧪 Testing Plan

The project includes comprehensive validation logic, as detailed in the documentation:

- **Field Validation**: Ensures no empty fields during registration or admin updates.

- **Duplicate Checks**: Prevents multiple accounts with the same username.

- **UI Feedback**: Uses Message Boxes to notify users of successful actions or input errors. 
