# Exam
# Exam

📁 Included Files in the Project 👉(ScriptSqlDummyDataAndAnotherFiles)
The project package contains the following important supporting files:

📄 Database Script
A ready-to-use SQL script to create the full database schema required for the system.

📄 Dummy Data Script
A separate SQL script that inserts sample (dummy) data into the database for demonstration and testing purposes.

📊 System Diagram (.drawio)
A visual diagram (in .drawio format) that clearly illustrates the overall architecture, components, and data flow of the system.

These files are included to help reviewers or developers understand, set up, and evaluate the system quickly and efficiently.

🔐 Credentials for Easier Access
You can use the following sample emails and passwords to log in and test the project more easily during review or development:

(Moha@gmail.com,@aA12345) as admin And Student
(zzzz@gmail.com,@aA12345) as Student

🧱 Project Architecture & Technologies Used
This project is structured using a clean layered architecture that ensures separation of concerns and scalability:

📁 Project Layers:
UI Layer (Presentation): ASP.NET MVC with Razor views, partial views, and reusable components.

API Layer: Handles HTTP requests for frontend and possibly mobile integration.

Resources Layer: Centralized resource files for multilingual support.

BL (Business Logic) Layer: Contains all business rules and services logic.

DAL (Data Access Layer): Uses Entity Framework to interact with the SQL Server database.

Domain Layer: Holds core entity models (with base audit fields and relationships).

🛠️ Technologies & Tools:
ASP.NET MVC 5

Entity Framework (Code First)

AutoMapper – for efficient mapping between domain models and DTOs

Authentication & Authorization – using ASP.NET Identity (Roles & Claims)

Dependency Injection – for managing service lifetimes and reducing tight coupling between components

DTOs (Data Transfer Objects) – to decouple the UI/API from the domain

Services Pattern – encapsulating business logic and injected via DI

Reusable Components & Partial Views – for a modular UI design

SQL Server – as the backend database

Bootstrap – for responsive frontend design

هذا المشروع هو فكرة بسيطة تهدف إلى توضيح مستواي البرمجي وخبرتي الحالية.
المشروع كالاتي:
يُعتبر المشروع نظام اختبارات موجه للطلاب، حيث يتيح:
إضافة مواد دراسية وأسئلة واختبارات جديدة.
إمكانية تعديل المحتوى وإدارته بنظام صلاحيات محكم يضمن أن التعديلات تتم فقط من قِبل الأدمن أو المستخدمين المصرح لهم.
تخصيص أنواع مختلفة من الصلاحيات لكل مستخدم، مع إمكانية منح الشخص الواحد أكثر من دور داخل النظام.
سهولة التنقل والاستخدام داخل المشروع بفضل تطبيق  Business Process Modeling او بمعني اشمل Business Analysis.
