using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private bool beingUsed;

    private void Awake()
    {
        beingUsed = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingUsed)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Extend();
            }
            else
            {
                Retract();
            }
        }
    }

    private void Extend()
    {
        Debug.Log("Extending");
    }

    private void Retract()
    {
        Debug.Log("Retending");
    }
}
