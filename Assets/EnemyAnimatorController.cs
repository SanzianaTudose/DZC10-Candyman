using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetAttack()
    {
        anim.SetBool("Attack", true);
    }

    public void SetAttackFalse()
    {
        anim.SetBool("Attack", false);
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
        anim.SetBool("lock", true);
    }

    public void SetLockFalse()
    {
        anim.SetBool("lock", false);
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
