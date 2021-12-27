using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.Shared.Checks;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Ruining
{
    internal sealed class HideTreeRuining : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideTreeRuining;

        private readonly ModCheck _check;
        public override bool IsAvailable => _check.IsDisabled;

        public HideTreeRuining(IModContext context) : base(context)
        {
            _check = context.Resolve<ModCheck>(Mods.BOB);
        }

        protected override bool OnTerminate()
        {
            _check.Reset();
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