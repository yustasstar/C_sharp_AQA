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
        private string testPlaceholder = "Full Name";
        private string testLabel = "Full Name";
        private string testFullName = "Test Name 123";
        private string testEmail = "TestEmail@test.net";
        private string testCurrentAddress = "Test Current Adress 123";
        private string testPermanentAddress = "Test Permanent Address 123";
        //_________________________________________________

        [Test]
        [Description("TextBox Page H1 'Text Box' should be visible")]
        public async Task VerifyTextBoxPageH1()
        {
            await _TextBoxPage.GoToTextBoxPage();
            await _TextBoxPage.IsTextBoxPageH1Visible();
        }

        [Test]
        [Description("Label 'Full Name' should be visible")]
        public async Task VerifyFullNameLabel()
        {
            await _TextBoxPage.GoToTextBoxPage();
            await _TextBoxPage.IsFullNameLabelVisible();
        }

        [Test]
        [Description("Enter {testFullName} in Full Name input, press submit, text Name should be 'Name:{testFullName}'")]
        public async Task VerifyFullNameFilled()
        {
            await _TextBoxPage.GoToTextBoxPage();
            await _TextBoxPage.FillFullName(testFullName);
            await _TextBoxPage.IsFullNameFocused();
            await _TextBoxPage.ClickSubmitButton();
            await _TextBoxPage.IsSubmitButtonFocused();
            await _TextBoxPage.VerifyFullNameOutput(testFullName);
        }

        [Test]
        [Description("Clear 'Full Name' Input, press submit, text 'Name:{testFullName} should not be visible")]
        public async Task VerifyFullNameInput()
        {
            await _TextBoxPage.GoToTextBoxPage();
            await _TextBoxPage.FillFullName(testFullName);
            await _TextBoxPage.IsFullNameFocused();
            await _TextBoxPage.ClickSubmitButton();
            await _TextBoxPage.IsSubmitButtonFocused();
            await _TextBoxPage.VerifyFullNameOutput(testFullName);
            
            await _TextBoxPage.ClearFullNameInput();
            await _TextBoxPage.ClickSubmitButton();
            await _TextBoxPage.IsSubmitButtonFocused();
            await _TextBoxPage.VerifyFullNameOutputCleared(testFullName);
        }
    }
}
