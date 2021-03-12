using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private BoundaryProvider playerBoundaryProvider;
    [SerializeField] private BoundaryProvider enemyBoundaryProvider;
    [SerializeField] private BulletPool playerBulletPool;
    [SerializeField] private BulletPool enemyBulletPool;
    [SerializeField] private BulletPool asteroidPool;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private Spawner spawner;


    private void Start()
    {
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