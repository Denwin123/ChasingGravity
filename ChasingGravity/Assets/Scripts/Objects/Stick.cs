using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Rigidbody RB;

    private bool beingUsed;
    private bool extending = true;

    private void Awake()
    {
        beingUsed = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (beingUsed)
        {
            if (Input.GetKey(KeyCode.Mouse0))
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
        Vector3 newPos = transform.localPosition;
        
        if (transform.localPosition.z < 1.6)
        {
            Debug.Log("Extending");
            newPos = new Vector3(newPos.x, newPos.y, newPos.z + .02f);
            transform.localPosition = newPos;
        }
    }

    private void Retract()
    {
        Vector3 newPos = transform.localPosition;
        
        if (transform.localPosition.z > 0.0)
        {
            Debug.Log("Retracting");
            newPos = new Vector3(newPos.x, newPos.y, newPos.z - .02f);
            transform.localPosition = newPos;
        }
    }
}
