using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script's only purpose in life is to disable
 * the time scale at the beginning of a loaded scene.
 */
public class DisableGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Disabling time scale");
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
