using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Attack : Grounded
{

    public Attack(EnemySM stateMachine) : base("Attack", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        sm.rend.sharedMaterial = sm.materials[3]; // red material
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        sm.FaceTarget(sm.target);   // Make sure to face towards the target

        // TODO Attack //
        // ........... //
        // TODO Attack //


        /*bool successfulDodge = true;
        if (successfulDodge)
            stateMachine.ChangeState(sm.idleState);
        else
            // TODO die or add to panicmeter
            return;*/
    }

}
