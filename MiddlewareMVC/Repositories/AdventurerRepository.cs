using Microsoft.EntityFrameworkCore;

namespace MiddlewareMVC.Repositories
{
    public interface IAdventurerRepository
    {
        List<Adventurer> GetAllAdventurers();
    }

    public class AdventurerRepository : IAdventurerRepository
    {
        private AdventurerDbContext _dbContext;

        public AdventurerRepository(AdventurerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Adventurer> GetAllAdventurers()
        {
            return _dbContext.Adventurers.ToList();
        }
    }
}
