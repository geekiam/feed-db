
## Geekiam Feed Processing Database

The Geekiam Feed Processing Database is a database that is used to store the feed information and posts that are 
processed by the Geekiam collective of Feed Processing Services.

The intention of the database is that although the schema may be simple and contrived in its first few iterations
the complexity and size of the database will grow as the Feed Processing Services grow in number and complexity.

A number of the Feed Processing Services will be developed in in Dotnet C# However, all services may intially at least 
point to the central database for their data storage and processing needs.  The data stored in this database 
may be ephemeral in nature and may be deleted and recreated at any time.

The database will be developed using the Entity Framework Core and will be developed using the Code First approach.

### Database Schema




### Database Migrations
To generate a migration script we typically open a new terminal change into the directory Persistence project
`cd src/Persistence` and then run the following command:



```bash
## Generate a migration script
## N.B.  provide a meaningful name for the migration in this exaple we use the name initial
dotnet ef  migrations add initial  --output-dir Persistence/Migrations
```

