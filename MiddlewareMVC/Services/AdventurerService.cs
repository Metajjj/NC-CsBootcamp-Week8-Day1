using MiddlewareMVC.Repositories;

namespace MiddlewareMVC.Services
{
    public interface IAdventurerService
    {
        List<Adventurer> GetAllAdventurers();
    }

    public class AdventurerService : IAdventurerService
    {
        private IAdventurerRepository _adventurerRepository;

        public AdventurerService(IAdventurerRepository adventurerRepository)
        {
            _adventurerRepository = adventurerRepository;
        }

        public List<Adventurer> GetAllAdventurers()
        {
            return _adventurerRepository.GetAllAdventurers();
        }
    }
}
