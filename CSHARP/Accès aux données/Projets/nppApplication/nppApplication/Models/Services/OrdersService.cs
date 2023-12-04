
using nppApplication.Models.Data;

namespace nppApplication.Models.Services;

public class OrdersService
{
    private readonly NppContext _context;

    public OrdersService(NppContext context)
    {
        _context = context;
    }

    public void AddOrder(Order entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Orders.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }

    public Order GetOrderById(int id)
    {
        Order entity = _context.Orders.FirstOrDefault(entity => entity.Id == id);

        return entity;
    }
    public void DeleteOrder(Order entity)
    {

        _context.Orders.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateOrder(Order entity)
    {
        _context.Orders.Update(entity);
        _context.SaveChanges();
    }

}

