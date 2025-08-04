# 📦 Proyecto: Gestión de Órdenes

## 🧾 Descripción

Este proyecto implementa una solución completa para la gestión de órdenes de clientes, utilizando buenas prácticas de arquitectura y tecnologías modernas en el backend y frontend.

- **Backend**: .NET Core 8 con arquitectura **hexagonal**, acceso a datos mediante **Dapper** (micro ORM) y base de datos **SQL Server**.
- **Frontend**: **Angular 17** con Angular Material, diseño modular y uso de formularios reactivos.
- Comunicación entre capas desacoplada y organizada bajo principios **SOLID** y **Clean Architecture**.

---

## 🚀 Características

- 📄 Registro de órdenes con detalles de producto  
- 📊 Predicción de próxima fecha de compra por cliente (usando SQL + lógica de ventana)  
- 🔍 Filtrado de órdenes por cliente  
- 🧪 Validaciones de formularios en frontend  
- 💾 Acceso a datos con Dapper (consultas, stored procedures)  
- ✅ Integración de formularios con Angular Material  

---


## ⚙️ Tecnologías Usadas

| Backend               | Frontend          |
|----------------------|-------------------|
| .NET 8               | Angular 17        |
| C#                   | Angular Material  |
| Dapper               | RxJS              |
| SQL Server           | TypeScript        |
| Arquitectura Hexagonal | Formularios Reactivos |

---

## 🛠️ Estructura del Proyecto

```
/BD
└── 01. sp_GetSalesDatePrediction
└── 02. sp_AddNewOrderWithDetail

/Backend
└── Application
│   ├── Ports
│   └── UseCases
└── Domain
│   └── Model
└── Infrastructure
    └── Adapters
        ├── In
        │   └── WebApi
        └── Out
            └── ReporitorySqlServer

/Frontend
└── src
    ├── app
    │   ├── components-general
    │   │   └── layout
    │   │       └── sidebar
    │   └── views
    │       └── customers
    │           ├── components
    │           │   ├── customer-orders-modal
    │           │   └── new-order-dialog
    │           ├── interfaces
    │           ├── sales-date-prediction
    │           └── services
    └── environments
```

---

## 💡 Cómo Ejecutarlo

### 🗄️ Scripts de Base de Datos

Antes de ejecutar el proyecto, asegúrate de crear los procedimientos almacenados ejecutando los siguientes scripts ubicados en la carpeta `/DB`:

1. `01_sp_GetSalesDatePrediction.sql` – Predicción de la próxima orden de compra de un cliente.
2. `02_sp_AddNewOrderWithDetail.sql` – Inserción de una nueva orden junto con su detalle.

### ⚙️ Backend (.NET)

> ⚠️ **Importante:** Asegúrate de configurar la cadena de conexión en appsettings.json.

```bash
cd Backend/WebApi
dotnet restore
dotnet run
```

### 🖥️ Frontend (Angular)

```
cd Frontend
npm install
ng serve
```

---

## 📸 Capturas

### Sales Date Prediction

<img width="600" height="400" alt="image" src="https://github.com/user-attachments/assets/294e987d-298d-4a5e-9f54-8bd1a437f4d3" />

### View Orders Of Customer
<img width="600" height="400" alt="image" src="https://github.com/user-attachments/assets/d8a1b2a3-0edc-4dd8-9af7-a06a3eb11728" />

### New Order
<img width="600" height="400" alt="image" src="https://github.com/user-attachments/assets/5311c5a0-70b3-4b7f-9043-c0cb48f7cbee" />

---

## 🙋 Autor

### Yeimer Andres Jaramillo Fernandez
📧 Mail: Andresjara0897@hotmail.com <br/>
💼 GitHub: https://github.com/Jaferye97 <br/>
🔗 LinkedIn: https://www.linkedin.com/in/yeimerjarafer/ <br/>

