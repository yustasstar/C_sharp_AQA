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
        [Category("UI")]
        [Description("H1 'Text Box' should be visible")]
        public async Task VerifyTextBoxPageH1()
        {
            await _TextBoxPage.GoToURL(PageUrl);
            await _TextBoxPage.IsPageH1Visible(PageH1);
        }

        [Test]
        [Category("UI")]
        [Description("Label 'Full Name' should be visible")]
        public async Task VerifyFullNameLabel()
        {
            await _TextBoxPage.GoToURL(PageUrl);
            await _TextBoxPage.IsInputLabelVisible(fullNameLabel);
        }

        [Test]
        [Category("UI")]
        [Description("Enter {FullName} in 'Full Name' input, press 'Submit' btn, text should be 'Name:{FullName}'")]
        public async Task VerifyFullNameInput()
        {
            await _TextBoxPage.GoToURL(PageUrl);
            await _TextBoxPage.FillInput(FullName, fullNamePlaceholder);
            await _TextBoxPage.IsInputFocused(fullNamePlaceholder);
            await _TextBoxPage.ClickButton(SubmitBtn);
            await _TextBoxPage.IsButtonFocused(SubmitBtn);
            await _TextBoxPage.VerifyOutputValue(FullName);
        }

        [Test]
        [Category("UI")]
        [Description("Clear 'Full Name' input, click Submit, output should be cleared")]
        public async Task VerifyFullNameOutput()
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
