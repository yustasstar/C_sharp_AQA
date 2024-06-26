using Atata;
using _ = AtataUITests.PageObjects.RadioButtonPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Radio Button")]
    [Url("radio-button")]
    public sealed class RadioButtonPage : DemoQAPage<_>
    {
        //Texts:
        [FindByClass("text-center")]
        public Text<_> RadioButtonPageH1 { get; set; }

        [FindByClass("mb-3")]
        public Text<_> DoYouLikeText { get; set; }

        [FindByClass("mt-3")]
        public Text<_> SuccessText { get; set; }

        //Yes Radio:
        [FindByLabel("Yes")]
        public RadioButton<_> YesRadioButton { get; set; }

        [FindByLabel("Yes")]
        public Label<_> YesLabel { get; set; }

        //Impressive Radio:
        [FindByLabel("Impressive")]
        public RadioButton<_> ImpressiveRadioButtom{ get; set; }

        [FindByLabel("Impressive")]
        public Label<_> ImpressiveLabel { get; set; }

        //No Radio:
        [FindByLabel("No")]
        public RadioButton<_> NoRadioButton { get; set; }

        [FindByLabel("No")]
        public Label<_> NoLabel { get; set; }
    }
}
