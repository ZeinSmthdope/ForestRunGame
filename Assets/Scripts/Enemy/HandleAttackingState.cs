using UnityEngine;

public class HandleAttackingState : HandleState
{
    public string attackAudioName;
    private bool hasRecentlyAttacked = false;

    private void Update()
    {
        if (!isActive) return;
        transform.LookAt(player.transform.position);
        navMeshAgent.isStopped = false;
    }

    private void ResetHasRecentlyAttacked()
    {
        hasRecentlyAttacked = false;
    }

    public override void Enter()
    {
        isActive = true;
        if (attackAnimationName != "" && !hasRecentlyAttacked)
        {
            hasRecentlyAttacked = true;
            Invoke("ResetHasRecentlyAttacked", 4);
            EventManager.TriggerEvent<GenericEvent, string>(this.attackAudioName); // calls the character's attack audio
            enemyAnimator.SetTrigger(attackAnimationName);
        }
        
        navMeshAgent.SetDestination(player.transform.position);
        hasCompleted = true;
    }

    public override void Exit()
    {
        isActive = false;
        if (attackAnimationName != "") enemyAnimator.ResetTrigger(attackAnimationName);
        hasCompleted = false;
    }

    public override void SetGameObject(GameObject gameObject)
    {
        return;
    }
}
