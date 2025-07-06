[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)
[![NuGet Version](https://img.shields.io/nuget/v/CoreMap)](https://www.nuget.org/packages/CoreMap)
[![](https://img.shields.io/nuget/dt/CoreMap?label=Downloads)](https://www.nuget.org/packages/CoreMap)

# CoreMap

**CoreMap** is a lightweight, di friendly object mapping library designed for **Clean Architecture** in modern .NET applications. 
It promotes **manual mapping via handler classes**, encouraging full control, maintainability, and testability.

## ✨ Features

- 🔌 **DI-integrated mapper resolution** – mapping handlers are fully resolved from your DI container
- 🧩 **Supports constructor injection** – mapping logic can depend on other services (e.g. complex mapping helper services)
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
- **Mental flow consistency** – you're already using `IRequest` + `IRequestHandler` patterns with MediatR-Style and with CoreMap, you follow the same structure:  
  `DTOs & Entities` + `IMapHandler<TInput, TOutput>`.  
  This reduces mental context switching and increases speed through familiarity.
- **New dev friendliness** – explicit handler-based mapping makes the codebase easier to reason about for anyone unfamiliar with AutoMapper-style conventions.
- **Strict control** – essential for mapping across boundaries like DTOs ↔ domain models, where implicit behavior can introduce subtle bugs.
- **Service injection support** – unlike static extension methods, CoreMap handlers are resolved from DI, allowing you to inject services (e.g. ID generators, localization providers) when mappings require context.

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

[![](https://img.shields.io/nuget/dt/CoreMap?label=Downloads)](https://www.nuget.org/packages/CoreMap)

```bash
dotnet add package CoreMap
```

## 🚀 Usage

### 1. Create Entities

```csharp
public record ArticleEntity
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public AuthorEntity WrittenBy { get; init; } = default!;
}

public record AuthorEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;

}
```
### 2. Create Responses (DTOs)
```csharp
internal record ArticleResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public AuthorResponse Author { get; init; } = default!;
}
internal class AuthorResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
}
```
### 3. Create Handlers

```csharp
internal class AuthorResponseToEntityMap : ICoreMapHandler<AuthorResponse, AuthorEntity>
{
    public AuthorEntity Handler(AuthorResponse data) => new AuthorEntity()
    {
        Id = data.Id,
        Name = data.Title
    };
}
internal class ArticleResponseToEntityMap : ICoreMapHandler<ArticleResponse, ArticleEntity>
{
    private readonly ICoreMap _coreMap;

    public ArticleResponseToEntityMap(ICoreMap coreMap)
    {
        _coreMap = coreMap;
    }

    public ArticleEntity Handler(ArticleResponse data) => new ArticleEntity()
    {
        Description = data.Description,
        Id = data.Id,
        Title = data.Title,
        WrittenBy = _coreMap.MapTo<AuthorResponse, AuthorEntity>(data.Author)
    };

}
```

### 4. Register Services
In your Startup or whereever you define your dependency injection:
```csharp
    public static IServiceCollection AddServices(IServiceCollection services){
          // For Assembly Scanned Registration
          services.AddCoreMap(o => { }, new Type[]{
            typeof(Startup)
          });

          // For Manually Registration
          services.AddCoreMap(o => { });
          services.AddScoped<ICoreMapHandler<ArticleResponse, ArticleEntity>, ArticleResponseToEntityMap>();
          services.AddScoped<ICoreMapHandler<AuthorResponse, AuthorEntity>, AuthorResponseToEntityMap>();
          return service;
    }


```

### 4. Use Mapping
Example: 
```csharp
private ArticleEntity Item { get; set; } = default!;
protected override void OnInitialized(IServiceProvider serviceP)
{
    var coreMap = serviceP.GetRequiredService<ICoreMap>();
    var response = new ArticleResponse()
    {
        Description = "A description",
        Title = "A Title",
        Id = Guid.NewGuid(),
        Author = new AuthorResponse()
        {
            Id = Guid.NewGuid(),
            Title = "Maksim Shimshon"
        }
    };

    Item = coreMap.MapTo<ArticleResponse, ArticleEntity>(responses);
}
```

Map a collection:
```csharp
private ArticleEntity Item { get; set; } = default!;
protected override void OnInitialized(IServiceProvider serviceP)
{
    var coreMap = serviceP.GetRequiredService<ICoreMap>();
    var response = new ArticleResponse()
    {
        Description = "A description",
        Title = "A Title",
        Id = Guid.NewGuid(),
        Author = new AuthorResponse()
        {
            Id = Guid.NewGuid(),
            Title = "Maksim Shimshon"
        }
    };
    List<ArticleResponse> responses = new()
    {
        response with { },
        response with{ }
    };
    ICollection<ArticleEntity> entities = coreMap.MapEachTo<ArticleResponse, ArticleEntity>(responses);
}
```