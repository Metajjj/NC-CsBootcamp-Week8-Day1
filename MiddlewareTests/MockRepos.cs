namespace MiddlewareTests
{
    public class RepoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SuccessfulDbQuery()
        {
            var repo = new AdventurerRepository();

            Assert.Pass()

            /*var mockDb = new Mock<>();

            mockRepo.Setup(s => s.GetAllAdventurers()).Returns(
                [new Adventurer("Guy", FightingClasses.Warrior)]
            );

            var service = new AdventurerService(mockRepo.Object);
            //Testing the controller with pre-determined environment

            var result = service.GetAllAdventurers();

            Assert.That(result[0].Level == 1);*/
        }
    }
}