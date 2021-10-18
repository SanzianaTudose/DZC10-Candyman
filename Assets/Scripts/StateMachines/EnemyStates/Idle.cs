using UnityEngine;
using UnityEngine.AI;

public class Idle : Grounded
{
    public Idle(EnemySM stateMachine) : base("Idle", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
		sm.rend.sharedMaterial = sm.materials[0]; // green material
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

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
