using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolThree : ObjectPoolBase
{
    public ObjectPoolThree(int minSize, int maxSize, GameObject prefab) : base(minSize, maxSize, prefab) { }

    public override GameObject CreateObject()
    {
        return null;
    }
}
