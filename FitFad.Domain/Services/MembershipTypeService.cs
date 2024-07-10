using FitFad.Domain.Enums;

namespace FitFad.Domain.Services
{
    public static class MembershipTypeService
    {
        //Extension point: Move this out to a configuration file
        public static decimal GetPrice(MembershipType type)
        {
            return type switch
            {
                MembershipType.Adult => 100,
                MembershipType.Child => 50,
                MembershipType.Senior => 70,
                MembershipType.Student => 80,
                MembershipType.Family => 200,
                MembershipType.Couple => 150,
                MembershipType.Corporate => 500,
                _ => throw new ArgumentException("Invalid membership type.")
            };
        }

        public static string GetDescription(MembershipType type)
        {
            return type switch
            {
                MembershipType.Adult => "Adult membership",
                MembershipType.Child => "Child membership",
                MembershipType.Senior => "Senior membership",
                MembershipType.Student => "Student membership",
                MembershipType.Family => "Family membership",
                MembershipType.Couple => "Couple membership",
                MembershipType.Corporate => "Corporate membership",
                _ => throw new ArgumentException("Invalid membership type.")
            };
        }

        public static int GetMaxClients(MembershipType type)
        {
            return type switch
            {
                MembershipType.Adult => 1,
                MembershipType.Child => 1,
                MembershipType.Senior => 1,
                MembershipType.Student => 1,
                MembershipType.Family => 4,
                MembershipType.Couple => 2,
                MembershipType.Corporate => 10,
                _ => throw new ArgumentException("Invalid membership type.")
            };
        }
    }
}
