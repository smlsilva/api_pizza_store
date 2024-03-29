using pizzastore.model.pizza;
namespace pizzastore.itf.pizzarepository;

public interface IPizza {
    // POST
    public Pizza add(Pizza pizza);
    // GET ALL
    public List<Pizza> list();
    // DELETE
    void delete(Pizza pizza);
    // ATUALIZAR
    void atualizar(Pizza pizza);
}