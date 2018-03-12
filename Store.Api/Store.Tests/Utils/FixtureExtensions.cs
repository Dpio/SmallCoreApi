using System.Linq;
using AutoFixture;

namespace Store.Tests.Utils
{
    public static class FixtureExtensions
    {
        public static IFixture WithStandardCustomization(this IFixture fixture)
        {
            fixture = new Fixture().Customize(new IgnoreVirtualMembersCustomisation());
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }
    }
}