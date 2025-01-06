using Microsoft.AspNetCore.Mvc;

namespace MiddlewareTests
{
    public class ServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSuccessfulRepo()
        {

            var mockRepo = new Mock<IAdventurerRepository>();

            mockRepo.Setup(s => s.GetAllAdventurers()).Returns(
                [new Adventurer("Guy", FightingClasses.Warrior)]
            );

            var service = new AdventurerService(mockRepo.Object);
            //Testing the controller with pre-determined environment

            var result = service.GetAllAdventurers();

            Assert.That(result[0].Level == 1);

        }


        [Test]
        public void TestSuccessfulAdd()
        {
            var mockRepo = new Mock<IAdventurerRepository>();

            mockRepo.Setup(s => s.AddAdventurer(
                It.IsAny<Adventurer>()
                ) 
            ).Returns( true );

            var service = new AdventurerService(mockRepo.Object);

            var res = service.AddAdventurer(new Adventurer("a", FightingClasses.Rogue));

            Assert.That(res);
        }
    }
}