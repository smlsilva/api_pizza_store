using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("AppDb"));
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var sabores = new List<Pizza> {
    new Pizza { id = 1, nome = "Calabresa" },
    new Pizza { id = 2, nome = "Brócolis"  },
    new Pizza { id = 3, nome = "Frango"  },
    new Pizza { id = 4, nome = "Catupiry"  },
    new Pizza { id = 5, nome = "Peito de Peru"  }
};

app.MapGet("/cardapio", () => { 
    return sabores;
});

app.MapGet("/cardapio/{id}", (int id) => { 
    var sabor = sabores.Find(sabor => sabor.id == id);

    if(sabor is null) {
        return Results.NotFound("Nenhum Resultado foi encontrado!");
    }

    return Results.Ok(sabor);
})
.WithName("Pegando sabor especifico")
.RequireAuthorization();

app.MapPost("/cardapio", (Pizza pizza) => {
    sabores.Add(pizza);
    return sabores;
});

app.MapPut("/cardapio/{id}", (Pizza updateCardapio, int id) => {
    var sabor = sabores.Find(sabor => sabor.id == id);

    if(sabor is null) {
        return Results.NotFound("Nenhum Resultado foi encontrado!");
    }

    sabor.nome = updateCardapio.nome;

    return Results.Ok(sabor);
});

app.MapDelete("/cardapio/{id}", (int id) => { 
    var sabor = sabores.Find(sabor => sabor.id == id);

    if(sabor is null) {
        return Results.NotFound("Nenhum Resultado foi encontrado!");
    }

    sabores.Remove(sabor);

    return Results.Ok(sabor);
});

app.Run();

class Pizza {

    public int id { get; set; }

    public required string nome { get; set; }
}