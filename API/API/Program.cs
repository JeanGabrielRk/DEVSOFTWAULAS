//Testar as APIs
// - Rest Client - Extensão do VS Code
// - Postman
// - Insomnia

//MINIMAL APIs - C# 
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>();

produtos.Add(new Produto()
{
    Nome = "Notebook",
    Preco = 5000,
    Quantidade = 54
});
produtos.Add(new Produto()
{
    Nome = "Desktop",
    Preco = 3500,
    Quantidade = 150
});
produtos.Add(new Produto()
{
    Nome = "Monitor",
    Preco = 1200,
    Quantidade = 60
});
produtos.Add(new Produto()
{
    Nome = "Celular",
    Preco = 10000,
    Quantidade = 80
});

//EndPoints - Funcionalidades
//Request - Configurar a URL e o método/verbo HTTP
//Response - Retornar os dados (json/xml) 

app.MapGet("/", () => "API de produtos");

//GET: /produto/listar
app.MapGet("/produto/listar", () => 
{
    if(produtos.Count > 0)
    {
        return Results.Ok(produtos);
    }

    return Results.NotFound();
    
});

app.MapGet("/produto/buscar/{nome}", (string nome) => {

    foreach(Produto produtoCadastrado in produtos)
    {
        if(produtoCadastrado.Nome == nome)
        {
            return Results.Ok(produtoCadastrado);
        }
    }
    return Results.NotFound();

});

//GET: //produto/listar
app.MapPost("/produto/cadastrar", ([FromBody] Produto produto) => 
{
    //Adicionando dentro da lista
    produtos.Add(produto);
    return Results.Created("", produto);
});

app.MapDelete("/produto/remover", ([FromBody] Produto produto) => 
{

});

app.Run();
