using System;
using BepInEx;
using UnityEngine;

namespace GorillaShaders
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.notfishvr.gorillashaders", "GorillaShaders", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Update()
        {
            MakeLightSources(true);
        }
        private void MakeLightSource(VRRig player)
        {
            if (player.GetComponentInChildren<Light>() == null)
            {
                Light light = new GameObject("GorillaShaders").AddComponent<Light>();
                light.transform.SetParent(player.transform);
                light.transform.localPosition = new Vector3(-0.1f, 0.9f, 0.3f);
                light.range = 20f;
                light.intensity = 2f;
            }
        }
        private void MakeLightSources(bool checkExisting = false)
        {
            VRRig[] vrrigs = GameObject.FindObjectsOfType<VRRig>();
            foreach (VRRig vrrig in vrrigs)
            {
                if (!checkExisting || vrrig.GetComponentInChildren<Light>() == null)
                {
                    MakeLightSource(vrrig);
                }
            }
        }
    }
}