using System;
using UniRx;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpawnable, IDealDamage
{
    [SerializeField] private int damage;
    [SerializeField] private Projectile projectile;
    [SerializeField] private HealthSystem healthSystem;
    public Transform SpawnableTransform => transform;
    public Projectile Projectile => projectile;

    public Action Despawn { get; set; }

    public void Init()
    {
        healthSystem.Init();
        healthSystem.OnDied += Despawn;
    }

    public int GetDamageAmount()
    {
        return damage;
    }

    public void OnDamageDone()
    {
        Despawn?.Invoke();
    }


    public void OnDespawned()
    {
        healthSystem.OnDied -= Despawn;
        projectile.StopMovement();
    }
}

public interface IDealDamage
{
    int GetDamageAmount();
    void OnDamageDone();
}