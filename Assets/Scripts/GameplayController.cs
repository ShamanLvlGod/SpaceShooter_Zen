using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private BoundaryProvider playerBoundaryProvider;
    [SerializeField] private BoundaryProvider enemyBoundaryProvider;
    [SerializeField] private BulletPool playerBulletPool; // Pool Factory?
    [SerializeField] private BulletPool enemyBulletPool;
    [SerializeField] private BulletPool asteroidPool;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private Spawner spawner;

    [SerializeField] private PlayerController playerController;

    [Inject]
    void Init()
    {
        playerController.Init(playerBoundaryProvider, playerBulletPool);
        enemyPool.Init(enemyBulletPool, enemyBoundaryProvider);
        spawner.Init(enemyBoundaryProvider);
    }
}

public class Model
{
}

public class View
{
}

public class Presenter
{
    [SerializeField] private View view;
}

public class ViewController
{
}