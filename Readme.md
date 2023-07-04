Requisitos

Microsoft SQL Server
Visual Studio e/ou Visual Studio Code


Passo a passo da instalação

1. Clonar o projeto: https://github.com/pauloVitor2123/api-crossfit
2. Criar o arquivo appsettings.json de acordo 
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

3. Rodar no terminal o comando "Update-Database"

4.Rodar a solução.

Alguns comandos do EF:
Add migration - Add-Migration initialDB -Context AppDBContext - Update-Database -Context AppDBContext
