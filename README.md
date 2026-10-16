# Mini CRM v1

Mini CRM v1 is a simple console-based customer management application written in C#/.NET. The project was created as a practical exercise in object-oriented programming, collections, LINQ, validation, nullable reference handling, and CRUD operations.

## Features

- Add a customer
- Display all customers
- Find a customer by ID
- Find a customer by email
- Update customer data
- Remove a customer
- Automatic customer ID generation
- Validation of customer data
- Duplicate email protection
- Console menu interface
- Safe numeric input handling with `TryParse()`

## Customer model

Each customer contains:

- `Id`
- `Name`
- `Email`
- `Age`
- `City`
- `Balance`

## Validation

The application validates customer data before adding or updating a customer:

- Name is required
- Email is required
- Age must be between 0 and 120
- Balance cannot be negative
- Email must be unique

## Project structure

```text
MiniCRMv1/
├── Program.cs
├── Customer.cs
├── CustomerService.cs
└── MiniCRMv1.csproj
```

### `Customer.cs`

Defines the customer data model.

### `CustomerService.cs`

Contains the customer management logic, including CRUD operations and validation.

### `Program.cs`

Contains the console user interface, menu, input parsing, and presentation logic.

## CRUD operations

| Operation | Implementation |
|---|---|
| Create | `AddCustomer()` |
| Read | `GetAllCustomers()`, `GetCustomerById()`, `GetCustomerByEmail()` |
| Update | `UpdateCustomer()` |
| Delete | `RemoveCustomer()` |

## Technologies and concepts used

- C#
- .NET
- Object-oriented programming
- `List<T>`
- LINQ
- `IEnumerable<T>`
- Nullable reference types
- `FirstOrDefault()`
- `Any()`
- `int.TryParse()`
- `decimal.TryParse()`
- Guard clauses
- CRUD

## Running the project

Requirements:

- .NET SDK

From the project directory, run:

```bash
dotnet run
```

The application displays a menu:

```text
===== MINI CRM =====
1. Add customer
2. Show all customers
3. Find customer by ID
4. Find customer by email
5. Update customer
6. Remove customer
0. Exit
```

## Current limitations

Mini CRM v1 stores customers in memory using `List<Customer>`. Data is therefore not persisted after the application is closed.

A future version can replace the in-memory collection with a relational database using SQL and Entity Framework Core.

## Purpose

The project demonstrates practical understanding of fundamental C# concepts by combining them into a complete console application rather than isolated exercises.
