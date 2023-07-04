using EFCore.Shared;
// See https://aka.ms/new-console-template for more information
WriteLine("Hello, World!");

Northwind db = new();
WriteLine($" Nom du provider: {db.Database.ProviderName}");

GetCategories();