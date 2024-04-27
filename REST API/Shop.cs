using Microsoft.EntityFrameworkCore;
//Широков Кирилл 3пк1
namespace REST_API
{
    public class Seller
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public List<Buyer>? Buyers { get; set; }
    }

    public class Buyer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfPurchase { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public double? Price { get; set; }

        public List<Buyer>? Buyers { get; set; }
    }

    public class ShopContext : DbContext
    {
        public ShopContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
          optionsBuilder.UseSqlServer(
        "Server=DESKTOP-BNHKUSL;Database=Shop_1;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
        );

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public interface IShopService
    {       
        IEnumerable<Product> GetProducts();
        IEnumerable<Buyer> GetBuyers();
        IEnumerable<Seller> GetSellers();

        Task AddProduct(Product newProduct);
        Task AddBuyer(Buyer newBuyer);
        Task AddSeller(Seller newSeller);

        Task UpdateProduct(Guid id, Product updatedProduct);
        Task UpdateBuyer(Guid id, Buyer updatedBuyer);
        Task UpdateSeller(Guid id, Seller updatedSeller);

        Task DeleteProduct(Guid id);
        Task DeleteBuyer(Guid id);
        Task DeleteSeller(Guid id);
    }

    public class ShopService: IShopService
    {
        private ShopContext _context;
        public ShopService()
        {
            _context = new ShopContext();
        }

        public async Task AddProduct(Product newProduct) // Добавление
        {
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task AddBuyer(Buyer newBuyer)
        {
            _context.Buyers.Add(newBuyer);
            await _context.SaveChangesAsync();
        }

        public async Task AddSeller(Seller newSeller)
        {
            _context.Sellers.Add(newSeller);
            await _context.SaveChangesAsync();
        }


        public IEnumerable<Product> GetProducts() =>
            _context.Products.AsEnumerable();

        public IEnumerable<Buyer> GetBuyers() =>
            _context.Buyers.AsEnumerable();

        public IEnumerable<Seller> GetSellers() =>
            _context.Sellers.AsEnumerable();


        public async Task UpdateProduct(Guid id, Product updatedProduct)//обновление
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBuyer(Guid id, Buyer updatedBuyer)
        {
            var existingBuyer = await _context.Buyers.FindAsync(id);
            if (existingBuyer != null)
            {
                existingBuyer.Name = updatedBuyer.Name;
                existingBuyer.Surname = updatedBuyer.Surname;
                existingBuyer.DateOfPurchase = updatedBuyer.DateOfPurchase;

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateSeller(Guid id, Seller updatedSeller)
        {
            var existingSeller = await _context.Sellers.FindAsync(id);
            if (existingSeller != null)
            {
                existingSeller.Name = updatedSeller.Name;
                existingSeller.Surname = updatedSeller.Surname;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(Guid id) // Удаление 
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBuyer(Guid id)
        {
            var existingBuyer = await _context.Buyers.FindAsync(id);
            if (existingBuyer != null)
            {
                _context.Buyers.Remove(existingBuyer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSeller(Guid id)
        {
            var existingSeller = await _context.Sellers.FindAsync(id);
            if (existingSeller != null)
            {
                _context.Sellers.Remove(existingSeller);
                await _context.SaveChangesAsync();
            }
        }
    }
}