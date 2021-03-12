public class ForwardProjectile : Projectile
{
    public float StartVelocity => startVelocity.magnitude;

    public void SetForwardMovement(float vel)
    {
        rb.velocity = transform.forward * vel;
    }

    public override void StartMovement()
    {
        SetForwardMovement(StartVelocity);
    }
}