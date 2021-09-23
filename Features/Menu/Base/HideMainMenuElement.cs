using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Menu.Base
{
    internal abstract class HideMainMenuElement : HideUIComponentByName
    {
        public HideMainMenuElement(IModContext context, string componentName) : base(context, componentName) { }

        protected override UIComponent GetComponent()
        {
            var menuContainer = UIView.Find("MenuContainer")?.GetComponent<UIPanel>();
            if (menuContainer is null)
            {
#if DEV
                Log.Warning($"{GetType().Name}.{nameof(GetComponent)} could not find MenuContainer.");
#endif
                return null;
            }
            var component = menuContainer.Find(ComponentName)?.GetComponent<UIComponent>();
#if DEV
            if (component is null)
            {
                Log.Warning($"{GetType().Name}.{nameof(GetComponent)} could not find {ComponentName}.");
            }
#endif
            return component;
        }
    }
}