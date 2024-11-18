using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Object to pool
    [SerializeField] private IntVariable initialSize; // Number of objects to create initially

    private Queue<GameObject> pool = new Queue<GameObject>(); // Queue to store the pool objects
    private List<GameObject> activeObjects = new List<GameObject>();
    private void Awake()
    {
        InitializePool();
    }

    // Initialize the pool with inactive objects
    private void InitializePool()
    {
        int intsize = initialSize.Value;
        for (int i = 0; i < intsize; i++)
        {
            GameObject obj = CreateNewObject();
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    // Create a new object instance
    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.SetParent(transform); // Optional: keep things organized
        return obj;
    }

    // Get an object from the pool
    public GameObject GetObject()
    {
        GameObject obj;
        if (pool.Count > 0)
        {
             obj = pool.Dequeue();
        }
        else
        {
            // If no objects are available, create a new one
            obj = CreateNewObject();
        }
        obj.SetActive(true);
        activeObjects.Add(obj);
        return obj;
    }

    // Return an object to the pool
    public void ReturnObject(GameObject obj, bool updateActiveObjectList = true)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
        if (updateActiveObjectList)
        {
            activeObjects.Remove(obj);
        }
    }

    public void ReturnFullPool()
    {
        foreach (GameObject obj in activeObjects)
        {
            ReturnObject(obj, updateActiveObjectList:false);
        }
        activeObjects = new List<GameObject>();
    }


}

