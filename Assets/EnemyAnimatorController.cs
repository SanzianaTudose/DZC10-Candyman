using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetAttack()
    {
        anim.SetTrigger("attack");
    }

    public void AttackTriggerF()
    {
        anim.ResetTrigger("attack");
    }


    public void SetHit()
    {
        anim.SetBool("hit", true);
    }

    public void SetHitFalse()
    {
        anim.SetBool("hit", false);
    }

    public void SetLock()
    {
        anim.SetBool("lockin", true);
    }

    public void SetLockTrigger()
    {
        anim.SetBool("lockin", false);
    }

    public void SetChase()
    {
        anim.SetBool("chase", true);
    }

    public void SetChaseFalse()
    {
        anim.SetBool("chase", false);
    }
    public void SetPatrol()
    {
        anim.SetBool("patrol", true);
    }

    public void SetPatrolFalse()
    {
        anim.SetBool("patrol", false);
    }
}
