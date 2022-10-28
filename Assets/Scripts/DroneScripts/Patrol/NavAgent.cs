using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;
    private int destinationPoint = 0;
    public NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f){
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if(wayPoints.Length == 0){
            return;
        }

        agent.destination = wayPoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % wayPoints.Length;
    }
}
