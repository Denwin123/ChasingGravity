using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Scripts/Player/PlayerMovement")]
//[RequireComponent(typeof(CharacterController))]
[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rB;

    private Vector3 respawnPos;
    private Quaternion respawnRot;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();

        SetRespawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }

    private void FixedUpdate()
    {
        if (!Cursor.visible)
        {
            /*if (Input.GetKey(KeyCode.Mouse0))
            {
                Movement(0, 3);
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Movement(1, 3);
            }*/

            rB.velocity -= rB.velocity * 0.005f;
        }
    }

    //----------------------------------------------------------------------------------------------------------------------
    // Movement

    private void Movement(int type, int speed)
    {
        switch (type)
        {
            case 0:
                Push(speed);
                break;
            case 1:
                Push(-speed);
                break;
            default:
                break;
        }
    }

    public void PushPlayer(int speed)
    {
        Push(speed);
    }

    private void Push(int speed)
    {
        if (rB != null)
        {
            Vector3 newForce = transform.GetChild(0).forward * speed * Time.fixedDeltaTime;
            rB.AddForce(newForce, ForceMode.VelocityChange);
        }
        else
            Debug.LogWarning("Character Controller and Rigidbody is missing");
    }


    //----------------------------------------------------------------------------------------------------------------------
    // Respawn

    private void SetRespawn()
    {
        respawnPos = transform.position;
        respawnRot = transform.rotation;
    }

    private void Respawn()
    {
        transform.position = respawnPos;
        transform.rotation = respawnRot;
        rB.velocity = new Vector3(0, 0, 0);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.layer == 6)
            //rB.velocity *= -1f;
    }
}
