# Geekiam Feeds Database

The database is designed for the processing and updating the Geekiam feeds the database itself is not designed to be 
the backend for the website or any of the applications within the Geekiam public facing stack of applications. 

It's primary purpose is to process and update the number of feeds form sources that geekiam is aware 
on schedule basis.   The intention for this specific project is that it can be reused by the Geekiam Administration API
which are for the most part only Back End related services.

The Primary target Database we are targeting for this Postgres and we primarily use Entity Framework Core to provide 
an abstraction layer and migrations.

