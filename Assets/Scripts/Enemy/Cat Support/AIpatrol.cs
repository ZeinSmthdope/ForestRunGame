using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIpatrol : MonoBehaviour

{
    //Source https://www.youtube.com/watch?v=-Iwsz4gdgyQ

    
    private Animator anim;
    private Rigidbody rbody;

    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;



    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    /* 
    In case we want to make the cat jump
    public float jumpableGroundNormalMaxAngle = 45f;
    public bool closeToJumpableGround;
    

    private int groundContactCount = 0;

    public bool IsGrounded
    {
        get
        {
            return groundContactCount > 0;
        }
    }*/

    void Awake()
    {

        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.Log("Animator could not be found");

        rbody = GetComponent<Rigidbody>();

        if (rbody == null)
            Debug.Log("Rigid body could not be found");

    }
    


    // Start is called before the first frame update
    void Start()
    {
        anim.applyRootMotion = false;
        agent = GetComponent<NavMeshAgent>();
        //For cat to chase
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDestination();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchForDestination()
    {

        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);
        float y = groundLayer;

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
