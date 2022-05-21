using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    #region PublicFields
    public List<Pool> Pools;
    public Dictionary<string, List<GameObject>> PooledObject;
    #endregion PublicFields

    #region UnityMethods
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Initialize();
    }
    #endregion UnityMethods

    #region Methods

    private void Initialize()
    {
        PooledObject = new Dictionary<string, List<GameObject>>();
        GameObject clone;
        foreach (var item in Pools)
        {
            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < item.AmaountToPool; i++)
            {
                clone = Instantiate(item.Object);
                clone.transform.SetParent(item.Parent);
                clone.SetActive(false);
                objectPool.Add(clone);
            }
            PooledObject.Add(item.Tag, objectPool);
        }

        StopAllCoroutines();
    }

    public GameObject GetPooledObject(string tag)
    {
        List<GameObject> Objects = PooledObject[tag];
        for (int i = 0; i < Objects.Count; i++)
        {
            if (!Objects[i].activeInHierarchy)
            {
                return Objects[i];
            }
        }
        return null;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject poolObject = GetPooledObject(tag);
        if (poolObject != null)
        {
            poolObject.transform.position = position;
            poolObject.transform.rotation = rotation;
            poolObject.SetActive(true);
        }
        return poolObject;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    #endregion Methods
}
