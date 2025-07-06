# CoreMap

**CoreMap** is a lightweight, di friendly object mapping library designed for **Clean Architecture** in modern .NET applications. 
It promotes **manual mapping via handler classes**, encouraging full control, maintainability, and testability.

## ✨ Features

- 🔌 **DI-integrated mapper resolution** – mapping handlers are fully resolved from your DI container
- 🧩 **Supports constructor injection** – mapping logic can depend on other services (e.g. repositories, providers, factories)
- 🔁 **Supports both synchronous and asynchronous mapping**
- ♻️ **Singleton mapping handlers by default** – efficient and consistent, but configurable
- ⚙️ **Zero reflection, zero magic** – fully explicit, traceable, and easy to debug
- 🧪 **Easy to test** – works seamlessly with standard unit test libraries and mocking frameworks
- 🌐 **Minimal dependencies** – compatible with `.NET Standard 2.0` and `.NET 8.0+`

## ❓ Why CoreMap?

You might ask: _Why use CoreMap when powerful libraries like AutoMapper or Mapster already exist?_

While those tools are excellent and offer rich features, **CoreMap was created with a different goal in mind**:

> ✅ To enforce **manual, explicit mappings** that reduce ambiguity and avoid surprises — especially for teams following **Clean Architecture** and **MediatR-style** design.

CoreMap favors:

- **Clarity over cleverness** – no magic, no reflection, no unexpected behavior.
- **Mental flow consistency** – you're already using `IRequest` + `IRequestHandler` patterns in MediatR.  
  With CoreMap, you follow the same structure:  
  `IMapRequest<TInput, TOutput>` + `IMapHandler<TInput, TOutput>`.  
  This reduces mental context switching and increases speed through familiarity.
- **New dev friendliness** – explicit handler-based mapping makes the codebase easier to reason about for anyone unfamiliar with AutoMapper-style conventions.
- **Strict control** – essential for mapping across boundaries like DTOs ↔ domain models, where implicit behavior can introduce subtle bugs.
- **Service injection support** – unlike static extension methods, CoreMap handlers are resolved from DI, allowing you to inject services (e.g. lookup repositories, ID generators, localization providers) when mappings require context.

CoreMap doesn't try to replace general-purpose mappers — it focuses on **intentional mapping** in architecturally disciplined applications.

## 🔖 Versioning Policy

### 🚧 Pre-1.0.0 (`0.x.x`)
- The project is considered **Work In Progress**.
- **Breaking changes can occur at any time** without notice.
- No guarantees are made about stability or upgrade paths.

### ✅ Post-1.0.0 (`1.x.x` and beyond)
Follows a common-sense semantic versioning pattern:

- **Major (`X.0.0`)**  
  - Introduces major features or architectural changes  
  - May include well documented **breaking changes**

- **Minor (`1.X.0`)**  
  - Adds new features or enhancements  
  - May include significant bug fixes  
  - **No breaking changes**

- **Patch (`1.0.X`)**  
  - Hotfixes or urgent bug fixes  
  - Safe to upgrade  
  - **No breaking changes**

## 📦 Installation

```bash
dotnet add package CoreMap
```

## 📦 Usage

```bash

```