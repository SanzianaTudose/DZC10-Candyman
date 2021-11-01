using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemySM : StateMachine
{
    [Header("Patroling")]
    public bool shouldPatrol;
    public Transform[] patrolPoints;
    [HideInInspector] public int indexPatrol;

    [Header("Values")]
    public float lookRadius = 5f;  // Detection range for player
    public float[] lockInRange;
    public Rigidbody rigidBody;
    public Material[] materials;

    [HideInInspector] public Transform target = null;   // Reference to the player
    [HideInInspector] public NavMeshAgent agent = null;

    [HideInInspector] public Idle idleState;
    [HideInInspector] public LockIn lockInState;
    [HideInInspector] public ChasePlayer chasePlayerState;
    [HideInInspector] public Attack attackState;
    [HideInInspector] public Patrol patrolState;

    public bool playerInRange;

    protected override void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        indexPatrol = 0;

        playerInRange = false;

        base.Start();

        if (SetPlayerAttributes.LockInMax != float.NaN && SetPlayerAttributes.LockInMax != 0 && SetPlayerAttributes.LockInMin != float.NaN && SetPlayerAttributes.LockInMin != 0)
        {
            lockInRange[0] = SetPlayerAttributes.LockInMin;
            lockInRange[1] = SetPlayerAttributes.LockInMax;
        }
    }

    private void Awake()
    {
        idleState = new Idle(this);
        lockInState = new LockIn(this);
        chasePlayerState = new ChasePlayer(this);
        attackState = new Attack(this);
        patrolState = new Patrol(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    // Rotate to face the target
    public void FaceTarget(Transform _target)
    {
        Vector3 direction = (_target.position - agent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public bool agentHasReachedDestination()
    {
        if (!agent.pathPending)
            if (agent.remainingDistance <= agent.stoppingDistance)
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    return true;

        return false;
    }

    public bool playerIsInRange() 
    {
        return playerInRange;
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
