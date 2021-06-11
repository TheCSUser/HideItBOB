﻿using ColossalFramework;
using System;
using UnityEngine;

namespace HideItBobby
{
    public static class RuiningHelper
    {
        public static void UpdateExistingTreesRuining(bool disableRuining)
        {
            try
            {
                TreeInstance[] treeInstances = Singleton<TreeManager>.instance.m_trees.m_buffer;

                float minX;
                float minZ;
                float maxX;
                float maxZ;

                if (treeInstances != null)
                {
                    foreach (TreeInstance treeInstance in treeInstances)
                    {
                        if ((treeInstance.m_flags & 1) == 1 && (treeInstance.m_flags & 4) == 0 && treeInstance.Info != null && treeInstance.Position != null)
                        {
                            treeInstance.Info.m_createRuining = !disableRuining;

                            minX = treeInstance.Position.x - 4f;
                            minZ = treeInstance.Position.z - 4f;
                            maxX = treeInstance.Position.x + 4f;
                            maxZ = treeInstance.Position.z + 4f;
                            TerrainModify.UpdateArea(minX, minZ, maxX, maxZ, heights: false, surface: true, zones: false);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide it, BOBby!] RuiningHelper:UpdateExistingTreesRuining -> Exception: " + e.Message);
            }
        }

        public static void UpdateExistingPropsRuining(bool disableRuining)
        {
            try
            {
                PropInstance[] propInstances = Singleton<PropManager>.instance.m_props.m_buffer;

                float minX;
                float minZ;
                float maxX;
                float maxZ;

                if (propInstances != null)
                {
                    foreach (PropInstance propInstance in propInstances)
                    {
                        if ((propInstance.m_flags & 1) == 1 && (propInstance.m_flags & 4) == 0 && propInstance.Info != null && propInstance.Position != null)
                        {
                            propInstance.Info.m_createRuining = !disableRuining;

                            minX = propInstance.Position.x - 4.5f;
                            minZ = propInstance.Position.z - 4.5f;
                            maxX = propInstance.Position.x + 4.5f;
                            maxZ = propInstance.Position.z + 4.5f;
                            TerrainModify.UpdateArea(minX, minZ, maxX, maxZ, heights: false, surface: true, zones: false);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide it, BOBby!] RuiningHelper:UpdateExistingPropsRuining -> Exception: " + e.Message);
            }
        }
    }
}
