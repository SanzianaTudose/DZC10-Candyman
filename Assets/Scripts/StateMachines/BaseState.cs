using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseState
{
    public string bsName;

    protected StateMachine stateMachine;

    public BaseState(string _name, StateMachine _stateMachine)
    {
        this.bsName = _name;
        this.stateMachine = _stateMachine;
    }

    public virtual void Enter() {}
    public virtual void UpdateLogic() {}
    public virtual void UpdatePhysics() {}
    public virtual void Exit() {}
}
