using System;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] LayerMask hitLayers;
    [SerializeField] float hitDistance;
    [SerializeField] bool debugMode = false;
    [SerializeField] float hitRadus = 0.5f;
    static public GroundDetection instance;
    Vector3 Debugposistion;

    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public bool IsGrounded(Vector3 Posistion)
    {
        if (Physics.SphereCast(Posistion,hitRadus, Vector3.down, out RaycastHit hit, hitDistance, hitLayers))
        {
            if (debugMode)
            {
                Debug.DrawRay(Posistion, Vector3.down * hitDistance, Color.green,0.1f);
                print("Hit ground");
                Debugposistion = hit.point;
            }
            return true;
        }
       if (debugMode)
       {
            Debugposistion = Posistion;
            Debug.DrawRay(Posistion, Vector3.down * 0.5f, Color.red,0.1f);
       } 
        return false;
    }

    
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if(!debugMode) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Debugposistion, hitRadus);
        
    } 
#endif
}
