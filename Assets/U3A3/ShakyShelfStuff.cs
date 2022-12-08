using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyShelfStuff : MonoBehaviour
{
    public float timer = 0;

    void Update()
    {
        if (timer>0)
        {
            transform.eulerAngles = new(Mathf.Sin(Time.time * 10) * 10, 0, 0);
            timer -= Time.deltaTime;
        }
    }
}
