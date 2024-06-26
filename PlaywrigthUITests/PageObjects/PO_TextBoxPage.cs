﻿using Atata;
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
        public async Task GoToURL(string testPageUrl)
        {
            await page.GotoAsync(testPageUrl);
            //await page.WaitForURLAsync(PageUrl);
        }

        public async Task IsPageH1Visible(string PageH1)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = PageH1 })).ToBeVisibleAsync();
        }

        public async Task IsInputLabelVisible(string fullNameLabel)
        {
            await Assertions.Expect(page.Locator("#userName-wrapper div").Filter(new() { HasText = fullNameLabel })).ToBeVisibleAsync();
        }

        public async Task FillInput(string FullName, string fullNamePlaceholder)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).FillAsync(FullName);
            await Assertions.Expect(page.GetByPlaceholder(fullNamePlaceholder)).ToHaveValueAsync(FullName);
        }

        public async Task IsInputFocused(string fullNamePlaceholder)
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
            var button = page.GetByRole(AriaRole.Button, new() { Name = btnName });
            await button.ClickAsync();
            await Assertions.Expect(button).ToBeFocusedAsync();
        }

        public async Task ClearInput(string fullNamePlaceholder)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).ClearAsync();
        }

        public async Task VerifyOutputValue(string outputValue)
        {
            await Assertions.Expect(page.Locator("#output div")).ToHaveTextAsync($"Name:{outputValue}");
        }

        public async Task VerifyOutputCleared()
        {
            await Assertions.Expect(page.Locator("#output div")).ToBeEmptyAsync();
        }
    }
}
