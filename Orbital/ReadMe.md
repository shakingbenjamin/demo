Intro:

To use this project you will need Core 3.2 on your local machine - this is a proof of concept/task not the finished article.
This can be hosted on Linux/Mc/Windows, using Kestrel.

How to:

To generate and seed the database (sqlite) then run, please execute the following commands
dotnet ef migration add initialcreate
dotnet ef database update
dotnet run
navigate to: https://localhost:5001/api/leaseschedule

Things included:

Solitary end point to show the output of a json file deserialised and unmuddled to make human readable
Resolver and Repositories injected
Database seeding at run time, from json file
DTOs doe easily understandable data


Things outstanding:

This was/is a 2ish hour project
DTOs to be improved upon, as stands they're what the tables are based on which isn't ideal.
Separation of concerns, Application and Identity Services away from the Startup.cs
XUnit would be used along with mocking to test the end points and resolver.
Authorization including JWTs
Mail service for email alerts, registration and password reset.
Different levels of access and ability. Always path of least access granted.
More API endpoints (parameter driven GET for example)
A more user friendly front end (this would be stored within the client directory)
Static files would be used so thst angular isn't serving the front end, kestrel does this
Dockerise the output so it'll run on anything provided it has docker