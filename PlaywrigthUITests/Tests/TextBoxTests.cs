﻿using Microsoft.Playwright;
using NUnitTests.Features.Drive;
namespace PlaywrigthUITests.Tests
{
    [Description("Verify text box on buttons page")]
    class TextBoxTests : UITestFixture
    {
        public byte newstring = DrivePresetup.Accelerate;
        public byte newstring1 = DrivePresetup.InternalClass.InternalAccelerate;

        [Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Full Name' text input
            await Page.GetByPlaceholder("Full Name").FillAsync("John Doe");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then  I see "Name:John Doe" text.
            var isVisible = await Page.GetByText("Name:John Doe").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }
    }
}