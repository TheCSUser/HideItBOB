using com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor.Shared;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor
{
    internal sealed class DisableGrassFieldGroundColor : FeatureBase
    {
        private const string ShaderName = "_GrassFieldColorOffset";

        public override FeatureKey Key => FeatureKey.DisableGrassFieldGroundColor;
        private Vector4 DefaultColorOffset;

        public DisableGrassFieldGroundColor(IModContext context) : base(context) { }

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