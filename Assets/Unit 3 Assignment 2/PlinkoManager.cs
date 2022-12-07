using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlinkoManager : MonoBehaviour
{
    public static PlinkoManager instance;

    [SerializeField]
    Rigidbody ball;

    [SerializeField]
    Color[] pegColors;

    [SerializeField]
    Peg[] pegs;

    Rigidbody ballClone;

    [SerializeField]
    int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = $"Score: {score}";
        }
    }

    [SerializeField]
    TMP_Text scoreText;

    void Start()
    {
        instance = this;
        Score = 0;
        Setup();
    }

    public void Setup()
    {
        foreach (Peg peg in pegs)
        {
            peg.value = Random.Range(1, 4);
            peg.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", pegColors[peg.value - 1]);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && ballClone == null)
        {
            Vector3 instantiationPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
            instantiationPos.x = Mathf.Clamp(instantiationPos.x, -4.6f, 4.6f);
            instantiationPos.y = Mathf.Clamp(instantiationPos.y, 3.5f, 4.6f);
        
            ballClone = Instantiate(ball, instantiationPos, Quaternion.identity);
        }
    }
}
