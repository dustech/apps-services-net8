// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Northwind.Models;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();

var configuration = builder.Build();
var mySecret = configuration["ConnectionStrings:NorthWind"];

DbContextOptionsBuilder<NorthwindDb> options = new();
options.UseNpgsql(mySecret);
using (NorthwindDb db = new(options.Options))
{
    var categories = db.Categories.Select(c =>
        new { c.CategoryId, c.CategoryName, c.Description });
    var json = JsonSerializer.Serialize(categories);
    Console.WriteLine(json);
}


Console.WriteLine("Hello, World!");