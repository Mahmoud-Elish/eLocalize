# eLocalize
 Library Task

# Functionalities 
 1- Add Book (Title , Quantity) <br />
 2- Add Member (UserName) <br />
 3- Borrows and Lends Books <br />
 4- Get All (Books, Members) with Details and Delete <br />
 5- Validates

# Technologies used in task
(ASP.Net Core MVC, Entity Framework (EF), LINQ, Bootstrap, jQuery and AJAX)

# Packages
Microsoft.EntityFrameworkCore <br />
Microsoft.EntityFrameworkCore.SqlServer <br />
Microsoft.EntityFrameworkCore.Tools <br />
Microsoft.AspNetCore.Mvc.NewtonsoftJson <br />

-also check: <br />
Bootstrap <br />
jQuery

# To Install and Run
1- check and change ConnectionStrings of your database in appsettings.json <br />
2- In package manager console make Default project Library.DAL and run 2 commands <br />
    A. add-migration [name of migration] <br />
    B. update-database <br />
3- make sure when run project make Library.MVC default project <br />