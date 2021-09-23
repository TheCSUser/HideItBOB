using ColossalFramework.UI;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements.Base
{
    internal abstract class HideUIComponent : FeatureBase
    {
        protected readonly Cached<UIComponent> Component;

        public HideUIComponent(IModContext context) : base(context)
        {
            Component = new Cached<UIComponent>(GetComponent);
        }

        protected override bool OnEnable()
        {
            var component = Component.Value;
            if (component is null) return false;
            component.eventVisibilityChanged += OnComponentVisibilityChanged;
            component.isVisible = false;
            return true;
        }

        protected override bool OnDisable()
        {
            var component = Component.Value;
            if (component is null) return false;
            component.eventVisibilityChanged -= OnComponentVisibilityChanged;
            component.isVisible = true;
            Component.Invalidate();
            return true;
        }

        protected virtual void OnComponentVisibilityChanged(UIComponent component, bool value)
        {
            if (component.isVisibleSelf) component.isVisible = false;
        }

        protected abstract UIComponent GetComponent();
    }
}