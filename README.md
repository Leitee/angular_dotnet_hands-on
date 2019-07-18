# Prisma Demo


![Alt text](https://pandorasistemas.visualstudio.com/SchoolMngr/_apis/build/status/SchoolMngr-WebAPI-CI "Azure pipeline")


## Algunos features

* Para acceder a los datos se aplican patrones como Repository, Uow, y Factory, permitiendo hacer llamadas simples desde la capa de servicio;
* Librerías hechas en .Net Standard para poder reutilizar tanto en .Net Core como en .Net Framework
* Una librería CORE transversal a todo el proyecto en la cual se definen los contratos que van a implementar las diferentes capas del sistema. Ayudando a la reutilización del código, mayor robustez y testeabilidad.
* El código una vez hecho el commit a Github se somete a CI en la plataforma Azure DevOps. 
* La base de dato esta creada con EF Code First, en modo desarrollo se crea una instancia de LocalDb, luego para el despliegue cambia por un Full Sql (Docker)
* Se usa Librería Reinforced.Typing para generar automáticamente el modelo del cliente web. Una vez que se compila con éxito el proyecto Prisma.Demo.MODEL
* Aplicación desplegada en Docker hub mediante CD para descarga y testearla posteriormente. 
* El cliente web maneja los errores con un Interceptor como asi tmb las llamadas http a la Api.

# Luego de hacer pull del repositorio se puede testear el projecto de 2 maneras. 

## 1) Bajar ambas imágenes y corre usando docker

*docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Devadmin321' -p 5433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
*sqlcmd -U sa -P Devadmin321 -S localhost,5433 -i src/db_script/createDB.sql
*docker run --rm -d -p 88:80/tcp leitee/prisma.api:pod
*docker run --rm -d -p 8080:80/tcp leitee/prisma.spa:latest

## 2) Corre en modo local

### Api REST
*dotnet ef database update
*dotnet build src/prisma.api/Prisma.Demo.sln
*dotnet run --project src/prisma.api/Prisma.Demo.API/Prisma.Demo.API.csproj

### Cliente Web SPA
npm install
npm start
