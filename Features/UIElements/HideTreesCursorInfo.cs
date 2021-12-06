using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideTreesCursorInfo : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideTreesCursorInfo;

        public readonly ToolBaseProxy _toolBaseProxy;

        public HideTreesCursorInfo(IModContext context) : base(context)
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
            _toolBaseProxy.DisableTreeToolCursorInfo = true;
            return true;
        }

        protected override bool OnDisable()
        {
            _toolBaseProxy.DisableTreeToolCursorInfo = false;
            return true;
        }
    }
}