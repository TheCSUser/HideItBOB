using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HidePauseOutline : HideUISprite
    {
        public override FeatureKey Key => FeatureKey.HidePauseOutline;

        public HidePauseOutline(IModContext context) : base(context) { }

        protected override UISprite GetComponent()
        {
            var component = GameObject.Find(nameof(PauseOutline));
            if (component is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(HidePauseOutline)}.{nameof(GetComponent)} could not find {nameof(PauseOutline)}, current error count is {ErrorCount}.");
#endif
                return null;
            }
            var uiSprite = component.GetComponent<UISlicedSprite>();
            if (uiSprite is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(HidePauseOutline)}.{nameof(GetComponent)} could not find {nameof(UISlicedSprite)}, current error count is {ErrorCount}.");
#endif
                return null;
            }
            return uiSprite;
        }
    }
}