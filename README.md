# eLocalize
 Library Task

# Functionalities 
 1- Add Book (Title , Quantity)
 2- Add Member (UserName)
 3- Borrows and Lends Books
 4- Get All (Books, Members) with Details and Delete
 5- Validates

# Technologies used in task
(ASP.Net Core MVC, Entity Framework (EF), LINQ, Bootstrap, jQuery and AJAX)

# Packages
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Mvc.NewtonsoftJson

-also check:
Bootstrap
jQuery

# To Install and Run
1- check and change ConnectionStrings of your database in appsettings.json
2- In package manager console make Default project Library.DAL and run 2 commands
    A. add-migration [name of migration]
    B. update-database
3- make sure when run project make Library.MVC default project