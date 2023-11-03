using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Distract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void distraction(GameObject obj)
    {
        //if (Vector3.Distance(this.gameObject.transform.position, obj.transform.position) < 1 )
        //{
            this.gameObject.GetComponent<Animator>().SetBool("Run Forward", false); 
        //}
    }
}
