using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal abstract class HideDecorations : UpdatableFeatureBase
    {
        protected TerrainProperties TerrainProperties => TerrainManager.exists ? TerrainManager.instance.m_properties : null;

        public HideDecorations(IModContext context) : base(context) { }

        public override FeatureFlags Update()
        {
            if (IsDisposed || IsError || !IsAvailable || !IsInitialized) return Result(false);
            try
            {
                var result = OnUpdate();
                return Result(result, true);
            }
            catch (Exception e)
            {
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnUpdate)} failed", e);
                return Result(false);
            }
        }

        protected override bool OnEnable() => OnUpdate();
        protected override bool OnDisable() => OnUpdate();
    }
}
