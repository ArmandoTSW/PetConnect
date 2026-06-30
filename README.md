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

La aplicacion usa una arquitectura hexagonal sencilla:

- `PetConnect.Domain`: entidades principales, value objects y excepciones de negocio.
- `PetConnect.Application`: interfaces, DTOs, servicios y casos de uso.
- `PetConnect.Infrastructure`: repositorios en memoria y registro de dependencias.
- `PetConnect.Web`: adaptador de entrada con interfaz MVC y vistas Bootstrap 5.

La idea principal es que la logica de adopcion viva en `Domain` y `Application`, mientras que `Web` solo se encarga de recibir datos del usuario y mostrar resultados.

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
