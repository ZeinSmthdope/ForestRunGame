using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlScript : MonoBehaviour
{
    private Transform player;
    private Animator enemyAnimator;
    private Rigidbody enemyRigid;
    public float movementSpeed = 3f;
    public string attackAnimationName = "Attack2";
    public string runForwardAnimationName = "Run Forward";
    public bool isDistracted = false;
    public bool isChasing = false;
    private GameObject distraction = null;

    private void Start() 
    {
        // Source: https://forum.unity.com/threads/c-ai-follow-chase.319332/
        enemyRigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        enemyAnimator = gameObject.GetComponent<Animator>();
        InvokeRepeating("ShouldEnemyBeDistracted", 0, 1.0f);
    }

    private void ShouldEnemyBeDistracted()
    {
        if (!isChasing) return; // Do nothing if not aggro'd
        if (isDistracted && !distraction.GetComponent<Collectible>().isOnMap) CancelDistraction();

        GameObject[] collectiblesOnTheMap = GameObject.FindGameObjectsWithTag("Collectible");
        // If Enemy is not currently distracted and there are collectibles on the map
        if (!isDistracted && collectiblesOnTheMap.Length > 0)
        {
            // Are any of the collectibles near the Enemy
            foreach (GameObject collectible in collectiblesOnTheMap)
            {
                // Case when a collectible has not been handled by the player
                if (!collectible.GetComponent<Collectible>().dirty) continue;

                // Case when collectible has been handled by the player & is nearby
                if (Vector3.Distance(transform.position, collectible.transform.position) < 5)
                {
                    // Distract the enemy
                    Debug.Log("[EnemyControlScript.cs] " + gameObject.name + " is near a distraction");
                    isDistracted = true;

                    // Save the distraction so we can reference it later
                    distraction = collectible;

                    // Distract the enemy for a random # of seconds
                    Invoke("CancelDistraction", Random.Range(1, 5));
                    break;
                }
            }
        }
    }

    private void CancelDistraction()
    {
        if (!distraction) return; 
        // Reset the state
        isDistracted = false;
        distraction.transform.position = new Vector3(0, 0, 0);
        distraction.GetComponent<Collectible>().isOnMap = false;
        distraction = null;
        Debug.Log("[EnemyControlScript.cs] " + gameObject.name + " is no longer distracted");
    }

    void Update()
    {
        if (distraction && !distraction.GetComponent<Collectible>().isOnMap) CancelDistraction(); // Handle case where distraction no longer on map and enemy is still distracted

        // If player is nearby, aggro
        if (Vector3.Distance(transform.position, player.transform.position) < 30)
        {
            isChasing = true;
        } else
        {
            enemyAnimator.SetTrigger("Idle");
        }

        if (!isChasing) return; // Do nothing if not aggro'd


        // Case when Enemy is distracted
        if (isDistracted)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true; // Prevent the Enemy from being thrown around if the collectible hits them
            if (Vector3.Distance(transform.position, distraction.transform.position) < 3)
            {
                if (runForwardAnimationName != "") enemyAnimator.ResetTrigger(runForwardAnimationName);
                if (attackAnimationName != "") enemyAnimator.ResetTrigger(attackAnimationName);
                enemyAnimator.SetTrigger("Idle");
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, distraction.transform.position, movementSpeed * Time.deltaTime);
                transform.LookAt(distraction.transform.position);
            }
            Debug.Log("[EnemyControlScript.cs] " + gameObject.name + " is distracted");
        }

        // Case when the Enemy is not distracted
        if (!isDistracted)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            if (Vector3.Distance(player.position, transform.position) < 5)
            {
                // Enemy is close to Player, show attack animation
                if (attackAnimationName != "") enemyAnimator.SetTrigger(attackAnimationName);
            } else
            {
                // Enemy is far from Player, show run animation
                if (runForwardAnimationName != "") enemyAnimator.SetTrigger(runForwardAnimationName);
            }

            Debug.Log("[EnemyControlScript.cs] " + gameObject.name + " is not distracted");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            transform.LookAt(player.transform.position, Vector3.up);
        }
    }
    
    /*
    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position; // See unity tutorial below for source
        if (burger.GetComponent<Collectible>().recentlyThrown == true)
        {
            if (Vector3.Distance(this.gameObject.transform.position, burger.gameObject.transform.position) < 5)
            {
                enemyAnimator.ResetTrigger(runForwardAnimationName);
                enemyAnimator.SetTrigger("Idle"); 
            }
        }
        else
        {
            enemyAnimator.ResetTrigger("Idle"); 

            if (direction.magnitude < 5)
            {
                if (attackAnimationName != "")
                {
                    enemyAnimator.SetTrigger(attackAnimationName);
                }
            }
            else
            {
                if (runForwardAnimationName != "")
                {
                    enemyAnimator.SetTrigger(runForwardAnimationName);
                }
            }
        }


        
    }
    */

    //public float visAngle = 30.0f;
    //public float attackDist = 10.0f;
    //public float visDist = 30.0f;

    /*   Source: https://learn.unity.com/tutorial/chasing-the-player-1#
     *   
     *   Good source to use to refine the bear's movements and attack scenarios. Started tutorial code below:
     *   
    public bool canSeePlayer()
    {
        Vector3 direction = player.position - bear.transform.position;
        float angle = Vector3.Angle(direction, bear.transform.forward);
        if(direction.magnitude < visDist && angle < visAngle)
        {
            return true; 
        }
        return false; 
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - bear.transform.position; 
        if(direction.magnitude < attackDist)
        {
            return true; 
        }
        return false; 
    }

    public class Pursue: State
    {
        //public Pursue(GameObject )
    }*/

}
