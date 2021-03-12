using System;
using UniRx;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private Transform muzzleTransform;
    private BulletPool pool;
    private float lastFired;

    public void Init(BulletPool pool)
    {
        this.pool = pool;
    }

    public void Shoot()
    {
        if (Time.time - lastFired > fireRate)
        {
            Bullet bullet = pool.Get();
            bullet.transform.position = muzzleTransform.position;
            bullet.transform.rotation = Quaternion.Euler(0, muzzleTransform.eulerAngles.y, 0);
            lastFired = Time.time;
        }
    }
}