namespace pizzastore.Endpoints;
using pizzastore.pizza;
public static class PizzaEndpoints {

    public static void RegisterPizzaEndpoints (this IEndpointRouteBuilder endpoints) {
        
        var sabores = new List<Pizza> {
            new Pizza { id = 1, nome = "Calabresa" },
            new Pizza { id = 2, nome = "Brócolis"  },
            new Pizza { id = 3, nome = "Frango"  },
            new Pizza { id = 4, nome = "Catupiry"  },
            new Pizza { id = 5, nome = "Peito de Peru"  }
        };

        endpoints.MapGet("/cardapio", () => { 
            return sabores;
        })
        .WithName("Todos os Sabores");

        endpoints.MapGet("/cardapio/{id}", (int id) => { 
            var sabor = sabores.Find(sabor => sabor.id == id);

            if(sabor is null) {
                return Results.NotFound("Nenhum Resultado foi encontrado!");
            }

            return Results.Ok(sabor);
        })
        .WithName("Pegando sabor especifico")
        .RequireAuthorization();

        endpoints.MapPost("/cardapio", (Pizza pizza) => {
            sabores.Add(pizza);
            return Results.Created("",sabores);
        })
        .WithName("Inserindo um novo sabor de pizza")
        .RequireAuthorization();

        endpoints.MapPut("/cardapio/{id}", (Pizza updateCardapio, int id) => {
            var sabor = sabores.Find(sabor => sabor.id == id);

            if(sabor is null) {
                return Results.NotFound("Nenhum Resultado foi encontrado!");
            }

            sabor.nome = updateCardapio.nome;

            return Results.Ok(sabor);
        })
        .WithName("Atualizando sabor específico")
        .RequireAuthorization();

        endpoints.MapDelete("/cardapio/{id}", (int id) => { 
            var sabor = sabores.Find(sabor => sabor.id == id);

            if(sabor is null) {
                return Results.NotFound("Nenhum Resultado foi encontrado!");
            }

            sabores.Remove(sabor);

            return Results.Ok(sabor);
        })
        .WithName("Deletar um sabor do cardápio")
        .RequireAuthorization();
    }
}