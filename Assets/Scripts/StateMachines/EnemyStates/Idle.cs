using UnityEngine;
using UnityEngine.AI;

public class Idle : Grounded
{
    private EnemyAnimatorController enemyAnimator;
    public Idle(EnemySM stateMachine) : base("Idle", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAnimatorController>();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        enemyAnimator.SetHitFalse();
        // If the player is in range of the enemy vision stop and lockIn
        if (sm.playerIsInRange())
            stateMachine.ChangeState(sm.lockInState);
        // Start patrol
        else if (sm.shouldPatrol)
        {
            sm.agent.isStopped = false;
            stateMachine.ChangeState(sm.patrolState);
        }

    }

}
