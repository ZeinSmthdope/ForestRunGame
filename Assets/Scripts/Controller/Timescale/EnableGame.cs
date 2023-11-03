using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script's only purpose in life is to enable
 * the time scale at the beginning of a loaded scene.
 */
public class EnableGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enabling time scale");
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
