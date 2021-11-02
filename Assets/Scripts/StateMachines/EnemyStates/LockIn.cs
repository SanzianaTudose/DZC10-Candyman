using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LockIn : Grounded
{
    public float hasBeenWaitingFor = 0;
    // currently the waiting time gets lower each time you enter reenter the enemy "LockIn" state
    // if we wanted to reset it you would do it in this enter state and make it equal to 0
    public LockIn(EnemySM stateMachine) : base("LockIn", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        sm.agent.GetComponentInParent<EnemySounds>().LockIn();

        waitToLockIn();

        if(!sm.playerIsInRange())
            stateMachine.ChangeState(sm.idleState);

    }
        
    void waitToLockIn()
    {
        hasBeenWaitingFor += Time.deltaTime;

        float waitTime = Random.Range(sm.lockInRange[0], sm.lockInRange[1]);
        if (hasBeenWaitingFor > waitTime)
        {
            hasBeenWaitingFor = 0;
            stateMachine.ChangeState(sm.chasePlayerState);
        }
    }
}
