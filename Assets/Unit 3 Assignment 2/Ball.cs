using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int value;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer.Equals(6))
            value+=collision.gameObject.GetComponent<Peg>().value;

        if (collision.gameObject.layer.Equals(7))
        {
            PlinkoManager.instance.Score = value;
            PlinkoManager.instance.Setup();
            Destroy(gameObject);
        }
    }
}
