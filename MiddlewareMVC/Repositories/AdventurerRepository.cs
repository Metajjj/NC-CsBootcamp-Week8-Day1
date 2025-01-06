using Microsoft.EntityFrameworkCore;

namespace MiddlewareMVC.Repositories
{
    public interface IAdventurerRepository
    {
        List<Adventurer> GetAllAdventurers();
        public bool AddAdventurer(Adventurer a);
        public bool PatchAdventurer(int id, Adventurer a);
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

        public Adventurer? GetAdventurer(int id)
        {
            foreach (Adventurer a in GetAllAdventurers())
            {
                if (a.Id == id) return a;
            }

            return null;
        }

        public bool PatchAdventurer(int id, Adventurer a)
        {
            Adventurer? aToChange = GetAdventurer(id);

            if (aToChange is null) { return false; }

            
            if (a.Level == 0 && a.XP == 0)
            {
                return false;
            }
            else if (a.Level == 0 && a.XP > 0)
            {
                aToChange.GainXp(a.XP);
/*                a.Name = aToChange.Name;
                a.Level = aToChange.Level;
                a.FightingClass = aToChange.FightingClass;
                a.Id = aToChange.Id;*/
            }
            else if (a.Level > 0 && a.XP == 0)
            {
                aToChange.Level = a.Level;
/*                a.Name = aToChange.Name;
                a.XP = aToChange.XP;
                a.FightingClass = aToChange.FightingClass;
                a.Id = aToChange.Id;*/
            }
            else if (a.Level > 0 && a.XP > 0)
            {
                return false;
            }

            /*            _dbContext.Adventurers.Remove(aToChange);
                        _dbContext.Add(a);*/
            _dbContext.Adventurers.Update(aToChange);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
