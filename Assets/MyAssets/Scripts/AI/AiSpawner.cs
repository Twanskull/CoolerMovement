using UnityEngine;
using System;

public class AiSpawner : MonoBehaviour
{
    [SerializeField] WayPointList[] WayPointsColl;
    //[SerializeField] Transform [] wayPoints2;
    [SerializeField] GameObject agentPrefab;
    [SerializeField] int maxAgents = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < maxAgents; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0,WayPointsColl.Length);
            GameObject go = Instantiate(agentPrefab, transform.position, Quaternion.identity, transform);
            Transform[] getlist = WayPointsColl[randomIndex].WayPoints;
            go.GetComponent<Ai_Behavoir>().SetWayPointList(getlist);
        }
    }

    
}

[Serializable]
class WayPointList
{
    public Transform[] WayPoints;
}