using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings, IMongoCollection<Category> categoryCollection)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
            _categoryCollection = categoryCollection;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productCollection.InsertOneAsync(_mapper.Map<Product>(createProductDto));
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(p => p.Id == id);        
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var values = await _productCollection.Find(p => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string id)
        {
            var values = await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductByIdDto>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var values = await _productCollection.Find(p => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();

            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);

        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(p => p.Id == updateProductDto.Id, values);
        }
    }
}
