using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float launchforce = 10f;


    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;

        Rigidbody rb = col.GetComponent<Rigidbody>();
        if (rb == null) return;

        rb.AddForce(Vector3.up * launchforce,ForceMode.Impulse);
    }
}
