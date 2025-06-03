using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject Player;
    private BoxCollider stickCollider;

    private bool beingUsed;
    private bool extending = true;

    private int amountOfHits = 6;

    private void Awake()
    {
        beingUsed = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = transform.GetComponent<Rigidbody>();
        Player = transform.parent.parent.parent.parent.gameObject;
        stickCollider = Player.GetComponent<BoxCollider>();

        if (stickCollider != null)
        {
            stickCollider.size = transform.localScale;
            stickCollider.center = transform.position;
        }
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
            newPos = new Vector3(newPos.x, newPos.y, newPos.z + .02f);
            transform.localPosition = newPos;
            if (stickCollider != null)
            {
                stickCollider.center = newPos;
            }
        }
    }

    private void Retract()
    {
        Vector3 newPos = transform.localPosition;
        
        if (transform.localPosition.z > 0.0)
        {
            newPos = new Vector3(newPos.x, newPos.y, newPos.z - .02f);
            transform.localPosition = newPos;

            if (stickCollider != null)
            {
                stickCollider.center = newPos;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        amountOfHits -= 1;

        if (amountOfHits == 0)
        {
            Destroy(gameObject);
        }
    }
}
