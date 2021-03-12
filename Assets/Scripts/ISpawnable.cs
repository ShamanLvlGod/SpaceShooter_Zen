using System;
using UnityEngine;

public interface ISpawnable
{
    Transform SpawnableTransform { get; }
    Action Despawn { get; set; }
    void OnDespawned();
}