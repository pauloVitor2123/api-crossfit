# API Crossfit

## Requisitos do projeto
- Microsoft SQL Server
- Visual Studio 2022

## Instalação

1. Clone o repositório: https://github.com/pauloVitor2123/api-crossfit.git
2. Criar o arquivo `appsettings.json` de acordo 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DataBase": "Server={name};Database=DB_Crossfit;User Id={iduser};Password={password}"
  },
  "AllowedHosts": "*"
}

3. Abrir o "Console do Gerenciador de Pacotes" e digitar o comando `Update-Database`4. Rodar a solução.
4. Execute a solução.


## Comandos do EF (Entity Framework)
1. Adicionar uma migração: Add-Migration initialDB -Context AppDBContext
2. Atualizar o banco de dados: Update-Database -Context AppDBContext
