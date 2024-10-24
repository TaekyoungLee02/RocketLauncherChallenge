using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolOneWithUnityEnginePool : MonoBehaviour
{
    private ObjectPool<GameObject> pool;
    protected GameObject prefab;
    protected readonly int MINIMUN_POOL_LENGTH;
    protected readonly int MAXIMUM_POOL_LENGTH;

    public ObjectPoolOneWithUnityEnginePool(int minimunPoolLength, int maximumPoolLength, GameObject prefab)
    {
        MINIMUN_POOL_LENGTH = minimunPoolLength;
        MAXIMUM_POOL_LENGTH = maximumPoolLength;
        this.prefab = prefab;

        pool = new ObjectPool<GameObject>(CreateObject, OnGet, OnRelease, OnObjectDestroy, false, minimunPoolLength, maximumPoolLength);
    }

    private GameObject CreateObject()
    {
        return Instantiate(prefab);
    }

    private void OnGet(GameObject go)
    {
        go.SetActive(true);
    }

    private void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }

    private void OnObjectDestroy(GameObject go)
    {
        Destroy(go);
    }

    public GameObject GetObject()
    {
        return pool.Get();
    }

    public void ReleaseGameObject(GameObject go)
    {
        pool.Release(go);
    }
}
