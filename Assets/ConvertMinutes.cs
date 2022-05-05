using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertMinutes : MonoBehaviour
{
    // Start is called before the first frame update
    public int Data;
    int sec, min;
    void Start()
    {
        min= Data/60;
        sec= Data%60;
        print("M"+min);
        print("s"+sec);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
