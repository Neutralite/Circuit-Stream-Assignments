using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3A1Script : MonoBehaviour
{
    public Rigidbody sphere;
    Vector3 forceDirection;
    float timer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            forceDirection = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            forceDirection = Input.mousePosition - forceDirection;
 
            Vector3 instantiationPos = Camera.main.ScreenToWorldPoint(Input.mousePosition+new Vector3(0,0,20));
            var instance = Instantiate(sphere, instantiationPos, Quaternion.identity);
            instance.AddForce(forceDirection/(timer*10), ForceMode.Impulse);
            timer = 0;
        }
    }
}
