using UnityEngine;
using UnityEngine.AI;

public class Patrol : Grounded
{
    public Patrol(EnemySM stateMachine) : base("Patrol", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // If the player is in range of the enemy vision move towards target
        if (sm.playerIsInRange())
        {
            sm.agent.isStopped = true;
            stateMachine.ChangeState(sm.lockInState);
        }

        startPatroling();
    }

    void startPatroling()
    {
        // If we are at the destination go to next point
        if (sm.agentHasReachedDestination())
        {
            // Loop back to start point when at the end
            if (sm.indexPatrol >= sm.patrolPoints.Length)
                sm.indexPatrol = 0;

            Transform movePoint = sm.patrolPoints[sm.indexPatrol];

            // Move towards the target
            sm.agent.SetDestination(movePoint.position);
            sm.indexPatrol++;

            // Face the target
            sm.FaceTarget(movePoint);
        }
    }
}
