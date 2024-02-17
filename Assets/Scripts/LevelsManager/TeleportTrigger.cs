using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform teleportTarget;
    public bool enableFogOnTeleport = true; // Toggle this in the inspector
    public Color fogColor = Color.gray; // Set your preferred fog color
    public float fogDensity = 0.02f; // Set your preferred fog density

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportTarget.position;
            if (enableFogOnTeleport)
            {
                EnableFog();
            }
        }
    }

    private void EnableFog()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogDensity = fogDensity;
    }
}
