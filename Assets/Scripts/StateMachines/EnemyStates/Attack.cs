using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class Attack : Grounded
{
    private PlayerController player;
    public PanicMeterController pMeter;
    private SpamController sPrompt;
    private float addPanic = 0.0006f;
    private int eCount = 0;
    public Attack(EnemySM stateMachine) : base("Attack", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        pMeter = GameObject.FindGameObjectWithTag("Meter").GetComponent<PanicMeterController>();
        sPrompt = GameObject.FindGameObjectWithTag("Spam").GetComponent<SpamController>();
        player = sm.target.gameObject.GetComponent<PlayerController>();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        sm.agent.GetComponentInParent<EnemySounds>().Attack();

        sm.FaceTarget(sm.target);   // Make sure to face towards the target
        IncreasePanic();
        MiniGame();

    }

    private void MiniGame()
    {
        sPrompt.appear = true;
        player.speed = 0;
        if (Input.GetKeyDown(KeyCode.E))
        {
            eCount += 1;
            if(eCount > 20)
            {
                sPrompt.appear = false;
                stateMachine.ChangeState(sm.idleState);
                player.speed = player.defaultSpeed;
                eCount = 0;
            }
            
        }
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
