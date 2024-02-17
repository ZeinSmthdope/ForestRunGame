using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacterScript : MonoBehaviour
{
    public GameObject character;
    private Vector3 offset;
    private Vector3 newPosition;

    void Start()
    {
        offset.x = transform.position.x - character.transform.position.x;
        offset.y = transform.position.y - character.transform.position.y;
        offset.z = transform.position.z - character.transform.position.z;
        newPosition = transform.position;
    }
    void LateUpdate()
    {
        newPosition.x = character.transform.position.x + offset.x;
        newPosition.y = character.transform.position.y + offset.y;
        newPosition.z = character.transform.position.z + offset.z;
        transform.position = newPosition;
    }

}
