using FeatureToggle.Toggles;

namespace FeatureControl
{
    public class ReleaseFeatureToggles
    {
        public class ShowNameOnHomePage : SqlFeatureToggle
        {
            public ShowNameOnHomePage()
            {
                ToggleValueProvider = new CustomFeatureToggleProviders.CustomSqlFeatureToggleProvider("temp-ShowNameOnHomePage");
            }
        }
    }
}
