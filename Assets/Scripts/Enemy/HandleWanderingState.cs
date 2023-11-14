using UnityEngine;
using UnityEngine.AI;

public class HandleWanderingState : HandleState
{
    private int wanderDistance = 20;
    private int wanderTime = 0;
    private int maxWanderTime = 3;
    private bool idleWander = false;


    private void Update()
    {
        if (!isActive) return;
        if (navMeshAgent.remainingDistance <= 3 && !navMeshAgent.pathPending && !idleWander)
        {
            navMeshAgent.isStopped = true;
            if (wanderingAnimationName != "") enemyAnimator.ResetTrigger(wanderingAnimationName);
            if (idleAnimationName != "") enemyAnimator.SetTrigger(idleAnimationName);
            idleWander = true;
            Invoke("CompleteIdle", 1);
        }
    }

    private void CountWanderTime()
    {
        wanderTime += 1;
        if (wanderTime >= maxWanderTime) CompleteIdle();
    }

    private void CompleteIdle()
    {
        CancelInvoke();
        if (idleAnimationName != "") enemyAnimator.ResetTrigger(idleAnimationName);
        idleWander = false;
        hasCompleted = true;
        navMeshAgent.isStopped = false;
    }

    public override void Enter()
    {
        navMeshAgent.isStopped = false;
        idleWander = false;
        isActive = true;
        hasCompleted = false;
        InvokeRepeating("CountWanderTime", 0, 1);
        navMeshAgent.SetDestination(RandomPoint(navMeshAgent.transform.position, wanderDistance));
        if (wanderingAnimationName != "") enemyAnimator.SetTrigger(wanderingAnimationName);
    }

    public override void Exit()
    {
        idleWander = false;
        wanderTime = 0;
        navMeshAgent.ResetPath();
        isActive = false;
        hasCompleted = true;
        CancelInvoke();
        if (wanderingAnimationName != "") enemyAnimator.ResetTrigger(wanderingAnimationName);
    }

    public override void SetGameObject(GameObject gameObject)
    {
        return;
    }

    public static Vector3 RandomPoint(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);

        return navHit.position;
    }
}
