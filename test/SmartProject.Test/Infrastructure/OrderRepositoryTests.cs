using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using SmartProject.Domain.Features;
using SmartProject.Infrastructure;
using SmartProject.Infrastructure.Features;

namespace SmartProject.Test.Infrastructure
{
	public class OrderRepositoryTests
	{
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetByIdNotEmpty()
        {
            Order returnValue = new Order() { Id = 1, CustomerId = 1, ProductId = 1 };

            var moqSmartDbContext = new Mock<ISmartDbContext>();
            var moqOrderDbSet = new Mock<DbSet<Order>>();

            moqOrderDbSet.Setup(o => o.Find(It.IsAny<long>())).Returns(returnValue);
            moqSmartDbContext.Setup(m => m.Set<Order>()).Returns(moqOrderDbSet.Object);
            
            var orderRepository = new OrderRepository(moqSmartDbContext.Object);
            var testValue = orderRepository.GetById(1);

            Assert.That(testValue!.Id, Is.EqualTo(returnValue.Id));
        }
    }
}

