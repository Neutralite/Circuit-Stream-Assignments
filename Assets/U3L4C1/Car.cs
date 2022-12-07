using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Steer();
    }

    private void Steer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
    }
}
