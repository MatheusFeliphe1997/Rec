using Microsoft.EntityFrameworkCore;
using RecMatheus.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();




POST: http://localhost:5154/pages/aluno/cadastrar
app.MapPost("/pages/aluno/cadastrar", ([FromBody] Aluno aluno,
    [FromServices] AppDataContext ctx) =>
{
    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created("",aluno);
});

//GET: http://localhost:5154/pages/aluno/listar
app.MapGet("/pages/aluno/listar", ([FromServices] AppDataContext ctx) =>
{
    return Results.Ok(ctx.Alunos.ToList());
});

//POST: http://localhost:5154/pages/imc/cadastrar
app.MapPost("/pages/imc/cadastrar", ([FromBody] Imc imc,
    [FromServices] AppDataContext ctx) =>
{
    Aluno? aluno = ctx.Alunos.Find(imc.AlunoId);
    if (aluno == null)
    {
        return Results.NotFound("Aluno não encontrada");
    }

        imc.Valor = imc.Peso / (imc.Altura * imc.Altura);
    
        if (imc.Valor < 18.5)
        {
            return Results.BadRequest("Abaixo do peso");
        }
        if (imc.Valor >= 18.5 && imc.Valor < 24.9)
        {
            return Results.BadRequest("Peso normal");
        }
        if (imc.Valor >= 25 && imc.Valor < 29.9)
        {
            return Results.BadRequest("Sobrepeso");
        }
        if (imc.Valor >= 30 && imc.Valor < 34.9)
        {
            return Results.BadRequest("Obesidade grau 1");
        }
        if (imc.Valor >= 35 && imc.Valor < 39.9)
        {
            return Results.BadRequest("Obesidade grau 2");
        }
        if (imc.Valor >= 40)
        {
            return Results.BadRequest("Obesidade grau 3");
        }
        else
        {
            return Results.BadRequest("Erro");
        }
    aluno.Valor = imc.Valor;
    ctx.Imcs.Add(imc);
    ctx.SaveChanges();
    return Results.Created("", imc);
});

//GET: http://localhost:5154/pages/imc/listar
app.MapGet("/pages/imc/listar", ([FromServices] AppDataContext ctx) =>
{
    return Results.Ok(ctx.Imcs.Include(x => x.Aluno).ToList());
});

//GET: http://localhost:5154/pages/imc/listar/1
app.MapGet("/pages/imc/listar/{id}", ([FromServices] AppDataContext ctx, int id) =>
{
    return Results.Ok(ctx.Imcs.Include(x => x.Aluno).FirstOrDefault(x => x.Id == id));
});

//alterar imc por id
//PUT: http://localhost:5154/pages/imc/alterar/1
app.MapPut("/pages/imc/alterar/{id}", ([FromBody] Imc imc, [FromServices] AppDataContext ctx, int id) =>
{

    imcBanco.Peso = imc.Peso;
    imcBanco.Altura = imc.Altura;
    imcBanco.Valor = imc.Peso / (imc.Altura * imc.Altura);
    ctx.SaveChanges();
    return Results.Ok(imcBanco);
});



app.UseCors("Acesso Total");
app.Run();
