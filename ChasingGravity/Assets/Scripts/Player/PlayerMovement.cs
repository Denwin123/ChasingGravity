using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Scripts/Player/PlayerMovement")]
[RequireComponent(typeof(CharacterController))]
[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 respawnPos;
    private Quaternion respawnRot;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

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
                PushForward(speed);
                break;
            case 1:
                PushBackward(speed);
                break;
            default:
                break;
        }
    }

    private void PushForward(int speed)
    {
        if (controller != null)
        {
            controller.Move(transform.GetChild(0).forward * speed * .01f);
        }
        else
            Debug.LogWarning("Character Controller is missing");
    }

    private void PushBackward(int speed)
    {
        if (controller != null)
        {
            controller.Move(-transform.GetChild(0).forward * speed * .01f);
        }
        else
            Debug.LogWarning("Character Controller is missing");
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
        controller.enabled = false;
        transform.position = respawnPos;
        transform.rotation = respawnRot;
        controller.enabled = true;
    }
}
