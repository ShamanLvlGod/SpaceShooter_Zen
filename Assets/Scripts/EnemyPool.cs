using System;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private BoundaryProvider boundaryProvider;

    public override Enemy Get()
    {
        Enemy enemy = base.Get();
        enemy.Init(bulletPool, boundaryProvider);
        return enemy;
    }

    public override void ReturnObject(Enemy enemy)
    {
        enemy.OnDespawned();
        base.ReturnObject(enemy);
    }
}