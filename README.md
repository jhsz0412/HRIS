# HRIS — Human Resource Information System

**Building a modern, modular, and scalable HRIS platform.**

HRIS is an independent software project focused on building a modern Human Resource Information System designed to support employee information management and the operational needs of HR departments.

This project is inspired by my professional experience working with enterprise HRIS software, where I handled backend development, system configuration, report customization, data integration, and client-specific HR requirements. Through that experience, I developed a deeper understanding of HR workflows and the role software plays in managing human resources.

My goal is to use that experience to build my own HRIS product from the ground up — applying my knowledge of HR systems, software engineering principles, and modern web technologies to create a platform that can evolve into a product for real-world organizations.

> **Project status:** In active development. The backend foundation is being developed, while the React frontend is ongoing.

---

## Table of Contents

- [Project Vision](#-project-vision)
- [What Is an HRIS?](#-what-is-an-hris)
- [Architecture](#-architecture)
- [Technology Stack](#-technology-stack)
- [Project Structure](#-project-structure)
- [Core Modules](#-core-modules)
- [Development Principles](#-development-principles)
- [Roadmap](#-roadmap)
- [Project Goals](#-project-goals)

---

## 🎯 Project Vision

The vision is to build an HRIS platform that brings essential human resource operations into one organized system.

Rather than developing the entire application as a single, tightly coupled codebase, this project uses a **Clean Architecture approach with a Modular Monolith design**. This provides a clear separation of responsibilities while allowing related HR modules to operate together within one application.

The long-term goal is to develop a flexible HR platform that can grow with an organization, from employee record management to more advanced HR operations, reporting, and automation.

This is more than a technical exercise. It is an opportunity to turn my professional experience in HRIS implementation and development into a product of my own.

## 👥 What Is an HRIS?

A Human Resource Information System (HRIS) is software that helps organizations manage employee information and HR-related processes in a centralized platform.

Depending on the organization's needs, an HRIS can include:

- **Employee Information Management** — centralized employee records and employment details.
- **Organization Management** — companies, departments, groups, and positions.
- **User and Access Management** — user accounts, roles, permissions, and controlled access.
- **Attendance Management** — attendance records, timekeeping, and work schedules.
- **Leave Management** — leave applications, approvals, and balances.
- **Payroll Management** — payroll processing and employee compensation.
- **Reports and Analytics** — operational reports, summaries, and workforce insights.
- **Workflow Automation** — scheduled tasks, background processing, and approval workflows.

These are the broader product goals. Modules will be introduced progressively as development continues.

## 🏗️ Architecture

### Clean Architecture

The backend follows **Clean Architecture**, organizing the application into layers with distinct responsibilities.

The primary objective is to keep business rules independent of infrastructure details, making the codebase easier to understand, test, and extend.

```text
┌─────────────────────────────────────┐
│              HRIS.Api               │
│     Controllers, HTTP, Swagger      │
├─────────────────────────────────────┤
│          HRIS.Application           │
│ Use Cases, CQRS, Validation,        │
│ Application Interfaces              │
├─────────────────────────────────────┤
│            HRIS.Domain              │
│ Entities and Business Rules         │
├─────────────────────────────────────┤
│         HRIS.Infrastructure         │
│ Database, EF Core, Persistence      │
└─────────────────────────────────────┘
```

The diagram illustrates the main project responsibilities, rather than a strict runtime request sequence.

#### Architecture layers

| Layer | Responsibility |
|---|---|
| **API** | Handles HTTP requests, controllers, API configuration, and endpoint documentation. |
| **Application** | Coordinates use cases, commands, queries, validation, and application-level contracts. |
| **Domain** | Contains core HR entities and business rules. |
| **Infrastructure** | Implements persistence and other technical services, including Entity Framework Core and SQL Server integration. |

The intended dependency direction keeps the Domain at the center of the business logic. Infrastructure implements technical details required by the Application layer, rather than defining the business rules themselves.

### Modular Monolith

This project also follows the **Modular Monolith** architectural style.

A modular monolith is a single deployable application organized into distinct, well-defined modules. Instead of immediately distributing the system across multiple microservices, the application keeps its modules within one solution while maintaining clear boundaries between their responsibilities.

For an HRIS, this is a practical approach because employee records, organizational structures, attendance, leave, and payroll often need to work closely together.

The design aims to provide:

- **Clear module boundaries** — each HR capability has an identifiable responsibility.
- **Simpler deployment** — the backend can initially be deployed as one application.
- **Shared business context** — related HR operations can coordinate without unnecessary network calls between services.
- **Maintainable development** — changes can be organized around individual features and use cases.
- **Room to evolve** — module boundaries can help guide future architectural decisions as requirements grow.

Clean Architecture and Modular Monolith solve different problems: **Clean Architecture organizes dependencies and responsibilities; Modular Monolith organizes business capabilities within one deployable system.** Together, they form the architectural foundation of this project.

## 🛠️ Technology Stack

### Backend API

| Technology | Purpose |
|---|---|
| **C#** | Primary backend programming language. |
| **ASP.NET Core Web API** | Building RESTful API endpoints and backend services. |
| **.NET 10** | Backend application platform. |
| **Entity Framework Core** | Object-relational mapping and database access. |
| **SQL Server** | Relational database for HRIS data. |
| **MediatR** | Organizing application requests and use cases using a mediator pattern. |
| **FluentValidation** | Validating application requests. |
| **Swagger / OpenAPI** | API documentation and endpoint testing. |

### Frontend — In Development

| Technology | Purpose |
|---|---|
| **React** | Building the user interface. |
| **Vite** | Frontend development server and build tooling. |
| **TypeScript** | Type-safe frontend development. |
| **Tailwind CSS** | Utility-first styling and responsive layouts. |
| **shadcn/ui** | Reusable interface components and design foundations. |

The frontend is being developed separately from the backend API, allowing each side to have its own project structure and development workflow.

### Planned Integrations and Capabilities

| Technology | Intended purpose |
|---|---|
| **JWT Authentication** | Token-based authentication for API clients. |
| **Role-Based Access Control (RBAC)** | Managing access according to roles and permissions. |
| **ClosedXML** | Generating Excel reports and exports. |
| **JasperReports** | Advanced report generation and formatted business reports. |
| **Hangfire** | Scheduling and processing background jobs. |

These capabilities are part of the intended technology direction and will be introduced as the corresponding features are implemented.

## 📐 Development Principles

This project aims to apply established software engineering practices throughout development.

- **Object-Oriented Programming (OOP)** — representing business concepts through appropriate objects and entities.
- **SOLID principles** — guiding maintainable class design and separation of responsibilities.
- **Separation of Concerns** — keeping API, application logic, domain rules, and infrastructure distinct.
- **Domain-Driven Design concepts** — using HR domain concepts to guide the organization of business logic.
- **CQRS concepts** — separating commands that change state from queries that retrieve information where appropriate.
- **Dependency Injection** — providing dependencies through the framework rather than tightly coupling implementations.
- **RESTful API design** — exposing clear and consistent HTTP endpoints.
- **Validation** — checking incoming application requests before executing use cases.
- **Database design** — maintaining appropriate relationships, constraints, and query patterns for HR data.

The goal is to apply these principles where they solve real problems, rather than introducing patterns solely for the sake of complexity.

## 🗺️ Roadmap

Development will follow an incremental approach.

- [x] Create the .NET solution and backend projects.
- [x] Establish the initial Clean Architecture project structure.
- [x] Configure Entity Framework Core and SQL Server.
- [x] Create the initial database migration.
- [x] Set up Swagger/OpenAPI documentation.
- [x] Begin foundational employee and organization APIs.
- [ ] Complete and refine foundational HR modules.
- [ ] Implement authentication and authorization.
- [ ] Develop the React frontend.
- [ ] Connect the frontend to the backend API.
- [ ] Build attendance and leave management.
- [ ] Introduce reporting and Excel exports.
- [ ] Implement payroll capabilities.
- [ ] Add background processing and automation.
- [ ] Improve automated testing, deployment, and production readiness.

*The roadmap reflects the intended development sequence and may change as the project evolves.*

## 🚀 Project Goals

My goals for this project are to:

1. Build a real-world HRIS product grounded in practical HR system experience.
2. Strengthen my expertise in C#, ASP.NET Core, React, TypeScript, and SQL Server.
3. Apply Clean Architecture and Modular Monolith principles to a multi-module business application.
4. Develop a foundation that can support more complex HR workflows as the product grows.
5. Eventually turn the project into an independent software product for organizations.

## 📌 Current Status

The backend is the primary development focus. The .NET solution, architecture layers, database integration, initial migration, and API documentation are established. Foundational HR modules are being developed, while the React frontend remains in progress.

This is an evolving project, and features described as planned are not necessarily implemented yet.

---

**Built independently by a developer with hands-on experience in enterprise HRIS development, reporting, and system implementation.**

