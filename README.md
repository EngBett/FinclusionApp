# FinclusionApp

## Running the application

### 1. Via docker containers
Navigate to `/src` directory on terminal and run 
```
~$ docker-compose up -d 
```

### 2. Locally

#### Create the database
Navigate to the src folder and open `docker-compose.yml` file  
comment the all services except `db` service as shown below:
```
version: "3.9"

services: 
  db:
    container_name: mssql_db
    image: mcr.microsoft.com/mssql/server:2019-latest
    restart: always
    ports:
      - "1433:1433"
    environment:
      SA_PASSWORD: ${MSSQL_PASSWORD}
      ACCEPT_EULA: "Y"
  
#  identity-server:
#    container_name: identity-server
#    build: ./IdentityServer
#    restart: always
#    ports:
#      - "5000:80"
#    volumes:
#      - .:/identity-server
#    depends_on:
#      - db
#        
#  store-api:
#    container_name: store-api
#    build: ./StoreApi
#    restart: always
#    ports:
#      - "5002:80"
#    volumes:
#      - .:/store-api
#    depends_on:
#      - db
#    
#  acc-management:
#    container_name: acc-management
#    build: ./AccManagement
#    restart: always
#    ports:
#      - "5004:80"
#    volumes:
#      - .:/acc-management
#    depends_on: 
#      - db
# 
```
Open your terminal and navigate to the `src` directory.<br>
Fire up the database container by running the command below:<br> `~$ docker-compose up -d`<br><br>
I deliberately included the `.env` file to keep the db password.<br>

####  Identity server migrations
On your terminal navigate to IdentityServer directory and run the following commands:
```
~$  dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
```
```
~$ dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
```
```
~$  dotnet ef migrations add InitialDbMigration -c AppDbContext -o Data/Migrations
```

```
~$  dotnet ef database update -c PersistedGrantDbContext
```
```
~$  dotnet ef database update -c ConfigurationDbContext
```
```
~$ dotnet ef database update -c AppDbContext
```

####  Account management migrations
On your terminal navigate to AccManagement directory `~$ cd ../AccManagement` and run the following commands:
```
~$  dotnet ef migrations add InitialDbMigration -c AppDbContext -o Data/Migrations
```
```
~$ dotnet ef database update -c AppDbContext
```

### Running the applications
Navigate to each of the three folders on terminal and execute `~$ dotnet run`<br>
The applications will run as follows:<br>
>IdentityServer on `https://localhost:5001/` <br>
>AccManagement on `https://localhost:5005/` <br>
>StoreApi on `https://localhost:5003/swagger` <br>
