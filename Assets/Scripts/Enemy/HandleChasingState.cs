using UnityEngine;

public class HandleChasingState : HandleState
{
    private void Update()
    {
        if (!isActive) return;
        transform.LookAt(player.transform.position);
        navMeshAgent.isStopped = false;
    }

    public override void Enter()
    {
        isActive = true;
        if (runAnimationName != "") enemyAnimator.SetTrigger(runAnimationName);
        navMeshAgent.SetDestination(player.transform.position);
        hasCompleted = true;
    }

    public override void Exit()
    {
        isActive = false;
        if (runAnimationName != "") enemyAnimator.ResetTrigger(runAnimationName);
        hasCompleted = false;
    }

    public override void SetGameObject(GameObject gameObject)
    {
        return;
    }
}
