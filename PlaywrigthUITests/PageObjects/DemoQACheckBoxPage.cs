﻿using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQACheckBoxPage
    {
        private IPage _page;
        private string RadioButtonPageUrl = "https://demoqa.com/checkbox";

        public DemoQACheckBoxPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToDemoQaChecboxPage()
        {
            await _page.GotoAsync(RadioButtonPageUrl);
        }

        public async Task CheckHomeCheckbox()
        {
            await _page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3).ClickAsync();
        }

        public async Task CheckCheckbox(string branch)
        {
            await _page.Locator("label").Filter(new() { HasText = branch }).GetByRole(AriaRole.Img).First.ClickAsync();
        }

        public async Task OpenHome()
        {
            await _page.GetByLabel("Toggle").First.ClickAsync();
        }

        public async Task VerifyHomeChecked()
        {
            await Assertions.Expect(_page.Locator("#tree-node path").Nth(3)).ToBeCheckedAsync();
        }

        public async Task<bool> VerifyCheckboxChecked(string branch)
        {
            try
            {
                // Locate `span` element containing the branch title
                var spanElement = _page.Locator($"span.rct-text:has(span.rct-title:text-is('{branch}'))");

                // Check the `span` visible
                var spanElementVisible = await spanElement.IsVisibleAsync();
                Console.WriteLine($"span element for '{branch}' visible: {spanElementVisible}");
                if (!spanElementVisible)
                {
                    Console.WriteLine($"span element for '{branch}' not found or not visible.");
                    return false;
                }

                // Locate the checkbox in `span` element
                var checkboxLocator = spanElement.Locator(".rct-icon-check");

                // Check if the checkbox is visible
                var checkboxVisible = await checkboxLocator.IsVisibleAsync();
                Console.WriteLine($"Checkbox for '{branch}' visible: {checkboxVisible}");

                return checkboxVisible;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
    }
}
