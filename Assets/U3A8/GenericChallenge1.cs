using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericChallenge1 : MonoBehaviour
{
    private void Start()
    {
        InstantiateComponentObject<TestComponent1>(2);
        var test = new GenericChallenge1();
        test.InstantiateComponentObject<TestComponent2>(3);
    }
    List<T> InstantiateComponentObject<T>(int amount) where T : MonoBehaviour
    {
        List<T> newList = new();
        for (int i = 0; i < amount; i++)
        {
            var obj = new GameObject(typeof(T).ToString());
            obj.AddComponent<T>().enabled = false;
            Debug.Log($"Instantiated new GameObject with {typeof(T)} component.");
            newList.Add(obj.GetComponent<T>());
        }
        return newList;
    }
}
