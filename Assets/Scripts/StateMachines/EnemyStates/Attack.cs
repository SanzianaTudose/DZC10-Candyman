using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Attack : Grounded
{
    private PlayerMovement player;
    public PanicMeterController pMeter;
    private float addPanic = 0.0006f;
    private int eCount = 0;
    public Attack(EnemySM stateMachine) : base("Attack", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        sm.rend.sharedMaterial = sm.materials[3]; // red material
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        pMeter = GameObject.FindGameObjectWithTag("Meter").GetComponent<PanicMeterController>();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        sm.FaceTarget(sm.target);   // Make sure to face towards the target
        IncreasePanic();
        MiniGame();
  

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

    private void MiniGame()
    {
        player.speed = 0;

        if(Input.GetKeyDown(KeyCode.E))
        {
            eCount += 1;
            if(eCount > 20)
            {
                stateMachine.ChangeState(sm.idleState);
                player.speed = 10;
                eCount = 0;
            }
            
        }
    }
    //stateMachine.ChangeState(sm.idleState);

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
