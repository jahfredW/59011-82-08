using Microsoft.EntityFrameworkCore.Query.Internal;
using nppApplication.Models.Data;




namespace nppApplication.Models.Services
{




    public class CategoryService
    {
        private readonly nppContext _context;

        public CategoryService(nppContext context)
        {
            _context = context;
        }

        public void AddCategory(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategorys()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            Category entity = _context.Categories.FirstOrDefault(entity => entity.Id == id);

            return entity;
        }
        public void DeleteCategory(Category entity)
        {

            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();
        }

    }


}
