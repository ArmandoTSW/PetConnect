# PetConnect

PetConnect es una aplicacion web escolar para gestionar adopciones de mascotas. Permite visualizar mascotas disponibles, registrar adoptantes y crear solicitudes de adopcion desde una interfaz MVC con Bootstrap 5.

## Problema que resuelve

Muchas adopciones requieren organizar informacion basica de mascotas, personas interesadas y solicitudes. PetConnect centraliza ese flujo para que sea facil consultar disponibilidad y dar seguimiento al estado de cada solicitud.

## Tecnologias usadas

- ASP.NET Core 8 MVC
- C#
- Bootstrap 5
- Datos temporales en memoria
- Git

## Arquitectura

La version base separa el proyecto en capas simples:

- `PetConnect.Domain`: entidades principales del negocio.
- `PetConnect.Application`: servicios e interfaces.
- `PetConnect.Infrastructure`: repositorios en memoria.
- `PetConnect.Web`: interfaz web MVC.

## Estructura de carpetas

```text
PetConnect/
├── PetConnect.sln
├── src/
│   ├── PetConnect.Web/
│   ├── PetConnect.Domain/
│   ├── PetConnect.Application/
│   └── PetConnect.Infrastructure/
├── docs/
│   └── adr/
├── README.md
└── .gitignore
```

## Ejecutar interfaz web MVC

```bash
dotnet run --project src/PetConnect.Web
```

## Ejecutar API

La API REST se agregara en una rama posterior como complemento tecnico.

```bash
dotnet run --project src/PetConnect.Api
```

## Endpoints principales

Pendiente de agregar cuando exista `PetConnect.Api`.

## Capturas

### Pagina principal
Pendiente de agregar captura.

### Lista de mascotas
Pendiente de agregar captura.

### Swagger API
Pendiente de agregar captura.

## Autor

Jesús Armando Cen Balam.
