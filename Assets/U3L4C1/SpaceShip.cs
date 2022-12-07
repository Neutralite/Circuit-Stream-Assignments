using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Vehicle
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

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-1, 0, 0);
        }
    }
}
