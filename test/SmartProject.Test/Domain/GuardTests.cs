using SmartProject.Domain.Common;

namespace SmartProject.Test.Domain;

public class GuardTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NotEmptyStringDoesNotThrowException()
    {
        string value = "SmartProject";
        Assert.DoesNotThrow(() => Guard.AgainstEmptyString(value));
    }
}
