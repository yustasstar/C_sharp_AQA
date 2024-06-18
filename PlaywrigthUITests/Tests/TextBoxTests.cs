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

        //TEST DATA:_______________________________________
        //Page:
        public string PageUrl = "https://demoqa.com/text-box";
        private string PageH1 = "Text Box";
        //Labels:
        private string fullNamePlaceholder = "Full Name";
        private string fullNameLabel = "Full Name";
        //Inputs:
        private string FullName = "Test Name 123";
        private string Email = "TestEmail@test.net";
        private string CurrentAddress = "Test Current Adress 123";
        private string PermanentAddress = "Test Permanent Address 123";
        private string SubmitBtn = "Submit";
        //_________________________________________________

        [Test]
        [Description("TextBox Page H1 'Text Box' should be visible")]
        public async Task VerifyTextBoxPageH1()
        {
            await _TextBoxPage.GoToURL(PageUrl);
            await _TextBoxPage.IsPageH1Visible(PageH1);
        }

        [Test]
        [Description("Label 'Full Name' should be visible")]
        public async Task VerifyFullNameLabel()
        {
            await _TextBoxPage.GoToURL(PageUrl);
            await _TextBoxPage.IsInputLabelVisible(fullNameLabel);
        }

        [Test]
        [Description("Enter {FullName} in Full Name input, press submit, text Name should be 'Name:{FullName}'")]
        public async Task VerifyFullNameFilled()
        {
            await _TextBoxPage.GoToURL(PageUrl);
            await _TextBoxPage.FillInput(FullName, fullNamePlaceholder);
            await _TextBoxPage.IsInputFocused(fullNamePlaceholder);
            await _TextBoxPage.ClickButton(SubmitBtn);
            await _TextBoxPage.IsButtonFocused(SubmitBtn);
            await _TextBoxPage.VerifyOutputValue(FullName);
        }

        [Test]
        [Description("Clear 'Full Name' Input, press submit, text 'Name:{FullName} should not be visible")]
        public async Task VerifyFullNameInput()
        {
            await _TextBoxPage.GoToURL(PageUrl);
            await _TextBoxPage.FillInput(FullName, fullNamePlaceholder);
            await _TextBoxPage.IsInputFocused(fullNamePlaceholder);
            await _TextBoxPage.ClickButton(SubmitBtn);
            await _TextBoxPage.IsButtonFocused(SubmitBtn);
            await _TextBoxPage.VerifyOutputValue(FullName);

            await _TextBoxPage.ClearInput(fullNamePlaceholder);
            await _TextBoxPage.ClickButton(SubmitBtn);
            await _TextBoxPage.VerifyOutputCleared();
        }
    }
}
