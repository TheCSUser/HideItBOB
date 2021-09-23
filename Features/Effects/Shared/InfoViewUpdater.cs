using com.github.TheCSUser.Shared.Common;
using System;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.Effects.Shared
{
    internal sealed class InfoViewUpdater : WithContext
    {
        public static readonly Texture2D ResourceTexture = new Texture2D(512, 512, TextureFormat.RGB24, false, true) { wrapMode = TextureWrapMode.Clamp };
        public static readonly Texture2D DestructionTexture = new Texture2D(512, 512, TextureFormat.RGB24, false, true) { wrapMode = TextureWrapMode.Clamp };

        private static InfoManager.InfoMode _cachedInfoMode = InfoManager.InfoMode.None;

        public InfoViewUpdater(IModContext context) : base(context) { }

        public void Update()
        {
            try
            {
                if (InfoManager.exists && InfoManager.instance.CurrentMode != _cachedInfoMode)
                {
                    if (InfoManager.instance.CurrentMode == InfoManager.InfoMode.None)
                    {
                        if (NaturalResourceManager.exists)
                        {
                            if (NaturalResourceManager.instance.m_resourceTexture != null)
                            {
                                Shader.SetGlobalTexture("_NaturalResources", NaturalResourceManager.instance.m_resourceTexture);
                            }
                            if (NaturalResourceManager.instance.m_destructionTexture != null)
                            {
                                Shader.SetGlobalTexture("_NaturalDestruction", NaturalResourceManager.instance.m_destructionTexture);
                            }
                        }
                    }
                    else
                    {
                        if (ResourceTexture != null)
                        {
                            Shader.SetGlobalTexture("_NaturalResources", ResourceTexture);
                        }
                        if (DestructionTexture != null)
                        {
                            Shader.SetGlobalTexture("_NaturalDestruction", DestructionTexture);
                        }
                    }

                    _cachedInfoMode = InfoManager.instance.CurrentMode;
                }
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(InfoViewUpdater)}.{nameof(Update)} failed", e);
            }
        }
    }
}