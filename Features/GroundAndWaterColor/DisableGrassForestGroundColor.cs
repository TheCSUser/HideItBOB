using com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor.Shared;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor
{
    internal sealed class DisableGrassForestGroundColor : FeatureBase
    {
        private const string ShaderName = "_GrassForestColorOffset";

        public override FeatureKey Key => FeatureKey.DisableGrassForestGroundColor;
        private Vector4 DefaultColorOffset;

        public DisableGrassForestGroundColor(IModContext context) : base(context) { }

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