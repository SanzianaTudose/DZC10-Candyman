using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    protected virtual void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

    private void OnGUI()
    {
        /*
        GUILayout.BeginArea(new Rect(15f, 15f, 200f, 100f));
        string content = currentState != null ? currentState.bsName : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();
        */
    }
}
