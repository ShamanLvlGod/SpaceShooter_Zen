using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    public override Bullet Get()
    {
        Bullet bullet = base.Get();
        bullet.Init();
        bullet.Projectile.StartMovement();
        return bullet;
    }

    public override void ReturnObject(Bullet bullet)
    {
        bullet.OnDespawned();
        base.ReturnObject(bullet);
    }
}