using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateMachine : MonoBehaviour {
    public enum AIState
    {
        Attacking,
        Chasing,
        Distracted,
        Wandering
    }

    private int enemyDistractionDistance = 8;
    private int enemyAttackDistance = 3;
    private int enemyAggroDistance = 30;
    public string attackAnimationName = "Attack";
    public string runAnimationName = "Run Forward";
    public string wanderingAnimationName = "Walk";
    public string idleAnimationName = "Idle";
    public string distractedAnimationName = "Idle";
    public GameObject player;
    public AIState currentState;
    private HandleState activeHandler;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        decideState();
    }

    private AIState decideState()
    {
        // Early rtn if current state hasn't completed
        if (activeHandler && !activeHandler.hasCompleted) return currentState;

        GameObject[] collectiblesOnTheMap = GameObject.FindGameObjectsWithTag("Collectible");
        // If there are collectibles on the map
        if (collectiblesOnTheMap.Length > 0)
        {
            // Are any of the collectibles near the Enemy
            foreach (GameObject collectible in collectiblesOnTheMap)
            {
                // Case when a collectible has not been handled by the player
                if (!collectible.GetComponent<Collectible>().dirty) continue;

                // Case when collectible has been handled by the player & is nearby
                if (Vector3.Distance(transform.position, collectible.transform.position) < enemyDistractionDistance)
                {
                    // Distract the enemy
                    return changeState(AIState.Distracted, collectible);
                }
            }
        }

        // If player is very close, attack
        if (Vector3.Distance(transform.position, player.transform.position) <= enemyAttackDistance)
        {
            return changeState(AIState.Attacking);
        }

        // If player is nearby, chase
        if (Vector3.Distance(transform.position, player.transform.position) <= enemyAggroDistance)
        {
            return changeState(AIState.Chasing);
        }

        // Default to Wandering state
        return changeState(AIState.Wandering);
    }

    private AIState changeState(AIState state, GameObject relatedObject = null)
    {
        if (activeHandler && activeHandler.hasCompleted)
        {
            activeHandler.Exit();
        }

        switch (state)
        {
            case AIState.Attacking:
                activeHandler = gameObject.GetComponent<HandleAttackingState>();
                break;
            case AIState.Chasing:
                activeHandler = gameObject.GetComponent<HandleChasingState>();
                break;
            case AIState.Distracted:
                activeHandler = gameObject.GetComponent<HandleDistractedState>();
                break;
            case AIState.Wandering:
                activeHandler = gameObject.GetComponent<HandleWanderingState>();
                break;
        }

        currentState = state;
        if (relatedObject)
        {
            activeHandler.SetGameObject(relatedObject);
        }
        activeHandler.SetAnimations(attackAnimationName, runAnimationName, wanderingAnimationName, idleAnimationName, distractedAnimationName);
        activeHandler.Enter();

        return currentState;
    }
}
