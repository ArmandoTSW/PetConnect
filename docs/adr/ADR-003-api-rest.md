# ADR-003 - API REST

## Estado
Aceptado

## Contexto
PetConnect necesita una API REST para probar y exponer operaciones principales de mascotas, adoptantes y solicitudes de adopcion. Esta API debe complementar a la interfaz MVC, no reemplazarla.

## Decision
Se agrega el proyecto `PetConnect.Api` con ASP.NET Core 8, endpoints REST y Swagger en ambiente de desarrollo. La API reutiliza los servicios de `PetConnect.Application` y los repositorios de `PetConnect.Infrastructure`.

## Justificacion
La API permite probar el sistema desde Swagger o clientes externos sin duplicar reglas de negocio. La logica principal se mantiene en Application y Domain.

## Alternativas consideradas
- Usar solamente MVC: se descarto porque no permite probar endpoints REST.
- Duplicar logica en la API: se descarto porque aumentaria errores y mantenimiento.
- Crear una API separada sin compartir proyectos: se descarto porque complicaria el proyecto escolar.

## Consecuencias
El proyecto puede ejecutarse como interfaz web MVC o como API con Swagger. Como desventaja, se debe mantener otro proyecto dentro de la solucion.
