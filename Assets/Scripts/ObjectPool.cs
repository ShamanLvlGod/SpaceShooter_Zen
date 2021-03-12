using System;
using UnityEngine;
using Zenject;

public class ObjectPool<T> : BasePool where T : ISpawnable
{
    public T prefab;


    protected override Transform GetBasePrefab()
    {
        return prefab.SpawnableTransform;
    }

    [Inject]
    public override void Init()
    {
        base.Init();
    }

    public override Transform GetBase()
    {
        return Get().SpawnableTransform;
    }

    public override void ReturnObjectBase(Transform pooledObject)
    {
        ReturnObject(GetTempComponent(pooledObject));
    }

    public virtual T Get()
    {
        T obj = GetTempComponent(base.GetBase());
        obj.Despawn = () => ReturnObject(obj);
        return obj;
    }

    public virtual void ReturnObject(T pooledObject)
    {
        pooledObject.Despawn = null;
        base.ReturnObjectBase(pooledObject.SpawnableTransform);
    }

    private T GetTempComponent(Transform pooledObject)
    {
        T objToReturn = pooledObject.GetComponent<T>();
        Debug.Assert(objToReturn != null);
        return objToReturn;
    }
}