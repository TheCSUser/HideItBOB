using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class CityNamePosition : ModifyUIComponentPosition
    {
        public override FeatureKey Key => FeatureKey.CityNamePosition;

        public CityNamePosition(IModContext context) : base(context) { }

        protected override GameObject GetGameObject()
        {
            var infoPanel = GameObject.Find("InfoPanel")?.GetComponent<UIComponent>();
            if (infoPanel is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(CityNamePosition)}.{nameof(GetGameObject)} could not find InfoPanel, current error count is {ErrorCount}.");
#endif
                return null;
            }
            var name = infoPanel.Find("Name")?.gameObject;
            if (name is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{nameof(CityNamePosition)}.{nameof(GetGameObject)} could not find Name, current error count is {ErrorCount}.");
#endif
            }
            return name;
        }

        protected override Vector3? GetDesiredComponentPosition()
        {
            var defaultPos = DefaultComponentPosition;
            if (!defaultPos.HasValue) return null;
            return new Vector3(
                defaultPos.Value.x + Mod.Settings.CityNamePosition,
                defaultPos.Value.y,
                defaultPos.Value.z
            );
        }
    }
}