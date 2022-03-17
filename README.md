# TaskTracker_API_3-tier_arch

the PostgreSQL is used for DBMS.
I used a postgres container in Docker.

At first, for launching the project it is needed to run the postgres container.
Then file "appsettings.json" have to be changed for own connection string configurations.
If it is necessary add migrations by entering command "add-migration migration_name".
Next step - open Package Manager Console on VS and enter command "update-database".
So, the database will be created.

Launch the application.
