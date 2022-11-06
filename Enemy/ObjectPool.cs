using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject pooledObject;
    [SerializeField] [Range(0, 15)] int pooledAmount = 5;
    [SerializeField] [Range(0.1f, 15f)] float waitSeconds = 1f;
    GameObject[] pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new GameObject[pooledAmount];
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject, transform);
            obj.SetActive(false);
            //pooledObjects.Push(obj);
            pooledObjects[i] = obj;
        }
        StartCoroutine(SpawnObject());
    }

    //instantiate the object every 1 second using a coroutine
    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitSeconds);
            GetPooledObject();
        }
    }

    //get the first inactive object in the list and activate it
    GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Length; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        return null;
    }
}
