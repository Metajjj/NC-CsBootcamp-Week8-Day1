using Microsoft.EntityFrameworkCore;

namespace MiddlewareMVC.Repositories
{
    public class AdventurerRepository
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
