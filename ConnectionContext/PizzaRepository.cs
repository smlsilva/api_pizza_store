using pizzastore.itf.pizzarepository;
using pizzastore.model.pizza;
namespace pizzastore.repository.pizza;
public class PizzaRepository : IPizza
{
    Connection _context = new Connection();
    public Pizza add(Pizza pizza)
    {
        _context.pizzaModel.Add(pizza);
        _context.SaveChanges();
        return pizza;
    }

    public void atualizar(Pizza pizza)
    {
        _context.pizzaModel.Update(pizza);
        _context.SaveChanges();
    }

    public void delete(Pizza pizza)
    {
        _context.pizzaModel.Remove(pizza);
        _context.SaveChanges();
    }

    public List<Pizza> list()
    {
        return _context.pizzaModel.ToList();
    }
}