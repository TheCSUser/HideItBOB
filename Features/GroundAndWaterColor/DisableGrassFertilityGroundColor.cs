using com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor.Shared;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor
{
    internal sealed class DisableGrassFertilityGroundColor : FeatureBase
    {
        private const string ShaderName = "_GrassFertilityColorOffset";

        public override FeatureKey Key => FeatureKey.DisableGrassFertilityGroundColor;
        private Vector4 DefaultColorOffset = GroundColorOffset.None;

        public DisableGrassFertilityGroundColor(IModContext context) : base(context) { }

        protected override bool OnEnable()
        {
            if (DefaultColorOffset == GroundColorOffset.None) DefaultColorOffset = Shader.GetGlobalVector(ShaderName);
            Shader.SetGlobalVector(ShaderName, GroundColorOffset.None);
            return true;
        }
        protected override bool OnDisable()
        {
            Shader.SetGlobalVector(ShaderName, DefaultColorOffset);
            return true;
        }

    }
}