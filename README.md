# BootcampAPI

API REST desarrollada con **ASP.NET Core .NET 10** como proyecto de bootcamp, aplicando principios de **Clean Architecture**, **CQRS** y separación de responsabilidades.

El proyecto implementa un CRUD de Accounts, persistencia con PostgreSQL, validaciones, manejo de excepciones, logging estructurado y despliegue mediante Docker y Kubernetes.

## Tecnologías

- .NET 10
- ASP.NET Core Minimal API
- Clean Architecture
- CQRS
- MediatR
- Entity Framework Core
- PostgreSQL
- FluentValidation
- Serilog
- Seq
- Swagger / Scalar
- Docker
- Kubernetes
- Minikube
- Helm
- GitHub Actions

## Arquitectura

El proyecto está organizado siguiendo Clean Architecture, separando las responsabilidades entre las capas de API, Application, Domain e Infrastructure.

CQRS se utiliza mediante MediatR para separar las operaciones de lectura (`Queries`) de las operaciones de escritura (`Commands`).

## Funcionalidades

- CRUD de Accounts
- Validación de requests mediante FluentValidation
- Manejo centralizado de excepciones mediante middleware
- Logging estructurado con Serilog
- Visualización de logs mediante Seq
- Persistencia con PostgreSQL y Entity Framework Core
- Documentación mediante Swagger / Scalar
- Contenerización con Docker
- Despliegue mediante Kubernetes y Helm
- Pipeline de CI/CD mediante GitHub Actions

## Kubernetes con Minikube

### Requisitos

- Docker Desktop
- Minikube
- kubectl
- Helm
- Git

## CI/CD

El proyecto utiliza GitHub Actions para automatizar el proceso de integración continua.

## Autor

Marcelo Avalos
