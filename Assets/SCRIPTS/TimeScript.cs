using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text Timer;
    private float time = 0.0f;
    public float b;
    public static bool reset;
    public static bool zero;
    public bool isTimer = true;
    // Start is called before the first frame update
    void Start()
    {
        //zero = false;
        reset = false;
        
        if (DifficultyScript.e)
        {
            b = 300f;
        }
        else if (DifficultyScript.m)
        {
            b = 180f;
        }
        else if (DifficultyScript.h)
        {
            b = 120f;
        }

        time = b;
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            //time = b;
            reset = false;
        }
        if (isTimer)
        {
            time = time - Time.deltaTime;
            Display();
        }
    }

    void Display()
    {
        int second = Mathf.FloorToInt(time);
        if (second == 0)
        {
            isTimer = false;
            zero = true;
        }
        Timer.text = string.Format("{0:000}", second);
    }
}