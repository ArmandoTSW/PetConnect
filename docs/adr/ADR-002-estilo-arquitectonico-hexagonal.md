# ADR-002 - Estilo arquitectonico hexagonal

## Estado
Aceptado

## Contexto
PetConnect necesita mantener separada la logica de adopciones de la interfaz web MVC. Tambien se planea agregar una API REST como complemento tecnico, por lo que no conviene que las reglas de negocio dependan directamente de controladores o vistas.

## Decision
Se adopta una arquitectura hexagonal sencilla, tambien conocida como puertos y adaptadores. La capa `Domain` contiene las entidades y reglas principales, `Application` contiene interfaces, servicios y casos de uso, `Infrastructure` contiene repositorios en memoria y `Web` funciona como adaptador de entrada MVC.

## Justificacion
Esta decision permite reutilizar la logica de negocio desde la interfaz MVC y, mas adelante, desde la API REST. Tambien ayuda a que el proyecto sea mas facil de explicar porque cada proyecto tiene una responsabilidad clara.

## Alternativas consideradas
- MVC simple: se descarto porque dejaria demasiada logica en los controladores.
- Capas tradicionales: se descarto porque no deja tan claro el concepto de puertos entre aplicacion e infraestructura.
- Microservicios: se descarto porque agrega complejidad innecesaria para un proyecto escolar.

## Consecuencias
La logica principal queda menos acoplada a la interfaz. Como desventaja, hay mas carpetas y clases que mantener, aunque se conservan simples para el alcance del proyecto.
