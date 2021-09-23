using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Features.Menu.Base;
using com.github.TheCSUser.HideItBobby.Features.Menu.Shared;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Menu
{
    internal sealed class HideMainMenuWorkshopPanel : HideMainMenuElement
    {
        public override FeatureKey Key => FeatureKey.HideMainMenuWorkshopPanel;

        public HideMainMenuWorkshopPanel(IModContext context) : base(context, "WorkshopAdPanel") { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(MainMenuProxy.Patches);
            MainMenuProxy.OnVisibilityChanged += OnMainMenuVisibilityChanged;
            MainMenuProxy.OnCreditsEnded += OnMainMenuCreditsEnded;
            return true;
        }
        protected override bool OnTerminate()
        {
            MainMenuProxy.OnCreditsEnded -= OnMainMenuCreditsEnded;
            MainMenuProxy.OnVisibilityChanged -= OnMainMenuVisibilityChanged;
            Patcher.Unpatch(MainMenuProxy.Patches);
            return true;
        }

        private void OnMainMenuVisibilityChanged(MainMenu mainMenu, bool isVisible)
        {
            if (!IsEnabled) return;
            var isPanelVisible = (mainMenu.GetField("m_WorkshopPanel") as UIComponent)?.isVisible ?? false;
            if (isPanelVisible) Enable(true);
        }
        private void OnMainMenuCreditsEnded(MainMenu mainMenu)
        {
            if (!IsEnabled) return;
            var isPanelVisible = (mainMenu.GetField("m_WorkshopPanel") as UIComponent)?.isVisible ?? false;
            if (isPanelVisible) Enable(true);
        }
    }
}