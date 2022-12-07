using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class A7Interface : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IDragHandler
{
    float timer,speed = 5f;
    bool dragging;
    bool spawnedCube = false;

    Vector2 origin, destination, direction;
    void Update()
    {
        if (dragging)
        {
            timer += Time.deltaTime;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        origin = Input.mousePosition;
        dragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        destination = Input.mousePosition;
        direction = destination - origin;
        direction.Normalize();
        GetComponent<Rigidbody>().velocity = direction * speed / timer;

        dragging = false;
        timer = 0;

        if (!spawnedCube)
            StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1);

        Instantiate(this, Vector3.zero, new Quaternion());

        spawnedCube = !spawnedCube;
    }
}