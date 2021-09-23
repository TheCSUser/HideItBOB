using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class ToolbarPosition : ModifyUIComponentPositionByName
    {
        public override FeatureKey Key => FeatureKey.ToolbarPosition;

        public ToolbarPosition(IModContext context) : base(context, "MainToolstrip") { }

        protected override Vector3? GetDesiredComponentPosition()
        {
            var defaultPos = DefaultComponentPosition;
            if (!defaultPos.HasValue) return null;
            return new Vector3(
                defaultPos.Value.x + Mod.Settings.ToolbarPosition,
                defaultPos.Value.y,
                defaultPos.Value.z
            );
        }
    }
}