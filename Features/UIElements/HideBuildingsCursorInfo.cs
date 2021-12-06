using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideBuildingsCursorInfo : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideBuildingsCursorInfo;

        public readonly ToolBaseProxy _toolBaseProxy;

        public HideBuildingsCursorInfo(IModContext context) : base(context)
        {
            _toolBaseProxy = context.Resolve<ToolBaseProxy>();
        }

        protected override bool OnInitialize()
        {
            Patcher.Patch(_toolBaseProxy.Patches);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(_toolBaseProxy.Patches);
            return true;
        }

        protected override bool OnEnable()
        {
            _toolBaseProxy.DisableBuildingToolCursorInfo = true;
            return true;
        }

        protected override bool OnDisable()
        {
            _toolBaseProxy.DisableBuildingToolCursorInfo = false;
            return true;
        }
    }
}