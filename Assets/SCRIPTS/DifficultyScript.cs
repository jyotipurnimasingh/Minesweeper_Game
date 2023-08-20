using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyScript : MonoBehaviour
{
    public static bool e;
    public static bool m;
    public static bool h;

    // Start is called before the first frame update
    void Start()
    {
        e = false;
        m = false;
        h = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Easy()
    {
        e = true;

    }
    public void Medium()
    {
        m = true;

    }
    public void Hard()
    {
        h = true;

    }
}
