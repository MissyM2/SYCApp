# SYCApp

### Overview
SYCApp is a .Net 7.0, .Net Maui and Xunit app that has been created as a template that includes best practices for app development.  To that end it includes the following:

  - Separation of Concerns: loosely coupling database and UI through the use of interfaces and MVVM architecture
  - DRY principles:  abstractions of database operations, use of base classes
  - Modularity that allows for unit testing the data and business logic
  - Dependency Inversion: High level modules are not dependent on low level modules.  The TodoSampleApp uses dependency injection, interfaces and abstraction.



### Structure
Solution Name: SYCApp
Projects:
- SYCApp.Core
- SYCApp.Core.Tests
- SYCApp.Domain
- SYCApp.Maui
- SYCApp.Maui.Core
- SYCApp.Maui.Tests
- SYCApp.Persistence
- SYCApp.Persistence.Tests
- SYCAppWebApi
- SYCAppWebApi.Tests

### Libraries and Folders

- SYCApp.Core
  - Microsoft.EntityFrameworkCore.Tools
 
  - /DataServices
  - /Enums
  - /Models
  - /Processors
    
- SYCApp.Core.Tests
  - Microsoft.NET.Test.Sdk
  - xunit
  - xunit.runner.visualstudio
  - coverlet.collector
  - Moq
  - Shouldly
 
  - request processor tests in root
 
- SYCApp.Domain
  -   Microsoft.EntityFrameworkCore.Tools
 
  -   /BaseModels
  -   model files in root

- SYCApp.Maui
  - Microsoft.Extensions.Logging.Debug
  - CommunityToolkit.Mvvm

  - /Controls
  - /Pages
  - /Services

- SYCApp.Maui.Core
  - CommunityToolkit.Mvvm
  - sqlite-net-pcl
  - SQLitePCLRaw.bundle_green"
  - SQLitePCLRaw.provider.dynamic_cdecl
  
  - /Converters
  - /Database
  - /Domain
  - /Extensions
  - /Interfaces
  - /Localization
  - /Services
  - /Validation
  - /ViewModels
 
- SYCApp.Maui.Tests
  - Microsoft.NET.Test.Sdk
  - xunit
  - xunit.runner.visualstudio
  - coverlet.collector
  - Moq
  - FluentAssertions

  - /Mocks
  - /ViewModels
 
- SYCApp.Persistence
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.EntityFrameworkCore.Sqlite
  - Microsoft.EntityFrameworkCore.Design

  - /Services
  - SYCAppDbContext
 
- SYCApp.Persistence.Tests
  - Microsoft.NET.Test.Sdk
  - xunit
  - xunit.runner.visualstudio
  - Miccrosoft.EntityFrameworkCore.Tools
  - Microsoft.EntityFrameworkCore.InMemory

  - LoginServiceTest
 
- SYCApp.WebApi
  - Microsoft.AspNetCore.OpenApi
  - Swashbuckle.AspNetCore
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.Data.Sqlite.Core
  - Microsoft.EntityFrameworkCore.Sqlite.Core

  - /Controllers
 
- SYCApp.WebApi.Tests
  - Microsoft.NET.Test.Sdk
  - xunit
  - xunit.runner.visualstudio
  - Moq
  - Shouldly

  - LoginControllerTests

 
### Other Features
 
