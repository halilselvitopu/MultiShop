using MultiShop.Catalog.Dtos.ShowcaseDtos;

namespace MultiShop.Catalog.Services.ShowcaseServices
{
    public interface IShowcaseService
    {
        Task<List<ResultShowcaseDto>> GetAllShowcasesAsync();
        Task CreateShowcaseAsync(CreateShowcaseDto createShowcaseDto);
        Task UpdateShowcaseAsync(UpdateShowcaseDto updateShowcaseDto);
        Task DeleteShowcaseAsync(string id);
        Task<GetShowcaseByIdDto> GetShowcaseByIdAsync(string id);
        Task ChangeShowcaseStatusToTrueAsync(string id);
        Task ChangeShowcaseStatusToFalseAsync(string id);
    }
}
