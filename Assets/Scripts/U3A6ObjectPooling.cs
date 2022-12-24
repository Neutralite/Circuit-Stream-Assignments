using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3A6ObjectPooling: MonoBehaviour
{
    public static U3A6ObjectPooling instance;

    [SerializeField]
    GameObject pooledObject;
    float releaseTimer, releaseDelay = 0.25f;
    [SerializeField]
    int initObjects = 10;
    [SerializeField]
    List<GameObject> inactivePool, activePool;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }
    void Update()
    {
        releaseTimer += Time.deltaTime;
        if(releaseTimer >= releaseDelay)
        {
            releaseTimer -= releaseDelay;
            ActivateObject();
        }
        if (activePool.Count > 0)
        {
            if (activePool[0].transform.position.y <= -10)
            {
                DeactivateObject();
            }
        }
    }
    void Setup()
    {
        instance = this;
        pooledObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pooledObject.AddComponent<Rigidbody>();
        pooledObject.SetActive(false);
        pooledObject.transform.SetParent(transform);
        pooledObject.transform.position = new(Random.Range(-5, 6), 10);
        inactivePool.Add(pooledObject);

        int toMake = initObjects - inactivePool.Count;
        for (int i = 0; i < toMake; i++)
        {
            CreateObject();
        }
    }
    void ActivateObject()
    {
        if(inactivePool.Count == 0)
        {
            CreateObject();
        }
        inactivePool[0].SetActive(true);
        activePool.Add(inactivePool[0]);
        inactivePool.Remove(inactivePool[0]);
    }
    void DeactivateObject()
    {
        activePool[0].SetActive(false);
        activePool[0].transform.position = new(Random.Range(-5, 6), 10);
        activePool[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
        inactivePool.Add(activePool[0]);
        activePool.Remove(activePool[0]);
    }
    void CreateObject()
    {
        GameObject temp = Instantiate(pooledObject, new(Random.Range(-5,6), 10), Quaternion.identity, transform);
        temp.SetActive(false);
        inactivePool.Add(temp);
    }
}
