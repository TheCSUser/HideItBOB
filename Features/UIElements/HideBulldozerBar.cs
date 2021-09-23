using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideBulldozerBar : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideBulldozerBar;

        public HideBulldozerBar(IModContext context) : base(context) { }

        protected override bool OnEnable()
        {
            var component = GetObject();
            if (component is null)
            {
                return false;
            }
            component.SetActive(false);
            return true;
        }
        protected override bool OnDisable()
        {
            var component = GetObject();
            if (component is null)
            {
                return false;
            }
            component.SetActive(true);
            return true;
        }

        private GameObject GetObject()
        {
            var component = GameObject.Find("BulldozerBar");
            if (component is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(HideBulldozerBar)}.{nameof(GetObject)} could not find BulldozerBar, current error count is {ErrorCount}.");
#endif
            }
            return component;
        }
    }
}