# API-REST-Demo
Una demostración sencilla de un API REST que servirá para hacer funciones CRUD usando .NET y SQL Server

SOFTWARE REQUERIDO:

Visual Studio Community 2022
SQL Server Express 2019
SSMS o PgAdmin  (Cualquiera servirá como gestor)
SDK .NET 6.0
Postman Agent Desktop (04.21)

DEPENDENCIAS: 

	Microsoft.EntityFrameworkCore 6.0.26
 	Microsoft.EntityFrameworkCore.SqlServer 6.0.26
	EFCore.NamingConvention 7.02
	Automapper 11.0.1
 	Automapper.Extensions.Microsoft.DependencyInjection(11.0.0)
	EFCore.NamingConventions(6.0.0)
 

CONTROL DE EXCEPCIONES: 

	400 : Bad Request - Errores generados por usuario
	401 : Unauthorized - Indica que el cliente debe autenticarse para obtener acceso al recurso 	solicitado, pero no se ha proporcionado la autenticación o la autenticación ha fallado.
	403 : Forbidden - Se utiliza cuando el servidor comprende la solicitud del cliente, pero se niega a cumplirla debido a restricciones en el acceso al recurso solicitado. A diferencia de 401, la autenticación no hará ninguna diferencia.
	404 : Not Found - Indica que el recurso solicitado no se encuentra en el servidor. Es el código de error más comúnmente utilizado para indicar que una página web o recurso solicitado no está disponible.
	500 : Internal Server Error - Errores generados por problemas internos
	501 : Registros duplicados en base



Importante: 

Se debe modificar manualmente el servidor SQL al que será dirigido. Considerar el archivo appsettings.json: 

 "ApiDatabase": "Server=LAPTOP-3E3ISE6N\\SQLEXPRESS;Database=master;Trusted_Connection=True;"



