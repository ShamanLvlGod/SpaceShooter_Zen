using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, ISpawnable
{
    [SerializeField] private Spaceship spaceship;
    [SerializeField] private Weapon weapon;
    [SerializeField] private HealthSystem healthSystem;
    private BoundaryProvider boundaryProvider;
    private Coroutine aiLoop;

    public Transform SpawnableTransform => transform;

    public Action Despawn { get; set; }

    public void Init(BulletPool bulletPool, BoundaryProvider boundaryProvider)
    {
        this.boundaryProvider = boundaryProvider;
        weapon.Init(bulletPool);
        healthSystem.Init();
        aiLoop = StartCoroutine(AIMachine());
        healthSystem.OnDied += Despawn;
    }

    private IEnumerator AIMachine()
    {
        spaceship.SetDirection(Vector2.up);
        while (true)
        {
            yield return WaitForManeuver();
            yield return MakeManeuver();
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator WaitForManeuver()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 1.9f));
    }

    private IEnumerator MakeManeuver()
    {
        Vector3 vel = spaceship.GetVelocity();
        weapon.Shoot();
        yield return new WaitForSeconds(0.1f);
        Vector3 target =
            boundaryProvider.GetClosest((spaceship.transform.position + spaceship.transform.forward.normalized * 6f) +
                                        spaceship.transform.right.normalized * Random.Range(-5, 5));
        yield return spaceship.MoveToTarget(target);
        spaceship.SetVelocity(vel);
    }

    public void OnDespawned()
    {
        StopCoroutine(aiLoop);
        spaceship.ResetShip();
        healthSystem.OnDied -= Despawn;
    }
}