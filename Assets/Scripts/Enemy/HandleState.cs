using UnityEngine;
using UnityEngine.AI;

abstract public class HandleState: MonoBehaviour
{
    public bool isActive = false;
    public bool hasCompleted = false;
    protected string attackAnimationName;
    protected string runAnimationName;
    protected string wanderingAnimationName;
    protected string idleAnimationName;
    protected string distractedAnimationName;
    protected GameObject enemy;
    protected GameObject player;
    protected Animator enemyAnimator;
    protected NavMeshAgent navMeshAgent;

    private void Awake()
    {
        player = GameObject.Find("Player");
        enemy = gameObject;
        enemyAnimator = gameObject.GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    abstract public void Enter();
    abstract public void Exit();
    abstract public void SetGameObject(GameObject gameObject);
    public void SetAnimations(string passedAttackAnimationName, string passedRunAnimationName, string passedWanderingAnimationName, string passedIdleAnimationName, string passedDistractedAnimationName)
    {
        attackAnimationName = passedAttackAnimationName;
        runAnimationName = passedRunAnimationName;
        wanderingAnimationName = passedWanderingAnimationName;
        idleAnimationName = passedIdleAnimationName;
        distractedAnimationName = passedDistractedAnimationName;
    }
}
