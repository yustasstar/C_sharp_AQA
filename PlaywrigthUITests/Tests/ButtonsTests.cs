﻿using Microsoft.Playwright;

namespace PlaywrigthUITests.Tests
{

    [Description("Verify Buttons on buttons page")]
    class ButtonsTestsrun : UITestFixture
    {
        [Test, Description("Verify Click Me button"), Retry(2)]
        public async Task ClickButtonTest()
        {
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I click the 'Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Click Me" }).ClickAsync();
            // Then  I see "You have done a dynamic click" text.
            var isVisible = await Page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.IsTrue(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
            // And I NOT see "You have done a double click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.IsTrue(isNotVisible, "The element with text 'You have done a double click' should NOT be visible after clicking the button.");
        }

        [Test, Description("Verify Double Click Me button"), Retry(2)]
        public async Task DoubleClickButtonTest()
        {
            // Given I go to DemoQA Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I double click the 'Double Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Double Click Me" }).DblClickAsync();
            // Then I see "You have done a double click" text.
            var isVisible = await Page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.IsTrue(isVisible, "The element with text 'You have done a double click' should be visible after clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a dynamic click").IsHiddenAsync();
            Assert.IsTrue(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after a double click.");
        }

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public async Task RigthClickButtonTest()
        {
            // Given I go to DemoQA Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I Rigth click the 'Right Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Right Click Me" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            // Then I see "You have done a right click" text.
            var isVisible = await Page.GetByText("You have done a right click").IsVisibleAsync();
            Assert.IsTrue(isVisible, "The element with text 'You have done a double click' should be visible after Rigth clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.IsTrue(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after Rigth clicking the button.");
        }
    }
}