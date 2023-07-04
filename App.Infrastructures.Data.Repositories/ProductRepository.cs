using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Products;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IAuctionRepository _auctionRepository;

        public ProductRepository(AppDbContext context, IAuctionRepository auctionRepository)
        {
            _context = context;
            _auctionRepository = auctionRepository;
        }

        public async Task<int> CreateProduct(AddProductInputDto inputDto, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = inputDto.Name,
                CategoryId = inputDto.CategoryId,
                BrandId = inputDto.BrandId,
                StoreId = inputDto.StoreId,
                Weight = inputDto.Weight,
                Description = inputDto.Description,
                ModelId = inputDto.ModelId,
                Price = inputDto.Price,
                IsActive = true
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }

        public async Task DeleteProduct(int id, CancellationToken cancellationToken)
        {
            Product? product = await _context.Products.FindAsync(id);

            product.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> ProductsCount(CancellationToken cancellationToken)
        {
            var count = await _context.Products.AsNoTracking().CountAsync(cancellationToken);

            return count;
        }

        public async Task<List<ProductOutputDto>> GetAllProducts(string? search, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Select(p => new ProductOutputDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                StoreId = p.StoreId,
                Weight = p.Weight,
                Description = p.Description,
                ModelId = p.ModelId,
                Price = p.Price,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted
            }).Where(p => p.IsActive == true && p.IsDeleted == false).ToListAsync(cancellationToken);

            if (string.IsNullOrEmpty(search))
            {
                return products;
            }
            else
            {
                products = products.Where(p => p.Name.Contains(search)).ToList();

                return products;
            }
        }

        public async Task<List<ProductOutputDto>> GetAllInActiveProducts(CancellationToken cancellationToken)
        {
            var products = await _context.Products.Where(p => p.IsActive == false).ToListAsync(cancellationToken);

            var inActiveProducts = products.Select(p => new ProductOutputDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                StoreId = p.StoreId,
                Weight = p.Weight,
                Description = p.Description,
                ModelId = p.ModelId,
                Price = p.Price,
                IsActive = p.IsActive
            }).ToList();

            return inActiveProducts;
        }

        public async Task<ProductOutputDto> GetProductBy(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(p => p.Store)
                .Include(p => p.Auctions)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            ProductOutputDto productDto = new()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                StoreId = product.StoreId,
                Weight = product.Weight,
                Description = product.Description,
                ModelId = product.ModelId,
                Price = product.Price,
                IsActive = product.IsActive,
                Auctions = product.Auctions,
                Store = product.Store
            };

            return productDto;
        }

        public async Task UpdateProduct(EditProductInputDto product, CancellationToken cancellationToken)
        {
            var productToUpdate = await _context.Products.Where(p => p.Id == product.Id)
                .FirstOrDefaultAsync(cancellationToken);

            productToUpdate.Name = product.Name;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.StoreId = product.StoreId;
            productToUpdate.Weight = product.Weight;
            productToUpdate.Description = product.Description;
            productToUpdate.ModelId = product.ModelId;
            productToUpdate.Price = product.Price;
            productToUpdate.IsActive = product.IsActive;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductOutputDto>> GetAllInAuctionProducts(CancellationToken cancellationToken)
        {
            var runningAuctions = await _auctionRepository.GetAllRunningAuctions(cancellationToken);

            var productIds = runningAuctions.Select(a => a.ProductId).ToList();

            var products = await _context.Products
                .Include(p => p.Auctions)
                .Include(p => p.ProductPhotos)
                .Where(p => p.IsActive && !p.IsDeleted && productIds.Contains(p.Id))
                .Select(p => new ProductOutputDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    StoreId = p.StoreId,
                    Weight = p.Weight,
                    Description = p.Description,
                    ModelId = p.ModelId,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    IsDeleted = p.IsDeleted,
                    Brand = p.Brand,
                    Category = p.Category,
                    Store = p.Store,
                    ProductPhotos = p.ProductPhotos
                }).ToListAsync(cancellationToken);

            return products;
        }

        public async Task<ProductOutputDto> GetProductDetails(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(p => p.Auctions)
                .Include(p => p.ProductPhotos)
                .Where(p => p.IsActive && !p.IsDeleted && p.Id == id)
                .Select(p => new ProductOutputDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    StoreId = p.StoreId,
                    Auctions = p.Auctions,
                    Weight = p.Weight,
                    Description = p.Description,
                    ModelId = p.ModelId,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    IsDeleted = p.IsDeleted,
                    Brand = p.Brand,
                    Category = p.Category,
                    Store = p.Store,
                    ProductPhotos = p.ProductPhotos
                }).SingleOrDefaultAsync(cancellationToken);

            return product;
        }

        public async Task UpdateProductPrice(int productId, int newPrice, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product != null)
            {
                product.Price = newPrice;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<ProductOutputDto>> GetRandomProducts(CancellationToken cancellationToken)
        {
            var randomProducts = await _context.Products
                .Include(o => o.ProductPhotos)
                .Include(o => o.Category)
                .Include(o => o.Store)
                .Where(p => p.IsActive && !p.IsDeleted && !p.Auctions.Any())
                .OrderBy(p => Guid.NewGuid())
                .Take(4)
                .ToListAsync(cancellationToken);

            var randomProductDtos = randomProducts.Select(p => new ProductOutputDto
            {
                Id = p.Id,
                Name = p.Name ?? string.Empty,
                Price = p.Price,
                ProductPhotos = p.ProductPhotos,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                StoreId = p.StoreId,
                Weight = p.Weight,
                Description = p.Description ?? string.Empty,
                ModelId = p.ModelId,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Auctions = p.Auctions,
                Category = p.Category,
                Store = p.Store
            }).ToList();

            return randomProductDtos;
        }

        public async Task<List<ProductOutputDto>> GetProductsByCategory(int catetoryId, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Auctions)
                .Include(p => p.ProductPhotos)
                .Where(p => p.CategoryId == catetoryId)
                .ToListAsync(cancellationToken);

            return products.Select(p => new ProductOutputDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                StoreId = p.StoreId,
                Weight = p.Weight,
                Description = p.Description,
                ModelId = p.ModelId,
                Price = p.Price,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Auctions = p.Auctions,
                Brand = p.Brand,
                Category = p.Category,
                Store = p.Store,
                ProductPhotos = p.ProductPhotos
            }).ToList();
        }

        public async Task<List<ProductOutputDto>> FilterProductsSearch(string searchPhrase, CancellationToken cancellationToken)
        {
            var filteredProducts = await _context.Products
                .Where(p => p.Name.ToLower().Contains(searchPhrase))
                .ToListAsync(cancellationToken);

            var productDtos = filteredProducts.Select(p => new ProductOutputDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                StoreId = p.StoreId,
                Weight = p.Weight,
                Description = p.Description,
                ModelId = p.ModelId,
                Price = p.Price,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Auctions = p.Auctions,
                Brand = p.Brand,
                Category = p.Category,
                Store = p.Store,
                ProductPhotos = p.ProductPhotos
            }).ToList();

            return productDtos;
        }
    }
}
