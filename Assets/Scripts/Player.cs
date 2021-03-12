using UniRx;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Spaceship spaceship;
    [SerializeField] private Weapon weapon;
    [SerializeField] private HealthSystem healthSystem;
    private BoundaryProvider boundaryProvider;

    public void Init(InputProvider inputProvider, BoundaryProvider boundaryProvider, BulletPool bulletPool)
    {
        this.boundaryProvider = boundaryProvider;
        weapon.Init(bulletPool);
        healthSystem.Init();
        inputProvider.OnAttackAxisChangedAsObservable().Subscribe(x => { weapon.Shoot(); });
        inputProvider.OnAxisChangedAsObservable().Subscribe(Move);
        healthSystem.OnDied += () => { Debug.LogError("Deeeeeeeeeeeed"); };
    }

    void Move(Vector2 dir)
    {
        spaceship.SetDirection(dir);

        spaceship.transform.position =
            boundaryProvider.GetClosest(spaceship.transform.position);
    }
}