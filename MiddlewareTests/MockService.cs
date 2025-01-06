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
    }
}