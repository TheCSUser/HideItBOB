using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideZoomAndUnlockBackground : HideUIComponent
    {
        public override FeatureKey Key => FeatureKey.HideZoomAndUnlockBackground;

        public HideZoomAndUnlockBackground(IModContext context) : base(context) { }

        protected override UIComponent GetComponent()
        {
            var tsbar = GameObject.Find("TSBar")?.GetComponent<UIComponent>();
            if (tsbar is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{GetType().Name}.{nameof(GetComponent)} could not find TSBar, current error count is {ErrorCount}.");
#endif
                return null;
            }
            var sprite = tsbar.Find("Sprite")?.GetComponent<UIComponent>();
            if (sprite is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{GetType().Name}.{nameof(GetComponent)} could not find Sprite, current error count is {ErrorCount}.");
#endif
            }
            return sprite;
        }
    }
}