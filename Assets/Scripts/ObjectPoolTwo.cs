using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTwo : ObjectPoolBase
{
    public ObjectPoolTwo(int minSize, int maxSize, GameObject prefab) : base(minSize, maxSize, prefab) { }

    public override GameObject GetObject()
    {
        GameObject go;


        if (poolIndex >= MAXIMUM_POOL_LENGTH)
        {
            poolIndex = 0;
            ReleaseObject(pool[poolIndex]);

            go = pool[poolIndex++];
            go.SetActive(true);
            return go;
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
}
