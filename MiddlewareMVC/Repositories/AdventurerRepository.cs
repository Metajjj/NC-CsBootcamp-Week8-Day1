using Microsoft.EntityFrameworkCore;

namespace MiddlewareMVC.Repositories
{
    public interface IAdventurerRepository
    {
        List<Adventurer> GetAllAdventurers();
        public bool AddAdventurer(Adventurer a);
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

        public bool AddAdventurer(Adventurer a)
        {
            _dbContext.Adventurers.Add(a);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
