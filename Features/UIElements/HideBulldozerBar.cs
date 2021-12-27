using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideBulldozerBar : HideUISprite
    {
        public override FeatureKey Key => FeatureKey.HideBulldozerBar;

        public HideBulldozerBar(IModContext context) : base(context) { }

        protected override UISprite GetComponent()
        {
            var component = GameObject.Find("BulldozerBar");
            if (component is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(HideBulldozerBar)}.{nameof(GetComponent)} could not find {nameof(PauseOutline)}, current error count is {ErrorCount}.");
#endif
                return null;
            }
            var uiSprite = component.GetComponent<UITiledSprite>();
            if (uiSprite is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(HideBulldozerBar)}.{nameof(GetComponent)} could not find {nameof(UITiledSprite)}, current error count is {ErrorCount}.");
#endif
                return null;
            }
            return uiSprite;
        }
    }
}