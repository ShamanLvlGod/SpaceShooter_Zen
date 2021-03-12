using System.Collections.Generic;
using UnityEngine;

public abstract class BasePool : MonoBehaviour
{
    public int startSize;
    protected readonly List<Transform> freeList = new List<Transform>();
    protected readonly List<Transform> usedList = new List<Transform>();
    protected abstract Transform GetBasePrefab();

    protected void PoolNewObject()
    {
        Transform pooledObject = Instantiate(GetBasePrefab(), transform);
        OnNewObjectCreated(pooledObject);
        freeList.Add(pooledObject);
    }

    protected virtual void OnNewObjectCreated(Transform pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    public virtual void Init()
    {
        for (int i = 0; i < startSize; i++)
        {
            PoolNewObject();
        }
    }

    public virtual Transform GetBase()
    {
        int numFree = freeList.Count;
        if (numFree == 0)
        {
            PoolNewObject();
            numFree = freeList.Count;
        }

        Transform pooledObject = freeList[numFree - 1];
        freeList.RemoveAt(numFree - 1);
        usedList.Add(pooledObject);
        pooledObject.gameObject.SetActive(true);
        return pooledObject;
    }

    public virtual void ReturnObjectBase(Transform pooledObject)
    {
        Debug.Assert(usedList.Contains(pooledObject));

        usedList.Remove(pooledObject);
        freeList.Add(pooledObject);

        pooledObject.parent = transform;
        pooledObject.localPosition = Vector3.zero;
        pooledObject.gameObject.SetActive(false);
    }
}