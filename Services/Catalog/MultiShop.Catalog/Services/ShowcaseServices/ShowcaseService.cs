using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ShowcaseDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ShowcaseServices
{
    public class ShowcaseService : IShowcaseService
    {
        private readonly IMongoCollection<Showcase> _showcaseCollection;
        private readonly IMapper _mapper;

        public ShowcaseService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _showcaseCollection = database.GetCollection<Showcase>(_databaseSettings.ShowcaseCollectionName);
            _mapper = mapper;
        }

        public Task ChangeShowcaseStatusToFalseAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task ChangeShowcaseStatusToTrueAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateShowcaseAsync(CreateShowcaseDto createShowcaseDto)
        {
            var value = _mapper.Map<Showcase>(createShowcaseDto);
            await _showcaseCollection.InsertOneAsync(value);
        }

        public async Task DeleteShowcaseAsync(string id)
        {
            await _showcaseCollection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<List<ResultShowcaseDto>> GetAllShowcasesAsync()
        {
            var values = _showcaseCollection.Find(p => true).ToListAsync();
            return _mapper.Map<List<ResultShowcaseDto>>(await values);
        }

        public async Task<GetShowcaseByIdDto> GetShowcaseByIdAsync(string id)
        {
            var values = await _showcaseCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetShowcaseByIdDto>(values);
        }

        public async Task UpdateShowcaseAsync(UpdateShowcaseDto updateShowcaseDto)
        {
            var values = _mapper.Map<Showcase>(updateShowcaseDto);
            await _showcaseCollection.FindOneAndReplaceAsync(p => p.Id == updateShowcaseDto.Id, values);

        }
    }
}
