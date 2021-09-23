using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Ruining
{
    internal sealed class HideTreeRuining : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideTreeRuining;

        private readonly ICheck _compatibilityCheck;
        public override bool IsAvailable => _compatibilityCheck.Result;

        public HideTreeRuining(IModContext context) : base(context)
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
            TreeInfo treeInfo;
            for (uint i = 0; i < PrefabCollection<TreeInfo>.LoadedCount(); i++)
            {
                treeInfo = PrefabCollection<TreeInfo>.GetPrefab(i);
                if (!(treeInfo is null) && treeInfo.m_createRuining)
                {
                    treeInfo.m_createRuining = false;
                }
            }
            return true;
        }
        protected override bool OnDisable()
        {
            TreeInfo treeInfo;
            for (uint i = 0; i < PrefabCollection<TreeInfo>.LoadedCount(); i++)
            {
                treeInfo = PrefabCollection<TreeInfo>.GetPrefab(i);
                if (!(treeInfo is null) && !treeInfo.m_createRuining)
                {
                    treeInfo.m_createRuining = true;
                }
            }
            return true;
        }
    }
}