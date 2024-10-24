using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPoolBase : MonoBehaviour
{
    protected List<GameObject> pool;
    protected GameObject prefab;
    protected int poolIndex;
    protected readonly int MINIMUN_POOL_LENGTH;
    protected readonly int MAXIMUM_POOL_LENGTH;

    public ObjectPoolBase(int minimunPoolLength, int maximumPoolLength, GameObject prefab)
    {
        MINIMUN_POOL_LENGTH = minimunPoolLength;
        MAXIMUM_POOL_LENGTH = maximumPoolLength;
        this.prefab = prefab;
        poolIndex = 0;

        pool = new List<GameObject>();
    }

    public virtual GameObject CreateObject()
    {
        for(int i = 0; i < MINIMUN_POOL_LENGTH; i ++)
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            pool.Add(go);
        }

        return null;
    }

    public virtual GameObject GetObject()
    {
        GameObject go;


        if (poolIndex >= MAXIMUM_POOL_LENGTH)
        {
            return Instantiate(prefab);
        }
        else if (poolIndex >= pool.Count)
        {
            go = Instantiate(prefab);
            pool.Add(go);
            return go;
        }
        else
        {
            go = pool[poolIndex++];
            go.SetActive(true);
            return go;
        }
    }

    public virtual void ReleaseObject(GameObject gameObject)
    {
        if (pool.Contains(gameObject)) gameObject.SetActive(false);
        else Destroy(gameObject);
    }
}
