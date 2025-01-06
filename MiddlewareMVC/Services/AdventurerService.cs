using MiddlewareMVC.Repositories;

namespace MiddlewareMVC.Services
{
    public class AdventurerService
    {
        private AdventurerRepository _adventurerRepository;

        public AdventurerService(AdventurerRepository adventurerRepository)
        {
            _adventurerRepository = adventurerRepository;
        }

        public List<Adventurer> GetAllAdventurers()
        {
            return _adventurerRepository.GetAllAdventurers();
        }
    }
}
