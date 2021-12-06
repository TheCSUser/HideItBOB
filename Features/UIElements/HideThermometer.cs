using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideThermometer : ModifyUIComponentPositionByName
    {
        public override FeatureKey Key => FeatureKey.HideThermometer;

        private readonly SnowFallDLCEnabledCheck _snowFallDLCEnabled;
        public override bool IsAvailable => _snowFallDLCEnabled.Result;

        public HideThermometer(IModContext context) : base(context, "Heat'o'meter")
        {
            _treeAnarchyPanelObject = new Cached<GameObject>(GetTreeAnarchyPanelObject);
            _snowFallDLCEnabled = context.Resolve<SnowFallDLCEnabledCheck>();
            _treeAnarchyModCheck = context.Resolve<TreeAnarchyModEnabledCheck>();
        }
        protected override bool OnTerminate()
        {
            _snowFallDLCEnabled.Reset();
            return base.OnTerminate();
        }

        protected override Vector3? GetDesiredComponentPosition()
        {
            var defaultPos = DefaultComponentPosition;
            if (!defaultPos.HasValue) return null;
            return new Vector3(
                x: defaultPos.Value.x,
                y: Mod.Settings.HideThermometer ? defaultPos.Value.y - 0.1f : defaultPos.Value.y,
                z: defaultPos.Value.z
                );
        }

        #region TreeAnarchy mod compatibility
        private readonly TreeAnarchyModEnabledCheck _treeAnarchyModCheck;

        private readonly Vector3 _treeAnarchyPanelPositionOnEnabled = new Vector3(-0.245f, 0.1f, 0f);
        private readonly Vector3 _treeAnarchyPanelPositionOnDisabled = new Vector3(-0.245f, 0.0f, 0f);

        private readonly Cached<GameObject> _treeAnarchyPanelObject;

        protected override bool OnUpdate()
        {
            var result = base.OnUpdate();
            if (_treeAnarchyModCheck.Result)
            {
                var treeAnarchyPanel = _treeAnarchyPanelObject.Value;
                if (!(treeAnarchyPanel is null) && treeAnarchyPanel.transform.localPosition != _treeAnarchyPanelPositionOnEnabled)
                {
                    treeAnarchyPanel.transform.localPosition = _treeAnarchyPanelPositionOnEnabled;
                }
            }
            return result;
        }
        protected override bool OnDisable()
        {
            if (_treeAnarchyModCheck.Result)
            {
                var treeAnarchyPanel = _treeAnarchyPanelObject.Value;
                if (!(treeAnarchyPanel is null))
                {
                    treeAnarchyPanel.transform.localPosition = _treeAnarchyPanelPositionOnDisabled;
                }
                _treeAnarchyPanelObject.Invalidate();
            }
            return base.OnDisable();
        }

        private GameObject GetTreeAnarchyPanelObject()
        {
            var obj = GameObject.Find("Heat'o'meter")?.transform?.Find("IndicatorPanel")?.gameObject;
#if DEV || PREVIEW
            if (obj is null)
            {
                Log.Info($"{nameof(HideThermometer)}.{nameof(GetTreeAnarchyPanelObject)} could not find Heat'o'meter/IndicatorPanel.");
            }
#endif
            return obj;
        }
        #endregion
    }
}