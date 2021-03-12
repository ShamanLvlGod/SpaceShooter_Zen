using System;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    private BulletPool bulletPool;
    private BoundaryProvider boundaryProvider;

    public void Init(BulletPool bulletPool, BoundaryProvider boundaryProvider)
    {
        this.bulletPool = bulletPool;
        this.boundaryProvider = boundaryProvider;
    }

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