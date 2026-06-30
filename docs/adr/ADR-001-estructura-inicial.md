# ADR-001 - Estructura inicial

## Estado
Aceptado

## Contexto
PetConnect necesita una base ordenada para una aplicacion escolar de adopciones de mascotas. El proyecto debe permitir trabajar con una interfaz web MVC y separar el codigo principal para facilitar cambios posteriores.

## Decision
Se crea una solucion ASP.NET Core 8 con cuatro proyectos: `PetConnect.Web`, `PetConnect.Domain`, `PetConnect.Application` y `PetConnect.Infrastructure`.

## Justificacion
Esta estructura mantiene separadas las entidades, los servicios, los repositorios en memoria y la interfaz web. Asi el proyecto puede crecer hacia una API REST sin duplicar la logica principal.

## Alternativas consideradas
- MVC en un solo proyecto: se descarto porque mezcla vistas, reglas y datos en el mismo lugar.
- Microservicios: se descarto porque seria demasiado complejo para el alcance escolar.

## Consecuencias
La solucion queda mas facil de explicar y mantener. Como desventaja, hay mas proyectos y referencias que administrar desde el inicio.
