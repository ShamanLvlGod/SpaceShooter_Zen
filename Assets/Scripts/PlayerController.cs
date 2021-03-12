using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    [Inject] private InputProvider inputProvider;

    public void Init(BoundaryProvider boundaryProvider, BulletPool bulletPool)
    {
        player.Init(inputProvider, boundaryProvider, bulletPool);
    }
}