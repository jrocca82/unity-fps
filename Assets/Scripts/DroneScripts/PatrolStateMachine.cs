using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStateMachine : MonoBehaviour
{
    enum States
    {
        PATROL,
        ATTACK
    }

    States currentState = States.PATROL;

    private NavAgent dronePatrolling;

    private AttackPlayer droneAttacking;

    NavMeshAgent thisNavMesh;

    void Start()
    {
        dronePatrolling = GetComponent<NavAgent>();
        droneAttacking = GetComponent<AttackPlayer>();
        thisNavMesh = GetComponent<NavMeshAgent>();
        ChangeState(States.PATROL);
    }

    void Update()
    {
        if (droneAttacking.playerDetected == true)
        {
            ChangeState(States.ATTACK);
        }

        if (droneAttacking.playerDetected == false)
        {
            ChangeState(States.PATROL);
        }
    }

    void ChangeState(States stateVal)
    {
        if (currentState == stateVal)
        {
            return;
        }

        switch (stateVal)
        {
            case States.PATROL:
                {
                    dronePatrolling.enabled = true;
                    thisNavMesh.enabled = true;
                    break;
                }
            case States.ATTACK:
                {
                    dronePatrolling.enabled = false;
                    thisNavMesh.enabled = false;
                    break;
                }
            default:
                {
                    return;
                }
        }

        currentState = stateVal;
    }
}
