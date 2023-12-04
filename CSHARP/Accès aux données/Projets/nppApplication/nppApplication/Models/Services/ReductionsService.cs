
using Microsoft.EntityFrameworkCore;
using nppApplication.Models.Data;

namespace nppApplication.Models.Services;

public class ReductionsService
{
    private readonly NppContext _context;

    public ReductionsService(NppContext context)
    {
        _context = context;
    }

    public void AddReduction(Reduction entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Reductions.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Reduction> GetAllReductions()
    {
        return _context.Reductions.Include("Order").Include("Discount").ToList();
    }

    public Reduction GetReductionById(int id)
    {
        Reduction entity = _context.Reductions.FirstOrDefault(entity => entity.Id == id);

        return entity;
    }
    public void DeleteReduction(Reduction entity)
    {

        _context.Reductions.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateReduction(Reduction entity)
    {
        _context.Reductions.Update(entity);
        _context.SaveChanges();
    }

}



