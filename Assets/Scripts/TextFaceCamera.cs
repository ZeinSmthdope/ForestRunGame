using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFaceCamera : MonoBehaviour
{
    public GameObject Text;

    // Update is called once per frame
    void Update()
    {
        if (Text != null)
        {
            Text.transform.LookAt(Camera.main.transform.position);
            Text.transform.Rotate(0, 180, 0);
        }
    }
}
