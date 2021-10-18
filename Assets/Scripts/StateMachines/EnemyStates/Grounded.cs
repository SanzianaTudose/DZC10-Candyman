using UnityEngine;
using UnityEngine.AI;

public class Grounded : BaseState
{
    protected EnemySM sm;

    public Grounded(string name, EnemySM stateMachine) : base(name, stateMachine)
    {
        sm = (EnemySM) this.stateMachine;
    }
}
