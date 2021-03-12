using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class SceneInstaller : MonoInstaller
{
    [SerializeField] private InputProvider inputProvider;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private BoundaryProvider boundaryProvider;

    public override void InstallBindings()
    {
        Container.BindInstance(inputProvider);
        Container.BindInstance(bulletPool);
        Container.BindInstance(boundaryProvider);
    }
}