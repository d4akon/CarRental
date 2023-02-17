<div class="min-h-[20px] flex flex-col items-start gap-4 whitespace-pre-wrap">
   <div class="markdown prose w-full break-words dark:prose-invert light">
      <h2>Project Overview</h2>
      <p>The Car Rental project is a web-based application that allows customers to rent cars. The system enables customers to choose a car, schedule a pick-up date, location and return date, location, also alows to generate invoice. The project is built using ASP.NET MVC framework and utilizes a SQL Server database to store information about customers, cars, reservations, locations and invoices.</p>
      <h2>Installation</h2>
      <ol>
         <li>Clone the project repository from GitHub and open it in Visual Studio.</li>
         <li>Open the Package Manager Console by going to Tools > NuGet Package Manager > Package Manager Console.</li>
         <li>Run the following command to install the Entity Framework package: Install-Package EntityFramework</li>
         <li>Run the following command to install the Entity Framework package: dotnet user-secrets set SeedUserPW Passw0rd</li>
         <li>Run the following command in the Package Manager Console to create the database: Update-Database</li>
         <li>The database will be created and seeded with sample data. You can check the tables in the SQL Server Object Explorer to verify that the database has been created successfully.</li>
         <li>Build the project and run it in the browser to verify that the application is working correctly.</li>
         <li>Test user creditials email: admin@rental.com password: Passw0rd.</li>
      </ol>
      With these steps, you should be able to install the Car Rental project on your local machine with a SQL Server database using Entity Framework.
      <h2>Project Structure</h2>
      <p>The project is structured into the following components:</p>
      <ol>
         <li>
            Controllers: Controllers manage user requests and interact with the database to retrieve or update data. The following controllers are included in the project:
            <ul>
               <li>HomeController: Manages the home page of the application.</li>
               <li>CarsController: Manages the car catalog and availability.</li>
               <li>ReservationsController: Manages the creation, editing, and cancellation of reservations.</li>
               <li>LocationsController: Manages the creation, editing, and deletion of locations.</li>
               <li>InvoicesController: Manages invoices generation and invoices history.</li>
            </ul>
         </li>
         <li>
            Models: Models represent the entities in the database and provide the data access layer for the application. The following models are included in the project:
            <ul>
               <li>Customer: Stores information about the customers, such as name, license number, email and phone number.</li>
               <li>Car: Stores information about the cars, such as brand, model, year, daily rate and availability.</li>
               <li>Reservation: Stores information about the reservations, such as the customer, car, pick-up and return dates and locations, total cost and status of payment.</li>
               <li>Location: Stores information about the Location, such as the name, adress and phone.</li>
               <li>Invoices: Stores information about the transactions, such as the reservation, status, amount, and date.</li>
            </ul>
         </li>
         <li>
            Views: Views provide the user interface for the application. The following views are included in the project:
            <ul>
               <li>Home/Index: Displays the home page of the application.</li>
               <li>Car/Index: Displays the car catalog, availability and reserve possibility.</li>
               <li>Reservation/Create: Allows customers to create a new reservation.</li>
               <li>Reservation/Index: Displays the reservations, status and generate invoice possibility.</li>
               <li>Invoices/Index: Displays the invoices history of the customer.</li>
            </ul>
         </li>
      </ol>
      <h2>Database Design</h2>
      <p>The project uses a SQL Server database to store information about customers, cars, reservations, invoices and locations. The database has the following tables:</p>
      <ol>
         <li>Customer: Stores information about the customers, such as name, license number, email and phone number.</li>
         <li>Car: Stores information about the cars, such as brand, model, year, daily rate and availability.</li>
         <li>Reservation: Stores information about the reservations, such as the customer, car, pick-up and return dates and locations, total cost and status of payment.</li>
         <li>Location: Stores information about the Location, such as the name, adress and phone.</li>
         <li>Invoices: Stores information about the transactions, such as the reservation, status, amount, and date.</li>
      </ol>
      <p>The database design ensures data integrity and supports the business rules of the car rental application.</p>
      <h2>Deployment</h2>
      <p>The Car Rental project can be deployed on a web server running IIS. The project can be published as a web deployment package and deployed to the server. The server must have the following prerequisites installed:</p>
      <ol>
         <li>.NET Framework 4.5 or later</li>
         <li>SQL Server Express LocalDB or higher</li>
         <li>Internet Information Services (IIS)</li>
      </ol>
      <h2>Conclusion</h2>
      <p>The Car Rental project is a web-based application that allows customers to rent cars. The application is built using the ASP.NET MVC framework and uses a SQL Server database to store information about customers, cars, reservations, invoices and locations. The project is well-structured and follows best practices for web application development.</p>
   </div>
</div>
