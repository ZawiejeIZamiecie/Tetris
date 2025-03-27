using UnityEngine;

public class Figure : MonoBehaviour
{
    [SerializeField]
    GameObject figureSegemented;

    [SerializeField]
    public Sprite icon;

    Rigidbody rb;

    bool spawned;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(rb)
            rb.Move(rb.position + Vector3.down * Time.deltaTime, Quaternion.identity);
    }

    public void Move(Vector2 vector2)
    {
        if(rb)
            rb.Move(rb.position + new Vector3(vector2.x, 0) * Time.deltaTime * -1, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!spawned)
        {
            if (collision.gameObject.tag == "Block")
            {
                Instantiate(figureSegemented, transform.position, Quaternion.identity);
                Destroy(gameObject);
                spawned = true;
            }
        }
    }
}
