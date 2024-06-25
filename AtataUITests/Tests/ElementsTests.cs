using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public sealed class ElementsTests : UITestFixture
    {
        //Elements:

        [Test]
        [Description("TestDecription")]
        public void VerifyURL()
        {
            Go.To<ElementsPage>()
                .PageUrl.Should.Be("https://demoqa.com/elements");
        }

    }
}
