namespace MiddlewareMVC
{

    public enum FightingClasses
    {
        Warrior, Rogue, Mage
    }

    public class Adventurer
    {
        public int Id { get; set; }
        //public static int IdCnt = 0;
        public string Name { get; set; }
        public FightingClasses FightingClass { get; set; }
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;

        public Adventurer(string name, FightingClasses fightingClass)
        {
            Name = name; FightingClass= fightingClass;
        }
    }
}
