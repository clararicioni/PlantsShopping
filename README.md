# 🌱 PlantsShopping

Aplicação web para catálogo e gerenciamento de plantas.

## 🚧 Status

**Em desenvolvimento**

## 🛠️ Tecnologias

<p> <img src="https://skillicons.dev/icons?i=angular,dotnet,cs,typescript,postgresql,html,css,bootstrap" /> </p>

**Bibliotecas e ferramentas**

* Entity Framework Core
* Npgsql
* AutoMapper
* Swashbuckle / Swagger
* Font Awesome
* RxJS
* Angular Router
* Angular Forms
* Angular HttpClient

## 📸 Imagens

<div align="center">

<img src="https://github.com/user-attachments/assets/1c36ad9c-0fbc-4ce0-a297-aac2b23f7ed5" alt="Home" />

<br><br>

<img src="https://github.com/user-attachments/assets/0ba7abd4-97f5-4d21-9317-2e2f9db27fd9" alt="Catálogo de plantas" />

<br><br>

<img src="https://github.com/user-attachments/assets/58d28139-4777-4977-b59c-d1ef04fd4072" width="50%" alt="Cadastro de planta" />

<br><br>

<img src="https://github.com/user-attachments/assets/55a83b4d-ce01-4752-8383-27e5df751237" alt="Sobre o projeto" />

</div>

## 🏗️ Estrutura

```text
PlantsShopping
│
├── PlantsShopping.Web
│   ├── ClientApp
│   │   ├── pages
│   │   ├── services
│   │   ├── shared
│   │   └── assets
│
└── PlantsShopping.ProductAPI
    ├── Controllers
    ├── Data
    ├── Repository
    └── ...
```

## 🔌 API

### Plantas

| Método | Endpoint             | Descrição              |
| ------ | -------------------- | ---------------------- |
| GET    | `/api/v1/Plant`      | Lista todas as plantas |
| GET    | `/api/v1/Plant/{id}` | Busca uma planta       |
| POST   | `/api/v1/Plant`      | Cadastra uma planta    |
| PUT    | `/api/v1/Plant`      | Atualiza uma planta    |
| DELETE | `/api/v1/Plant/{id}` | Exclui uma planta      |

## 🌿 Categorias

As plantas são divididas em:

* CACTOS/SUCULENTAS
* FLORES/ORNAMENTAIS
* FOLHAGENS
* ARVORES/ARBUSTOS
* FRUTIFERAS
* HORTAS/ERVAS
* OUTRAS

## 📋 Cadastro de plantas

Cada planta possui as seguintes informações:

```json
{
  "name": "Monstera",
  "price": 59.90,
  "description": "Planta ornamental para ambientes internos.",
  "categoryName": "FOLHAGENS",
  "imageUrl": "https://exemplo.com/monstera.jpg"
}
```

O valor `0` no campo `price` representa uma planta disponível para **doação**.

## ▶️ Como executar

### Pré-requisitos

* .NET 10 SDK
* Node.js
* Angular CLI
* PostgreSQL

### Backend

```bash
cd PlantsShopping.ProductAPI
dotnet restore
dotnet run
```

### Frontend

```bash
cd PlantsShopping.Web/ClientApp
npm install
ng serve --open --proxy-config proxy.conf.json --live-reload=false
```

