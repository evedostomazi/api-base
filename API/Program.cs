using API.Configuracoes;
using Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentidadeUsuario();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddJwtConfiguracoes();

builder.Services.AddRegisterServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var urlDev = "https://dominiodocliente.com.br";
//var urlHML = "https://dominiodocliente2.com.br";
//var urlPROD = "https://dominiodocliente3.com.br";

//app.UseCors(b => b.WithOrigins(urlDev, urlHML, urlPROD));

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
