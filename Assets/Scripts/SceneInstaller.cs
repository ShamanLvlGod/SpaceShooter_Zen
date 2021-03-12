using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class SceneInstaller : MonoInstaller
{
    [SerializeField] private InputProvider inputProvider;


    public override void InstallBindings()
    {
        Container.BindInstance(inputProvider);
    }
}