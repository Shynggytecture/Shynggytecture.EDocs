# Shynggytecture 

## Introduction

This repository is just an example how Workflow Core can help you to implement CQRS consistently and get  

### Useful links

* [CQRS](https://www.google.com)
* [OData](https://www.google.com)
* [Workflow Core](https://www.google.com)

## Solution structure

```
.
|-- ReadME.md
|-- Shynggytecture.EDocs.sln
|-- Postman Collection
|-- Shynggytecture.EDocs.Core
|   |-- ...
|   |-- Shynggytecture.EDocs.Core.csproj
|
|-- Shynggytecture.EDocs.Workflows
|   |-- ...
|   |-- Shynggytecture.EDocs.Workflows.csproj
|
|-- Shynggytecture.EDocs.DataModel.EfCore
|   |-- ...
|   |-- Shynggytecture.EDocs.DataModel.EfCore.csproj
|
|-- Shynggytecture.EDocs.ReadDataModel.EfCore
|   |-- ...
|   |-- Shynggytecture.EDocs.ReadDataModel.EfCore.csproj
|
|-- Shynggytecture.EDocs.WebAPI
    |-- ...
    |-- Shynggytecture.EDocs.WebAPI.csproj

```

### Core

Link: [Shynggytecture.EDocs.Core](/Shynggytecture.EDocs.Core/)

Dependencies: none 

Core lib what will be used for contracts.

### DataModel.EfCore

Link: [Shynggytecture.EDocs.DataModel.EfCore](/Shynggytecture.EDocs.DataModel.EfCore/)

Dependencies: 

* [Core project](/Shynggytecture.EDocs.Core/)
 
The lib for write db and services

### ReadDataModel.EfCore

Link: [Shynggytecture.EDocs.ReadDataModel.EfCore](/Shynggytecture.EDocs.ReadDataModel.EfCore/)

Dependencies: 

* [Core project](/Shynggytecture.EDocs.Core/)
 
The lib for read db and services

### Workflows

Link: [Shynggytecture.EDocs.Workflows](/Shynggytecture.EDocs.Workflows/)

Dependencies: 

* [Core project](/Shynggytecture.EDocs.Core/)

The lib for implementing business workflows.

### WebApi

Link: [Project](/Shynggytecture.EDocs.Workflows/)

Dependencies: 

* [Core project](/Shynggytecture.EDocs.Core/)
* [Workflow](/Shynggytecture.EDocs.Workflows/)
* [Write data model](/Shynggytecture.EDocs.DataModel.EfCore/)
* [Read data model](/Shynggytecture.EDocs.ReadDataModel.EfCore/)

The API project

