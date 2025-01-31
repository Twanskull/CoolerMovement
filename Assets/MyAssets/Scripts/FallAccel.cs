using UnityEngine;

public class FallAccel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float FallAcceleration = 9.8f;
    Rigidbody rb => GetComponent<Rigidbody>();
    Vector3 oldPos;

    // Update is called once per frame
    void LateUpdate()
    {
        if(rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * FallAcceleration * Time.deltaTime;
        }
    }
}
