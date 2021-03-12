using UniRx;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Spaceship spaceship;
    [SerializeField] private Weapon weapon;
    [SerializeField] private HealthSystem healthSystem;
    private BoundaryProvider boundaryProvider;

    [Inject]
    public void Init(BulletPool bulletPool, InputProvider inputProvider, BoundaryProvider boundaryProvider)
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