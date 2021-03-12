using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour, ILevelSpawner
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private BoundaryProvider boundaryProvider;

    [SerializeField] private List<BasePool> spawnables;

    [Inject]
    void Init(BoundaryProvider boundaryProvider)
    {
        //this.boundaryProvider = boundaryProvider;
        Observable.Interval(TimeSpan.FromSeconds(2)).Subscribe(ONNext);
    }

    private void ONNext(long obj)
    {
        Spawn();
    }

    public void Spawn()
    {
        Transform enemy = spawnables[Random.Range(0, spawnables.Count)].GetBase();
        enemy.transform.position =
            new Vector3(
                spawnPoint.position.x +
                Random.Range(-boundaryProvider.Bounds.extents.x, boundaryProvider.Bounds.extents.x),
                spawnPoint.position.y, spawnPoint.position.z);
    }
}

public interface ILevelSpawner
{
    void Spawn();
}