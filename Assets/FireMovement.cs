using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int fireSpeed;
  
   // StateMachineBehaviour stateMachine;
    void Start()
    {
       // stateMachine =GameObject. Find("Enemy").GetComponent<StateMachineBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(-fireSpeed * Time.deltaTime , 0f, 0f);
    }
}
