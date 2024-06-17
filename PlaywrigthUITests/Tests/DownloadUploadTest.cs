﻿using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class DownloadUploadTest : UITestFixture
    {
        private PO_DownloadPage _UpDownloadPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _UpDownloadPage = new PO_DownloadPage(Page);
        }

        [Test, Description("Donwload file verify file updated")]
        public async Task VerifyDownload()
        {
            await _UpDownloadPage.GoToUploadDownloadPage();
            await _UpDownloadPage.ClickDownloadButton();
        }

        [Test]
        public async Task VerifyUpload()
        {
            await _UpDownloadPage.GoToUploadDownloadPage();
            await _UpDownloadPage.ClickChooseFileButton();
        }
    }
}