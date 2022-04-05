# Twilio-ASP.NET-5-API
using Twilio in ASP.NET 5 API with Clean Code Architecture



Once the Packages are done restoring, open up the appsettings.json of both the API and MVC Projects. Make sure that you add in valid Connection strings here. Here is how I set it up for my database server (MSSQL).

"ConnectionStrings": {
  "ApplicationConnection": "Data Source=LAPTOP-7CS9KHVQ;Initial Catalog=StoreManager;Integrated Security=True;MultipleActiveResultSets=True",
  "IdentityConnection": "Data Source=LAPTOP-7CS9KHVQ;Initial Catalog=StoreManager;Integrated Security=True;MultipleActiveResultSets=True"
},
Once the Connection Strings are updated, let’s add the Migrations and Update the Database. Open up package Manager Console and Set the Startup project as the API Project. Set the Default Project as the Infrastructure project (See the red highlighted area in the screenshot below). Run the following commands.

add-migration initial2 -context ApplicationDbContext
add-migration initialIdentity2 -context IdentityContext



Note that I have already added the Migrations to the Solution Template, which means you really don’t have to do the above mentioned step to generate the Migrations. But in case you lose the Migration file, use the above commands to regenrate them.

With the Migrations ready, let’s update the database now.

update-database -context IdentityContext
update-database -context ApplicationDbContext



Default Roles & Credentials
As soon you build and run your Awesome Application, default users and roles get added to the database.

Default Roles are as follows.

SuperAdmin
Admin
Moderator
Basic
Here are the credentials for the default users.

Email – superadmin@gmail.com / Password – 123Pa$$word!
Email – basic@gmail.com / Password – 123Pa$$word!
