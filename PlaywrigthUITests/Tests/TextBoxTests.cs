using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    [TestFixture]
    internal class TextBoxTests : UITestFixture
    {
        private PO_TextBoxPage _TextBoxPage;

        [SetUp]
        public void SetupTextBoxPage()
        {
            _TextBoxPage = new PO_TextBoxPage(Page);
        }

        //Test DATA:_______________________________________
        public string testPageUrl = "https://demoqa.com/text-box";

        private string testPageH1 = "Text Box";
        private string fullNamePlaceholder = "Full Name";
        private string fullNameLabel = "Full Name";

        private string testFullName = "Test Name 123";
        private string testEmail = "TestEmail@test.net";
        private string testCurrentAddress = "Test Current Adress 123";
        private string testPermanentAddress = "Test Permanent Address 123";
        //_________________________________________________

        [Test]
        [Description("TextBox Page H1 'Text Box' should be visible")]
        public async Task VerifyTextBoxPageH1()
        {
            await _TextBoxPage.GoToTextBoxPage(testPageUrl);
            await _TextBoxPage.IsTextBoxPageH1Visible(testPageH1);
        }

        [Test]
        [Description("Label 'Full Name' should be visible")]
        public async Task VerifyFullNameLabel()
        {
            await _TextBoxPage.GoToTextBoxPage(testPageUrl);
            await _TextBoxPage.IsFullNameLabelVisible(fullNameLabel);
        }

        [Test]
        [Description("Enter {testFullName} in Full Name input, press submit, text Name should be 'Name:{testFullName}'")]
        public async Task VerifyFullNameFilled()
        {
            await _TextBoxPage.GoToTextBoxPage(testPageUrl);
            await _TextBoxPage.FillFullName(testFullName, fullNamePlaceholder);
            await _TextBoxPage.IsFullNameFocused(fullNamePlaceholder);
            await _TextBoxPage.ClickButton("Submit");
            await _TextBoxPage.IsButtonFocused("Submit");
            await _TextBoxPage.VerifyFullNameOutput(testFullName);
        }

        [Test]
        [Description("Clear 'Full Name' Input, press submit, text 'Name:{testFullName} should not be visible")]
        public async Task VerifyFullNameInput()
        {
            await _TextBoxPage.GoToTextBoxPage(testPageUrl);
            await _TextBoxPage.FillFullName(testFullName, fullNamePlaceholder);
            await _TextBoxPage.IsFullNameFocused(fullNamePlaceholder);
            await _TextBoxPage.ClickButton("Submit");
            await _TextBoxPage.IsButtonFocused("Submit");
            await _TextBoxPage.VerifyFullNameOutput(testFullName);
            
            await _TextBoxPage.ClearFullNameInput(fullNamePlaceholder);
            await _TextBoxPage.ClickButton("Submit");
            await _TextBoxPage.VerifyFullNameOutputCleared(testFullName);
        }
    }
}
