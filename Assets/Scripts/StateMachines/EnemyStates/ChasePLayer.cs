using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChasePlayer : Grounded
{
    public PanicMeterController pMeter;
    private float addPanic = 0.0002f;
    private EnemyAnimatorController enemyAnimator;

    public ChasePlayer(EnemySM stateMachine) : base("ChasePlayer", stateMachine) { }

    public override void Enter() {
        base.Enter();
        pMeter = GameObject.FindGameObjectWithTag("Meter").GetComponent<PanicMeterController>();
        enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAnimatorController>();
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        enemyAnimator.SetLockFalse();
        enemyAnimator.SetChase();

        // If the player is in range of the enemy vision move towards target
        if (sm.playerIsInRange())
        {
            sm.agent.GetComponentInParent<EnemySounds>().Chase();

            MoveTowardsTarget();
            IncreasePanic();
        }
            
        else if (sm.agentHasReachedDestination())
        {
            stateMachine.ChangeState(sm.idleState);
        }
            

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


    private void IncreasePanic()
    {

        if (pMeter != null && pMeter.panicMeter.value <= 100)
        {
            pMeter.panicMeter.value += addPanic;

        }
        else
        {
            Debug.Log("panic meter is null");
        }

    }


   
}
