using ColossalFramework.UI;
using com.github.TheCSUser.Shared.Common;
using System.Collections.Generic;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideSeparators : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideSeparators;

        public HideSeparators(IModContext context) : base(context) { }

        protected override bool OnEnable()
        {
            foreach (var component in GetComponents())
            {
                if (!(component is null))
                {
                    component.isVisible = false;
                }
            }
            return true;
        }
        protected override bool OnDisable()
        {
            foreach (var component in GetComponents())
            {
                if (!(component is null))
                {
                    component.isVisible = true;
                }
            }
            return true;
        }

        private IEnumerable<UIComponent> GetComponents()
        {
            var parent = GameObject
                .Find("MainToolstrip")
                ?.GetComponent<UIComponent>();

            if (parent is null) yield break;

            foreach (var component in parent.components)
            {
                if (!(component is null)
                    && (component.name.Equals("Separator")
                    || component.name.Equals("SmallSeparator")))
                {
                    yield return component;
                }
            }
        }
    }
}