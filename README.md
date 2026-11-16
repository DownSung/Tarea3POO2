# Tarea3POO2

**Tarea de Programación Orientada a Objetos II**

Proyecto de escritorio en C# con Windows Forms y SQL Server. La base `pubs` tiene 11 tablas y el menú muestra un formulario para cada una. Cada formulario presenta los datos en un `DataGridView` con un botón para actualizarlos.

## Pasos para usarlo

1. Abrir SQL Server Management Studio (SSMS).
2. Abrir y ejecutar `BaseDatos/instpubs.sql` para crear `pubs` y cargar los registros de ejemplo. **Cuidado: el archivo original borra la base `pubs` si ya existe.**
3. Ejecutar `BaseDatos/login.sql` para crear la tabla `app_users` del inicio de sesión.
4. Abrir `Tarea3POO2.csproj` en Visual Studio 2022 con **Desarrollo de escritorio con .NET** y .NET 8.
5. En `Datos/Conexion.cs`, modificar `Server=.\SQLEXPRESS` por el nombre de servidor que aparece en SSMS. Se usa autenticación integrada de Windows.
6. Ejecutar con F5. Visual Studio restaurará el paquete `Microsoft.Data.SqlClient` si hay acceso a NuGet.

## Usuario de prueba

Usuario: `admin`  
Contraseña: `Admin123!`

Si falla 3 veces, el formulario de Login se cierra y termina el programa. Los fallos de conexión no cuentan como contraseñas incorrectas.

## Archivos importantes

- `FrmLogin.cs`: ingreso al sistema y control de los intentos.
- `FrmPrincipal.cs`: menú de botones para abrir formularios.
- `FrmTabla.cs`: muestra los registros usando `DataGridView`.
- `FrmAutores.cs`, `FrmLibros.cs`, etc.: 11 formularios asociados a las tablas del archivo original.
- `Conexion.cs`: conexión y consultas a SQL Server.

**Alcance:** esta tarea se concentra en la *capa de presentación*: los formularios muestran y actualizan la consulta de los datos, sin incluir botones de insertar, modificar o eliminar. El formulario compartido `FrmTabla` evita repetir el mismo código en las 11 ventanas.

Este proyecto no se ha compilado ni probado contra un SQL Server real en este entorno. Para uso profesional, el inicio de sesión requeriría medidas adicionales de seguridad.

## Entrega mediante GitHub

Subir el contenido de la carpeta `Tarea3POO2` al repositorio, incluyendo `Tarea3POO2.sln`, `Tarea3POO2.csproj`, los archivos `.cs` y ambos scripts `.sql`. No es necesario subir las carpetas `bin`, `obj` ni `.vs`.

El docente puede descargar el repositorio y abrir `Tarea3POO2.sln` en Visual Studio 2022 con .NET 8. Para ejecutar consultas y usar el login necesita instalar SQL Server, ejecutar los scripts y adaptar el nombre del servidor en `Datos/Conexion.cs`.
