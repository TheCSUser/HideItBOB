using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Features.Menu.Shared;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Menu
{
    internal sealed class HideMainMenuDLCPanel : HideUIComponent
    {
        public override FeatureKey Key => FeatureKey.HideMainMenuDLCPanel;

        public HideMainMenuDLCPanel(IModContext context) : base(context) { }

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
            var isPanelVisible = (mainMenu.GetField("m_DLCPanel") as UIComponent)?.isVisible ?? false;
            if (isPanelVisible) Enable(true);
        }
        private void OnMainMenuCreditsEnded(MainMenu mainMenu)
        {
            if (!IsEnabled) return;
            var isPanelVisible = (mainMenu.GetField("m_DLCPanel") as UIComponent)?.isVisible ?? false;
            if (isPanelVisible) Enable(true);
        }

        protected override UIComponent GetComponent()
        {
            var menuContainer = UIView.Find("MenuContainer")?.GetComponent<UIPanel>();
            if (menuContainer is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(HideMainMenuDLCPanel)}.{nameof(GetComponent)} could not find MenuContainer.");
#endif
                return null;
            }
            var dlcPanelNew = menuContainer.Find("DLCPanelNew")?.GetComponent<UIComponent>();
#if DEV || PREVIEW
            if (dlcPanelNew is null)
            {
                Log.Warning($"{nameof(HideMainMenuDLCPanel)}.{nameof(GetComponent)} could not find DLCPanelNew.");
            }
#endif
            if (!(dlcPanelNew is null)) return dlcPanelNew;
            var dlcPanel = menuContainer.Find("DLCPanel")?.GetComponent<UIComponent>();

            if (dlcPanel is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(HideMainMenuDLCPanel)}.{nameof(GetComponent)} could not find DLCPanel.");
#endif
            }

            return dlcPanel;
        }
    }
}