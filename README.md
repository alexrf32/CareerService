# CareerService: gRPC API for Career and Subject Management

CareerService es un microservicio desarrollado en .NET 8 con gRPC y MongoDB. Permite gestionar carreras, asignaturas y relaciones entre asignaturas para instituciones educativas. Está diseñado con una arquitectura robusta para ofrecer escalabilidad, mantenibilidad y facilidad de integración con otros sistemas.

---

## Características Principales

- **Servicios gRPC**: Implementación de métodos para obtener y gestionar carreras, asignaturas y relaciones entre asignaturas.
- **Base de Datos MongoDB**: Almacena datos de carreras, asignaturas y relaciones con alta disponibilidad.
- **Mensajería con RabbitMQ**: Integración para publicar y consumir eventos en sistemas distribuidos.
- **Autenticación JWT (opcional)**: Seguridad implementada para proteger los endpoints.
- **Facilidad de Configuración**: Configuración centralizada mediante archivos JSON.

---

## Requerimientos

Asegúrate de que tu entorno tiene las siguientes herramientas instaladas:

- **[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)** 
- **[MongoDB](https://www.mongodb.com/atlas/database)** como base de datos.
- **[RabbitMQ](https://www.rabbitmq.com/)** para la mensajería (opcional).
- **[Postman](https://www.postman.com/downloads/)** para probar los servicios gRPC.

---

## Configuración Inicial

### Clonar el Repositorio

Clona el repositorio con el siguiente comando:

```bash
git clone https://github.com/alexrf32/CareerService.git

## Restaurar el Proyecto

Después de clonar el repositorio, navega a la carpeta del proyecto y restaura los paquetes de NuGet:

```bash
cd CareerService
dotnet restore
```

## Ejecutar la Aplicación

Para ejecutar la aplicación, utiliza el siguiente comando:

```bash
dotnet run
```
