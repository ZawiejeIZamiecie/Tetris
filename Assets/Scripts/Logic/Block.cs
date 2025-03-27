using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.Move(rb.position + Vector3.down * Time.deltaTime, Quaternion.identity);
        rb.isKinematic = true;
        rb.isKinematic = false;
    }
}
