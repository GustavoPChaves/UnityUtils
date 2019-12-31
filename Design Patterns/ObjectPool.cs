using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instantiate prefabs and manages it for reuse
/// </summary>
public class ObjectPool : MonoBehaviour
{
    /// <summary>
    /// Disable Pooled Objects when the Object Pool is Disabled
    /// </summary>
    [SerializeField] private bool _disablePooledObjects = true;

    /// <summary>
    /// If the pool can grows if it is empty
    /// </summary>
    [SerializeField] private bool _willGrow = true;

    /// <summary>
    /// Desired Object to pool
    /// </summary>
    [SerializeField] private GameObject _pooledObject;

    /// <summary>
    /// Initial amount to pool
    /// </summary>
    [SerializeField] private int _pooledAmount;

    /// <summary>
    /// Max count of prefabs
    /// </summary>
    [SerializeField] private int _growLimit;

    private List<GameObject> pooledObjects = new List<GameObject>();

    /// <summary>
    /// Initialize the list with the desired initial amount
    /// </summary>
    void Awake () {
        for (int i = 0; i < _pooledAmount; i++)
        {
            CreatePooledObject();
        }
    }

    /// <summary>
    /// Creates a pooled object
    /// </summary>
    /// <returns>Return a new pooled object</returns>
    GameObject CreatePooledObject()
    {
        GameObject obj = (GameObject)Instantiate(_pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        obj.transform.SetParent(transform);
        return obj;
    }

    /// <summary>
    /// Search for a valid gameObject for reuse
    /// </summary>
    /// <returns>A gameObject if has a valid one, Null if doesn't</returns>
    GameObject GetPooledObject()
    {
        for(int i = 0; i< pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (_willGrow)
        {
            if (pooledObjects.Count >= (_growLimit == 0 ? int.MaxValue : _growLimit))
            {
                return null;
            }
            var obj = CreatePooledObject();
            return obj;
        }
        return null;
    }

    /// <summary>
    /// Get a pooled Object
    /// </summary>
    /// <param name="position">Position of the object</param>
    /// <param name="parent">Parent of the object</param>
    /// <param name="rotation">Rotation of object</param>
    /// <returns>True if has a valid Object, False if not</returns>
    public GameObject GetPooledObject(Vector3? position, Transform parent = null, Quaternion? rotation = null)
    {
        var obj = GetPooledObject();
        if (obj == null)
            return null;

        if (position != null)
        {
            obj.transform.position = position ?? Vector3.zero;
        }

        if (rotation != null)
        {
            obj.transform.rotation = rotation ?? Quaternion.identity;
        }
        if (parent != null)
        {
            obj.transform.SetParent(parent);
        }
        return obj;
    }

    /// <summary>
    /// Called when the ObjectPool is disabled
    /// </summary>
    void OnDisable()
    {
        if(_disablePooledObjects)
            DisableAllPolledObjects();
    }

    /// <summary>
    /// Disable All Pooled Objects
    /// </summary>
    void DisableAllPolledObjects()
    {
        var count = pooledObjects.Count;
        for (int i = 0; i < count; i++)
        {
            pooledObjects[i].SetActive(false);
        }
    }

}
