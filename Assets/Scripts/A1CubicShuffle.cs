using UnityEngine;

public class A1CubicShuffle : MonoBehaviour
{
    [SerializeField]
    Transform[] points; //add objects to array to serve as points for the cube to follow

    [SerializeField]
    Transform prevPoint,nextPoint;

    [SerializeField]
    int prevPointIndex = 0, nextPointIndex = 1;
    
    [SerializeField]
    bool advance = true, //whether the cube is moving towards or away the end point
         independentSpeed = true; //whether the cube's speed is determined by speed or by time given to finish a given section 
    
    [SerializeField]
    float sectionDistance,
          distanceCovered = 0f,
          speed = 1,
          finishSectionInSeconds = 5f, 
          timer = 0f, 
          lerpValue;

    void Start()
    {
        prevPoint = points[prevPointIndex];
        nextPoint = points[nextPointIndex];
        sectionDistance = Vector3.Distance(prevPoint.position, nextPoint.position);
        advance = nextPointIndex > prevPointIndex;
        transform.position = prevPoint.position;
        GetComponent<MeshRenderer>().material.color = advance ? Color.red : Color.blue;
    }
    // Update is called once per frame
    void Update()
    {
        distanceCovered += speed * Time.deltaTime;
        timer += Time.deltaTime;

        if (independentSpeed) {

            distanceCovered = Mathf.Clamp(distanceCovered, 0, sectionDistance);

            lerpValue = distanceCovered / sectionDistance;
        }
        else
        {
            if (finishSectionInSeconds <= 0)
                finishSectionInSeconds = 1;

            lerpValue = timer / finishSectionInSeconds;
        }

        transform.position = Vector3.Lerp(prevPoint.position, nextPoint.position, lerpValue);

        // when the cube has reached the first point, it is then advancing towards the end point
        if (transform.position == points[0].position)
        {
            advance = true;
        }
        // when the cube has reached the end point, it is then advancing towards the first point
        if (transform.position == points[points.Length-1].position)
        {
            advance = false;
        }

        GetComponent<MeshRenderer>().material.color = advance ? Color.red : Color.blue;

        // once the cube has reached the next point, reset the counters and determine where the cube's going next
        if (transform.position == nextPoint.position)
        {
            prevPoint = nextPoint;
            prevPointIndex = nextPointIndex;
            nextPointIndex += advance ? 1 : -1;
            nextPoint = points[nextPointIndex];
            sectionDistance = Vector3.Distance(prevPoint.position, nextPoint.position);
            distanceCovered = 0;
            timer = 0;
        }
    }
}
