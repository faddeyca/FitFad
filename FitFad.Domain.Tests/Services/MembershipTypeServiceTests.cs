using FitFad.Domain.Enums;
using FitFad.Domain.Services;

namespace FitFad.Domain.Tests.Services
{
    [TestFixture]
    public class MembershipTypeServiceTests
    {
        [Test]
        public void MembershipTypeService_GetPrice_ShouldReturnPositivePrice()
        {
            foreach (MembershipType type in Enum.GetValues(typeof(MembershipType)))
            {
                Assert.That(MembershipTypeService.GetPrice(type), Is.GreaterThan(0));
            }
        }

        [Test]
        public void MembershipTypeService_GetDescription_ShouldReturnNonEmptyDescription()
        {
            foreach (MembershipType type in Enum.GetValues(typeof(MembershipType)))
            {
                Assert.That(MembershipTypeService.GetDescription(type), Is.Not.Empty);
            }
        }

        [Test]
        public void MembershipTypeService_GetMaxClients_ShouldReturnPositiveMaxClients()
        {
            foreach (MembershipType type in Enum.GetValues(typeof(MembershipType)))
            {
                Assert.That(MembershipTypeService.GetMaxClients(type), Is.GreaterThan(0));
            }
        }
    }
}
