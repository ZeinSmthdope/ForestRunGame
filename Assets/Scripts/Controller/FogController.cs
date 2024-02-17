using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    public bool enableFog = true;
    public Color fogColor = Color.grey;
    public FogMode fogMode = FogMode.Exponential;
    public float fogDensity = 0.06f;
    public float linearFogStart = 0f;
    public float linearFogEnd = 300f;

    // Start is called before the first frame update
    void Start()
    {
        ApplyFogSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            enableFog = !enableFog;  // Toggle fog on/off
            ApplyFogSettings();
        }
    }

    void ApplyFogSettings()
    {
        RenderSettings.fog = enableFog;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogMode = fogMode;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fogStartDistance = linearFogStart;
        RenderSettings.fogEndDistance = linearFogEnd;
    }
}
