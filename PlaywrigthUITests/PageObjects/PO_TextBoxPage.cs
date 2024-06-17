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

        public PO_TextBoxPage(IPage page)
        {
            this.page = page;
        }
        public async Task GoToTextBoxPage(string testPageUrl)
        {
            await page.GotoAsync(testPageUrl);
            //await page.WaitForURLAsync(testPageUrl);
        }

        public async Task IsTextBoxPageH1Visible(string testPageH1)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = testPageH1 })).ToBeVisibleAsync();
        }

        public async Task IsFullNameLabelVisible(string fullNameLabel)
        {
            await Assertions.Expect(page.Locator("#userName-wrapper div").Filter(new() { HasText = fullNameLabel })).ToBeVisibleAsync();
        }

        public async Task FillFullName(string testFullName, string fullNamePlaceholder)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).FillAsync(testFullName);
            await Assertions.Expect(page.GetByPlaceholder(fullNamePlaceholder)).ToHaveValueAsync(testFullName);
        }

        public async Task IsFullNameFocused(string fullNamePlaceholder)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).ClickAsync();
            await Assertions.Expect(page.GetByPlaceholder(fullNamePlaceholder)).ToBeFocusedAsync();
        }

        public async Task ClickButton(string btnName)
        {
            await page.GetByRole(AriaRole.Button, new() { Name = btnName }).ClickAsync();
        }

        public async Task IsButtonFocused(string btnName)
        {
            var submitButton = page.GetByRole(AriaRole.Button, new() { Name = btnName });
            await submitButton.ClickAsync();
            await Assertions.Expect(submitButton).ToBeFocusedAsync();
        }

        public async Task ClearFullNameInput(string fullNamePlaceholder)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).ClearAsync();
        }

        public async Task VerifyFullNameOutput(string testFullName)
        {
            await Assertions.Expect(page.Locator("#output div")).ToHaveTextAsync($"Name:{testFullName}");
        }
        public async Task VerifyFullNameOutputCleared(string testFullName)
        {
            await Assertions.Expect(page.Locator("#output div")).ToBeEmptyAsync(); //Not.ToHaveTextAsync($"Name:{testFullName}");
        }
    }
}
