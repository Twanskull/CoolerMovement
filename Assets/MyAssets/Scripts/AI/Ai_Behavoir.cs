
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Behavoir : MonoBehaviour
{

    public enum AiStates { Idle, Patrol, Chase, Attack };
    public AiStates currentState = AiStates.Idle;
    NavMeshAgent agent => GetComponent<NavMeshAgent>();
    [SerializeField] Transform currentTarget;
    [SerializeField] Transform[] wayPoints;
    [Range(0f, 1f)][SerializeField] float wayPointstoppingdistance = 0.25f;
    [SerializeField] int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateBehavior(AiStates.Patrol);
    }


    public void UpdateBehavior(AiStates newState)
    {
        StopAllCoroutines();
        currentState = newState;
        switch (currentState)
        {
            case AiStates.Idle:
                UpdateTarget(transform);
                agent.isStopped = true;
                break;
            case AiStates.Patrol:
                StartCoroutine(FollowWayPoints());
                break;
            case AiStates.Chase:
                break;
            case AiStates.Attack:
                break;

            default:
                UpdateBehavior(AiStates.Idle);
                Debug.LogWarning("Invalid State, default to idle");
                break;


        }

    }

    IEnumerator FollowWayPoints()
    {

        if(wayPoints.Length == 0) 
        {
            UpdateBehavior(AiStates.Idle);
            agent.isStopped = true;
            yield break;
        }

        float distance = 0f;

        UpdateTarget(wayPoints[currentIndex].transform);

        while (true)
        {
            distance = Vector3.Distance(transform.position, currentTarget.position);
            print(distance);
            if (distance < wayPointstoppingdistance)
            {
                currentIndex = NextWayPoint(currentIndex);
                UpdateTarget(wayPoints[currentIndex].transform);
                print("arrive");
                //break;
            }
            yield return null;

        }
    }

    void UpdateTarget(Transform newTarget)
    {
        currentTarget = newTarget;
        agent.SetDestination(currentTarget.position);
    }

    int NextWayPoint(int currentIndex)
    {
        float newIndex = currentIndex + 1;
        newIndex = newIndex % wayPoints.Length;
        return (int)newIndex;
    }
    public void SetWayPointList(Transform[] setlist)
    {
        wayPoints = setlist;
        
    }

}