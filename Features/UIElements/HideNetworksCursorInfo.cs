using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideNetworksCursorInfo : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideNetworksCursorInfo;

        public readonly ToolBaseProxy _toolBaseProxy;

        public HideNetworksCursorInfo(IModContext context) : base(context)
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
            _toolBaseProxy.DisableNetToolCursorInfo = true;
            return true;
        }

        protected override bool OnDisable()
        {
            _toolBaseProxy.DisableNetToolCursorInfo = false;
            return true;
        }
    }
}