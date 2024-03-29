using Microsoft.AspNetCore.Mvc;
using pizzastore.itf.pizzarepository;
using pizzastore.model.pizza;

namespace pizzastore.controller.pizza;
[ApiController]
[Route("/v1/api/pizzastore")]
class PizzaController : ControllerBase {

    private readonly IPizza _pizza;
    public PizzaController(IPizza pizza) {
        this._pizza = pizza;
    }

    [HttpGet]
    public IActionResult Get() {
        return Ok(_pizza.list());
    }

    [HttpPost]
    public IActionResult Post(Pizza pizza) {
        var pizzaInserida =  _pizza.add(pizza);
        return Ok($"Inserido com sucesso a pizza {pizzaInserida.nome} !");
    }

    [HttpDelete]
    public IActionResult Delete(Pizza pizza) {
        _pizza.delete(pizza);
        return Ok("Deletado com Sucesso!");
    }

    [HttpPut]
    public IActionResult Put(Pizza pizza) {
        _pizza.atualizar(pizza);
        return Ok("Atualizado com sucesso!");
    }
}