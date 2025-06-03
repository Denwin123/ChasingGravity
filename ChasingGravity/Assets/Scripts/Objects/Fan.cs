using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    PlayerMovement PM;

    private bool beingUsed;

    private void Awake()
    {
        beingUsed = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PM = transform.parent.parent.parent.parent.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (beingUsed)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                PM.PushPlayer(-3);
            }
        }
    }
}
