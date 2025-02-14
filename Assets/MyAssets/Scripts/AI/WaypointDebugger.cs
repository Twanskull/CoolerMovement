#if UNITY_EDITOR
using UnityEngine;
[ExecuteInEditMode]
public class WaypointDebugger : MonoBehaviour
{         

    [SerializeField] Transform[] waypoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateArray();
    }

    void Update()
    {
        if (waypoints.Length != transform.childCount) UpdateArray();
        
        for (int i = 0; i < waypoints.Length; i++)
        {
            int nextIndex = i + 1;
            nextIndex = nextIndex % waypoints.Length;
            nextIndex = nextIndex == 0 ? 1 : nextIndex;
            Debug.DrawLine(waypoints[i].position, waypoints[nextIndex].position, Color.blue);
        }
    }

    // Update is called once per frame
    void UpdateArray()
    {
        waypoints = GetComponentsInChildren<Transform>();
    }
}
#endif