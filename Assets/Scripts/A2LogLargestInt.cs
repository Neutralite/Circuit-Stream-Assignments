using UnityEngine;

public class A2LogLargestInt : MonoBehaviour
{
    public int[] array;
    int largest,temp,index;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        SeekLargest(array);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3)
        {
            SeekLargest(array);
        }
    }

    private void SeekLargest(int[] array)
    {
        if (array.Length == 0)
        {
            Debug.Log("Array has no numbers.");
            timer -= 3;
            return;
        }

        largest = array[0];
        index = 0;

        if (array.Length > 1)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > largest)
                {
                    largest = array[i];
                    index = i;
                }
            }

            temp = Random.Range(0,array.Length);
            array[index] = array[temp];
            array[temp] = largest;  
        }

        Debug.Log($"The largest number in the array is {largest} at index {index}.");
        
        timer -= 3;
    }
}
