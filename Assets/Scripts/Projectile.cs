using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected Vector3 startVelocity;
    [SerializeField] protected Rigidbody rb;
    private Quaternion startRotation;

    protected void Start()
    {
        startRotation = transform.rotation;
        StartMovement();
    }

    public virtual void StartMovement()
    {
        SetVelocity(startVelocity);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }


    public void StopMovement()
    {
        transform.rotation = startRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}