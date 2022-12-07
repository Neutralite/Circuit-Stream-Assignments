using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class A3ClickToExplode : MonoBehaviour
{
    public int debrisLevel = 0;
    private int maxDebrisLevel = 3; //any more than 3 and that's too much for unity
    public int cubeID = 0;
 
    public float explosionDelay = 0.1f,
                 debrisSpeed = 5f,
                 shrinkTime = 0.5f;

    Vector3[] positions = { new(-0.25f, -0.25f, -0.25f),
                            new( 0.25f, -0.25f, -0.25f),
                            new(-0.25f, -0.25f,  0.25f),
                            new( 0.25f, -0.25f,  0.25f),
                            new(-0.25f,  0.25f, -0.25f),
                            new( 0.25f,  0.25f, -0.25f),
                            new(-0.25f,  0.25f,  0.25f),
                            new( 0.25f,  0.25f,  0.25f)};

    IEnumerator OnMouseDown()
    {
        if (cubeID == 0)
        {
            yield return DivideCube();
        }
    }

    IEnumerator Start()
    {
        if (cubeID != 0)
        {
            yield return MoveDebris();
            yield return DivideCube();
            if (debrisLevel == maxDebrisLevel)
            {
                //Destroy(gameObject);
                yield return ShrinkCube();
            }
        }
    }

    IEnumerator ShrinkCube()
    {
        float elapsedTime = 0;
        float startTime = Time.time;
        Vector3 startScale = transform.localScale;
        while (elapsedTime < shrinkTime)
        {
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, elapsedTime/shrinkTime);
            elapsedTime = Time.time - startTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    IEnumerator DivideCube()
    {
        if (debrisLevel < maxDebrisLevel)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject debris = Instantiate(gameObject, transform);
                debris.transform.localScale = new(0.5f, 0.5f, 0.5f);
                debris.transform.localPosition = positions[i];
                debris.GetComponent<A3ClickToExplode>().cubeID = i + 1;
                debris.GetComponent<A3ClickToExplode>().debrisLevel += 1;
                transform.DetachChildren();
            }
            Destroy(gameObject);
        }
        yield return null;
    }

    private IEnumerator MoveDebris()
    {
        float elapsedTime = 0;
        float startTime = Time.time;

        while (elapsedTime < explosionDelay)
        {
            transform.Translate(debrisSpeed * Time.deltaTime * positions[cubeID - 1]);
            elapsedTime = Time.time - startTime;
            yield return null;
        }
    }
}
