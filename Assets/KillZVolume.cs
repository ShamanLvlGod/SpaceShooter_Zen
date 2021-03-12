using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZVolume : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        ISpawnable spawnable = other.GetComponent<ISpawnable>();
        spawnable?.Despawn?.Invoke();
    }
}