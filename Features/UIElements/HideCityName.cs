﻿using ColossalFramework;
using ColossalFramework.UI;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideCityName : UpdatableFeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideCityName;

        private string _backgroundSprite = null;

        private readonly Cached<UILabel> ComponentCache;

        public HideCityName(IModContext context) : base(context)
        {
            ComponentCache = new Cached<UILabel>(() =>
            {
                var infoPanel = GameObject.Find("InfoPanel")?.GetComponent<UIComponent>();
                if (infoPanel is null)
                {
                    IncreaseErrorCount();
#if DEV || PREVIEW
                    Log.Warning($"{GetType().Name}.{nameof(ComponentCache)} could not find InfoPanel, current error count is {ErrorCount}.");
#endif
                    return null;
                }
                var name = infoPanel.Find("Name")?.GetComponentInChildren<UILabel>();
                if (name is null)
                {
                    IncreaseErrorCount();
#if DEV || PREVIEW
                    Log.Warning($"{GetType().Name}.{nameof(ComponentCache)} could not find Name, current error count is {ErrorCount}.");
#endif
                }
                return name;
            }, int.MaxValue);
        }

        private UILabel GetComponent() => ComponentCache.Value;

        protected override bool OnEnable()
        {
            var cityNameLabel = GetComponent();
            if (cityNameLabel is null) return false;
            if (string.IsNullOrEmpty(cityNameLabel.text)) return true;

            if (_backgroundSprite is null) _backgroundSprite = cityNameLabel.backgroundSprite;
            cityNameLabel.backgroundSprite = null;
            cityNameLabel.text = "";
            return true;
        }
        protected override bool OnDisable()
        {
            var cityNameLabel = GetComponent();
            if (cityNameLabel is null) return false;
            if (!string.IsNullOrEmpty(cityNameLabel.text)) return true;

            cityNameLabel.backgroundSprite = _backgroundSprite;
            cityNameLabel.text = Singleton<SimulationManager>.exists ? Singleton<SimulationManager>.instance.m_metaData.m_CityName : "";
            IsError = false;
            ComponentCache.Invalidate();
            return true;
        }

        protected override bool OnUpdate() => OnEnable();
    }
}