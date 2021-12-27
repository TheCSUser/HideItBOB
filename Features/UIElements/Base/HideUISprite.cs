using ColossalFramework.UI;
using com.github.TheCSUser.Shared.Common;
using System;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements.Base
{
    internal abstract class HideUISprite : UpdatableFeatureBase
    {
        protected string DefaultSpriteName = null;
        protected readonly Cached<UISprite> Component;

        public override bool IsError
        {
            get
            {
                return base.IsError;
            }
            set
            {
                if (!value) Component.Invalidate();
                base.IsError = value;
            }
        }

        public HideUISprite(IModContext context) : base(context)
        {
            Component = new Cached<UISprite>(GetComponentPrivate, int.MaxValue);
        }

        private UISprite GetComponentPrivate()
        {
            try
            {
                return GetComponent();
            }
            catch (Exception e)
            {
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(GetComponent)} failed", e);
                return null;
            }
        }
        protected abstract UISprite GetComponent();

        protected override bool OnEnable()
        {
            var component = Component.Value;
            if (component is null) return false;
            if (string.IsNullOrEmpty(component.spriteName)) return true;

            if (DefaultSpriteName is null) DefaultSpriteName = component.spriteName;
            component.spriteName = null;
            return true;
        }
        protected override bool OnDisable()
        {
            var component = Component.Value;
            if (component is null) return false;

            if (component.spriteName is null) component.spriteName = DefaultSpriteName;
            Component.Invalidate();
            return true;
        }
        protected override bool OnUpdate() => OnEnable();

        protected override bool OnTerminate()
        {
            DefaultSpriteName = null;
            return base.OnTerminate();
        }
    }
}