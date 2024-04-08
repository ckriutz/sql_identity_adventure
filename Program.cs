// See https://aka.ms/new-console-template for more information

// create a static connection string.
// Notice how it's different than a standard connection string.
using Microsoft.Data.SqlClient;

// Lets make a list of 25 different cities to use for the query later.
List<string> usCities = new List<string> {"New York","Los Angeles","Chicago","Houston","Phoenix","Philadelphia","San Antonio","San Diego","Dallas","San Jose","Austin","Jacksonville","Fort Worth","Columbus","Charlotte","Indianapolis","Seattle","Denver","Washington, D.C.","Boston","El Paso","Nashville","Detroit","Portland","Las Vegas"};

// Also, since I didn't create the database to have an auto-incrementing ID, I'll generate a random ID for each city.
Random random = new Random();
int cityId = random.Next(1, 50000);

// Now, I'll randomly select a city from the list and generate a random population for the city.
string selectedCity = usCities[random.Next(0, usCities.Count)];
int randomPopulation = random.Next(100, 3500000);

// create a connection string to the Azure SQL Database
string connectionString = "Server=<SQL Server>,1433;Initial Catalog=<Database Name>;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";";

// create a new SqlConnection object
using SqlConnection connection = new SqlConnection(connectionString);

try
{
    connection.Open();
    Console.WriteLine("Connected to Azure SQL Database");
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

// create a new SqlCommand object
using SqlCommand command = connection.CreateCommand();
command.CommandText = $"INSERT INTO [dbo].[Cities] ([Id],[City],[Population]) VALUES({cityId},'{selectedCity}',{randomPopulation})";
command.ExecuteNonQuery();
Console.WriteLine("Inserted a row into the table");

connection.Close();

Console.WriteLine("Disconnected from Azure SQL Database");
Console.ReadLine();
