using ColossalFramework;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Imports;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.Effects.Base
{
    internal abstract class HideFog : UpdatableFeatureBase
    {
        private readonly float?[] _values;

        private readonly Cached<FogProperties> _fogProperties;
        protected FogProperties FogProperties => _fogProperties.Value;
        private readonly Cached<FogEffect> _fogEffect;
        protected FogEffect FogEffect => _fogEffect.Value;
        private readonly Cached<RenderProperties> _renderProperties;
        protected RenderProperties RenderProperties => _renderProperties.Value;

        public HideFog(IModContext context, byte values = 0) : base(context)
        {
            _fogProperties = new Cached<FogProperties>(() => Object.FindObjectOfType<FogProperties>(), int.MaxValue);
            _fogEffect = new Cached<FogEffect>(() => Object.FindObjectOfType<FogEffect>(), int.MaxValue);
            _renderProperties = new Cached<RenderProperties>(() => Singleton<RenderManager>.exists ? Singleton<RenderManager>.instance.m_properties : null, int.MaxValue);

            _values = new float?[values];
        }

        protected sealed override bool OnEnable()
        {
            if (FogProperties is null || FogEffect is null) return false;

            SaveValues();
            SetEnabledValues();
#if DEV
            if (_values.Length > 0) Log.Info($"{nameof(HideVolumeFog)}.{nameof(_values)} {ObjectDumper.Dump(_values)}");
#endif
            return true;
        }
        protected sealed override bool OnUpdate()
        {
            if (FogProperties is null || FogEffect is null) return false;

            SetEnabledValues();
            return true;
        }
        protected sealed override bool OnDisable()
        {
            SetDisabledValues();

            _fogProperties.Invalidate();
            _fogEffect.Invalidate();
            _renderProperties.Invalidate();
            return true;
        }

        protected abstract void SaveValues();
        protected abstract void SetEnabledValues();
        protected abstract void SetDisabledValues();


        protected void Save(byte index, float? value) => _values[index] = value;
        protected bool HasValue(byte index) => _values[index].HasValue;
        protected float Restore(byte index) => _values[index] ?? 0.0f;
    }
}