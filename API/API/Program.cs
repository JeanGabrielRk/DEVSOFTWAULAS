//Testar as APIs
// - Rest Client - Extensão do VS Code
// - Postman
// - Insomnia

//MINIMAL APIs - C# 
using API.Models;

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

//GET: //produto/listar
app.MapGet("/produto/listar", () => 
{
    return Results.Ok(produtos);
});

//GET: //produto/listar
app.MapPost("/produto/cadastrar/{nome}", (string nome) => 
{

    //Criar o objeto e preencher
    Produto produto = new Produto();
    produto.Nome = nome;
    //Adicionando dentro da lista
    produtos.Add(produto);
    return Results.Ok(produtos);
});

//Criar uma funcionalidade para receber informações
// - Receber informações pela URL da requisição
// - Receber informações pelo corpo da requisição

app.Run();

// C# - Utilização dos gets e sets
/*Produto produto = new Produto();
produto.Preco = 5;
produto.
Console.WriteLine("Preço: " + produto.Preco);

// JAVA - Utilização dos gets e sets
/*Produto produto = new Produto();
produto.setPreco(5);
Console.WriteLine("Preço: " + produto.getPreco());*/