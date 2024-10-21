using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPoolBase : MonoBehaviour
{
    protected readonly int MINIMUN_POOL_LENGTH;
    protected readonly int MAXIMUM_POOL_LENGTH;

    public ObjectPoolBase(int minimunPoolLength, int maximumPoolLength)
    {
        MINIMUN_POOL_LENGTH = minimunPoolLength;
        MAXIMUM_POOL_LENGTH = maximumPoolLength;
    }

    public virtual GameObject GetObject()
    {

        return null;
    }
}
