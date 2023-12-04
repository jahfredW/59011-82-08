
using nppApplication.Models.Data;

namespace nppApplication.Models.Services;

public class OrderLinesService
{
    private readonly NppContext _context;

    public OrderLinesService(NppContext context)
    {
        _context = context;
    }

    public void AddOrderLine(OrderLine entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.OrderLines.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<OrderLine> GetAllOrderLines()
    {
        return _context.OrderLines.ToList();
    }

    public OrderLine GetOrderLineById(int id)
    {
        OrderLine entity = _context.OrderLines.FirstOrDefault(entity => entity.Id == id);

        return entity;
    }
    public void DeleteOrderLine(OrderLine entity)
    {

        _context.OrderLines.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateOrderLine(OrderLine entity)
    {
        _context.OrderLines.Update(entity);
        _context.SaveChanges();
    }

}


