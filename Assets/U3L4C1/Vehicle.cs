using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(speed * Time.deltaTime * transform.forward,Space.World);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(speed * Time.deltaTime * -transform.forward,Space.World);
        }
    }

}
