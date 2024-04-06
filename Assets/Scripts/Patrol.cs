using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;

    private int _currentPoint;

    private void Start ()
    {
        navMeshAgent.SetDestination (waypoints[0].position);
    }

    private void Update ()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _currentPoint = (_currentPoint + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[_currentPoint].position);
        }
    }
}
