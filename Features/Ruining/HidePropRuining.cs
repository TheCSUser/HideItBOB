using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Ruining
{
    internal sealed class HidePropRuining : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HidePropRuining;

        private readonly ICheck _compatibilityCheck;
        public override bool IsAvailable => _compatibilityCheck.Result;

        public HidePropRuining(IModContext context) : base(context)
        {
            _compatibilityCheck = context.Resolve<BOBModDisabledCheck>();
        }

        protected override bool OnTerminate()
        {
            _compatibilityCheck.Reset();
            return base.OnTerminate();
        }

        protected override bool OnEnable()
        {
            PropInfo propInfo;
            for (uint i = 0; i < PrefabCollection<PropInfo>.LoadedCount(); i++)
            {
                propInfo = PrefabCollection<PropInfo>.GetPrefab(i);
                if (!(propInfo is null) && propInfo.m_createRuining)
                {
                    propInfo.m_createRuining = false;
                }
            }
            return true;
        }
        protected override bool OnDisable()
        {
            PropInfo propInfo;
            for (uint i = 0; i < PrefabCollection<PropInfo>.LoadedCount(); i++)
            {
                propInfo = PrefabCollection<PropInfo>.GetPrefab(i);
                if (!(propInfo is null) && !propInfo.m_createRuining)
                {
                    propInfo.m_createRuining = true;
                }
            }
            return true;
        }
    }
}