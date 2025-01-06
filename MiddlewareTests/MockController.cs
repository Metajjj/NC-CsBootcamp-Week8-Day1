global using MiddlewareMVC;
global using MiddlewareMVC.Services;
global using MiddlewareMVC.Repositories;
global using MiddlewareMVC.Controllers;

global using Moq;
global using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareTests
{
    public class ControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1Entry()
        {
            var mockService = new Mock<IAdventurerService>();

            mockService.Setup(s => s.GetAllAdventurers() ).Returns(
                [ new Adventurer("Guy", FightingClasses.Warrior) ]
            );

            var controller = new AdventurerController(mockService.Object);
                //Testing the controller with pre-determined environment

            var result = controller.GetAllAdventurers();

            if (result is OkObjectResult OkRes)
            {
                if ( OkRes.Value is List<Adventurer> list)
                {
                    if ( list.Count > 0)
                    {
                        Assert.Pass();
                        return;
                    }
                }
            }
           
            Assert.Fail();
            
        }
    }
}