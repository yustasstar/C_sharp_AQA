using Atata;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace PlaywrigthUITests.PageObjects
{
    internal class PO_TextBoxPage
    {
        private IPage page;
        public string TextBoxPageUrl = "https://demoqa.com/text-box";
        private string TextBoxPageH1 = "Text Box";
        private string fullNamePlaceholder = "Full Name";
        private string fullNameLabel = "Full Name";
        private string submitButtonRole = "button";
        private string submitButtonName = "Submit";

        public PO_TextBoxPage(IPage page)
        {
            this.page = page;
        }
        public async Task GoToTextBoxPage()
        {
            await page.GotoAsync(TextBoxPageUrl);
            //await page.WaitForURLAsync(TextBoxPageUrl);
        }

        public async Task IsTextBoxPageH1Visible()
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = TextBoxPageH1 })).ToBeVisibleAsync();
        }

        public async Task IsFullNameLabelVisible()
        {
            await Assertions.Expect(page.Locator("#userName-wrapper div").Filter(new() { HasText = fullNameLabel })).ToBeVisibleAsync();
        }

        public async Task FillFullName(string fullNameText)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).FillAsync(fullNameText);
            await Assertions.Expect(page.GetByPlaceholder(fullNamePlaceholder)).ToHaveValueAsync(fullNameText);
        }

        public async Task IsFullNameFocused()
        {
            await page.GetByPlaceholder(fullNamePlaceholder).ClickAsync();
            await Assertions.Expect(page.GetByPlaceholder(fullNamePlaceholder)).ToBeFocusedAsync();
        }

        public async Task ClickSubmitButton()
        {
            await page.GetByRole(AriaRole.Button, new() { Name = submitButtonName }).ClickAsync();
        }

        public async Task IsSubmitButtonFocused()
        {
            var submitButton = page.GetByRole(AriaRole.Button, new() { Name = submitButtonName });
            await submitButton.ClickAsync();
            await Assertions.Expect(submitButton).ToBeFocusedAsync();
        }

        public async Task ClearFullNameInput()
        {
            await page.GetByPlaceholder(fullNamePlaceholder).ClearAsync();
        }

        public async Task VerifyFullNameOutput(string testFullName)
        {
            await Assertions.Expect(page.Locator("#output div")).ToHaveTextAsync($"Name:{testFullName}");
        }
        public async Task VerifyFullNameOutputCleared(string testFullName)
        {
            await Assertions.Expect(page.Locator("#output div")).Not.ToHaveTextAsync($"Name:{testFullName}");
        }

        //public async Task<bool> IsNameHidden(string testFullName)
        //{
        //    return await page.GetByText($"Name:{testFullName}").IsHiddenAsync();
        //}
    }
}
