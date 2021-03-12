using System;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int healthPoints;
    [SerializeField] private LayerMask interactionLayers;
    public Action OnDied;
    private int hp;

    public void Init()
    {
        ResetHealth();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (((1 << other.gameObject.layer) & interactionLayers.value) != 0)
        {
            IDealDamage damageTaker = other.gameObject.GetComponent<IDealDamage>();
            if (damageTaker != null)
            {
                ApplyDamage(damageTaker);
            }
        }
    }

    public void ApplyDamage(IDealDamage dmgDealer)
    {
        hp -= dmgDealer.GetDamageAmount();
        dmgDealer.OnDamageDone();
        if (hp <= 0)
        {
            OnDied?.Invoke();
        }
    }

    public void ResetHealth()
    {
        hp = healthPoints;
    }
}


public interface ITakeDamage
{
    void ApplyDamage(IDealDamage dmgDealer);
}