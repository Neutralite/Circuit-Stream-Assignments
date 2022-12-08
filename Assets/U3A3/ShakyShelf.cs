using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyShelf : MonoBehaviour
{
    public LayerMask m_LayerMask;

    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].GetComponent<ShakyShelfStuff>().timer = 1;
            Debug.Log("Hit : " + hitColliders[i].name + i);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            MyCollisions();
        }
    }
}
