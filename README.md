# Instrucciones de prueba EstadoCuenta
Estado Cuenta manejo de compras y pagos

El proyecto EstadoCuenta es una solución compuesta por dos aplicaciones principales:

EstadoCuentaAPI (Backend - .NET 6)

API REST que gestiona Estados de Cuenta, Compras y Pagos.
Conecta con SQL Server utilizando Entity Framework Core y procedimientos almacenados.

EstadoCuentaWeb (Frontend - ASP.NET MVC)

Aplicación web que permite a los usuarios visualizar el Estado de Cuenta y gestionar Compras y Pagos.
Consume los endpoints de EstadoCuentaAPI.
Tecnologías Utilizadas

Backend (EstadoCuentaAPI)

ASP.NET Core 6

Entity Framework Core

SQL Server

Swagger (Documentación)

Frontend (EstadoCuentaWeb)

ASP.NET Core MVC

Bootstrap (UI)

RestSharp (Consumo de API)

iText7 (Generación de PDF)


Correr proyecto en Visual Studio
http://localhost:5277/
API : http://localhost:5029/swagger/index.html

Endpoints de la API

Obtiene el estado de cuenta de un cliente.

http://localhost:5029/api/EstadoCuenta/1

Registra una nueva compra.

http://localhost:5029/api/Movimientos/RegistrarCompra

{
  "ClienteID": 1,
  
  "Fecha": "2025-01-30T10:00:00",
  
  "Descripcion": "Compra en supermercado",
  
  "Monto": 150.00
  
}

Registrar un pago 

http://localhost:5029/api/Movimientos/RegistrarPago	

{

  "ClienteID": 1,
  
  "Fecha": "2025-01-30T10:00:00",
  
  "Monto": 200.00
  
}

Obtiene todas las compras de un cliente.

http://localhost:5029/api/Movimientos/Compras/1	














