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
        if (!Cursor.visible)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Movement(0, 3);
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Movement(1, 3);
            }
        }

        if (transform.position.y < -10)
        {
            Respawn();
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

    private void Push(int speed)
    {
        if (rB != null)
        {
            Vector3 newPos = transform.position;

            newPos = transform.position + (transform.GetChild(0).forward * speed * 0.1f);

            RaycastHit hitInfo;
            if (Physics.SphereCast(transform.position, 2, new Vector3(0, 1, 0), out hitInfo, 2, 6))
                newPos = transform.position;

            rB.MovePosition(newPos);
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
    }
}
