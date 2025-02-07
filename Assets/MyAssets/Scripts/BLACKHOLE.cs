using UnityEngine;

public class BLACKHOLE : MonoBehaviour
{


    float gravity = -9.81f;
    [SerializeField] float attractionforce = 9.81f;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        rb = col.GetComponent<Rigidbody>();
        


        

    }

    void OnTriggerStay(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        if (rb == null) return;

        Vector3 directionalGrav = transform.position - col.transform.position;
        directionalGrav = directionalGrav * attractionforce;
        directionalGrav += -gravity * Vector3.up;
       
        rb.AddForce(directionalGrav,ForceMode.Acceleration);

        
    }
}
