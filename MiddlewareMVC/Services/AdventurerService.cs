﻿using MiddlewareMVC.Repositories;

namespace MiddlewareMVC.Services
{
    public interface IAdventurerService
    {
        List<Adventurer> GetAllAdventurers();
        public bool AddAdventurer(Adventurer a);
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

        public bool AddAdventurer(Adventurer a)
        {
            //Add default name if not given
            if (String.IsNullOrWhiteSpace(a.Name)) { return false; }
                
            return _adventurerRepository.AddAdventurer(a);
        }
    }
}
