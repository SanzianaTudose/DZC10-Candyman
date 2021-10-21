using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChasePlayer : Grounded
{

    public ChasePlayer(EnemySM stateMachine) : base("ChasePlayer", stateMachine) { }

    public override void Enter() {
        base.Enter();
        sm.rend.sharedMaterial = sm.materials[2]; // orange material
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        // If the player is in range of the enemy vision move towards target
        if (sm.playerIsInRange())
            MoveTowardsTarget();
        else if (sm.agentHasReachedDestination())
            stateMachine.ChangeState(sm.idleState);
    }

    void MoveTowardsTarget() {
        // Move towards the target
        sm.agent.isStopped = false;
        sm.agent.SetDestination(sm.target.position);

        // Face the target
        sm.FaceTarget(sm.target);

        // If within attacking distance attack
        float _distance = Vector3.Distance(sm.target.position, sm.agent.transform.position);
        if (_distance <= sm.agent.stoppingDistance * 1.1f)
            stateMachine.ChangeState(sm.attackState);
    }
}
