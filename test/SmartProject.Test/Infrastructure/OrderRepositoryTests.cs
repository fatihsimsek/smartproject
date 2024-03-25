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
        public void check_ExistedOrderId_GetById()
        {
            Order expectedValue = new Order() { Id = 1, CustomerId = 1, ProductId = 1 };

            var moqSmartDbContext = new Mock<ISmartDbContext>();
            var moqOrderDbSet = new Mock<DbSet<Order>>();

            moqOrderDbSet.Setup(o => o.Find(It.IsAny<long>())).Returns(expectedValue);
            moqSmartDbContext.Setup(m => m.Set<Order>()).Returns(moqOrderDbSet.Object);
            
            var orderRepository = new OrderRepository(moqSmartDbContext.Object);
            var actualValue = orderRepository.GetById(1);

            Assert.IsNotNull(actualValue);
            Assert.That(actualValue!.Id, Is.EqualTo(expectedValue.Id));
        }
    }
}

