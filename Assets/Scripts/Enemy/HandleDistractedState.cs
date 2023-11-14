using UnityEngine;

public class HandleDistractedState : HandleState
{
    private bool isDistracted = false;
    private GameObject distraction = null;

    private void Update()
    {
        if (!isActive) return;
        if (hasCompleted || !distraction) return;
        transform.LookAt(distraction.transform.position);

        if (!distraction.GetComponent<Collectible>().isOnMap)
        {
            hasCompleted = true;
            return;
        }

        if (!isDistracted)
        {
            navMeshAgent.SetDestination(distraction.transform.position);
        }

        if (navMeshAgent.remainingDistance <= 1 && !navMeshAgent.pathPending)
        {
            if (distractedAnimationName != "") enemyAnimator.SetTrigger(distractedAnimationName);
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }
    }

    public override void Enter()
    {
        isActive = true;
        Invoke("Exit", Random.Range(2, 6));
        hasCompleted = false;
        isDistracted = true;
        return;
    }

    public override void Exit()
    {
        CancelInvoke();
        isActive = false;
        if (hasCompleted) return;
        if (distractedAnimationName != "") enemyAnimator.ResetTrigger(distractedAnimationName);
        distraction.transform.position = new Vector3(0, 0, 0);
        distraction.GetComponent<Collectible>().isOnMap = false;
        distraction = null;
        isDistracted = false;
        hasCompleted = true;
        navMeshAgent.isStopped = false;
        navMeshAgent.ResetPath();
    }

    public override void SetGameObject(GameObject gameObject)
    {
        distraction = gameObject;
    }
}
