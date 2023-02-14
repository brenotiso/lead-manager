
# Uma SPA simples utilizando React + MUI e .NET 6 

## Instalação e execução
Aqui será apresentado como instalar as dependências do projeto e executar as aplicações:

### 🚀 API

```bash
# navega para a pasta da api
$ cd api

# instala as dependências
$ dotnet restore

# instala as dependências do EF
$ dotnet tool install --global dotnet-ef

# atualiza as dependências do EF
$ dotnet tool install --global dotnet-ef

# executa as migrations para criar/atualizar a base de dados
$ dotnet ef database update --startup-project LeadManager.Api --project LeadManager.Infrastructure --context CommandContext

# rodando a aplicação
$ dotnet run --project .\LeadManager.Api\LeadManager.Api.csproj
```

A aplicação estará disponível em `https://localhost:7110` e `http://localhost:5110`

### 🌐 Web

```
# navega para a pasta do front
$ cd front

# instala as dependências 
$ npm install

# rodando a aplicação
$ npm run start
```

A aplicação estará disponível em `localhost:3000`
