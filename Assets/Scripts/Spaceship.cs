using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class Spaceship : MonoBehaviour, IDealDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float tilt;
    [SerializeField] private Rigidbody rb;

    private Coroutine currentMove;

    public void SetDirectionalVelocity(Vector2 dir)
    {
        Vector3 direction = dir.ToVector3();

        // rb.velocity = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * direction;
        SetVelocity(Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * direction);
        rb.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, direction.x * -tilt);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
        rb.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, velocity.x * -tilt);
    }

    public void SetDirection(Vector2 dir)
    {
        SetDirectionalVelocity(dir * speed);
    }

    public void SetDirectionalVelocity(Vector3 dir)
    {
        SetDirectionalVelocity(new Vector2(dir.x, dir.z));
    }

    public Coroutine MoveToTarget(Vector3 targetPos)
    {
        if (currentMove != null)
        {
            StopCoroutine(currentMove);
        }

        if (IsTargetValid(targetPos))
        {
            currentMove = StartCoroutine(MoveToTargetCoroutine(targetPos));
        }

        return currentMove;
    }

    private IEnumerator MoveToTargetCoroutine(Vector3 target)
    {
        Vector3 vec = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * (target - transform.position);
        SetDirection(new Vector2(vec.normalized.x, vec.normalized.z));
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (Vector3.Distance(target, transform.position) < 0.1f)
            {
                currentMove = null;
                SetDirection(Vector2.zero);
                yield break;
            }
        }
    }

    static bool IsTargetValid(Vector3 target)
    {
        return true;
    }

    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }

    public void ResetShip()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = Vector3.zero;
        rb.rotation = Quaternion.Euler(0, 0, 0);
    }

    public int GetDamageAmount()
    {
        return 1;
    }

    public void OnDamageDone()
    {
    }
}

public static class Vector3Extensions
{
    public static Vector3 ToVector3(this Vector2 vec)
    {
        return new Vector3(vec.x, 0, vec.y);
    }
}