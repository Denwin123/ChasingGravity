using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private UIManager UI;

    private GameObject[] objectList;

    [Header("Interaction")]
    [Tooltip("How far you can interact with something"), Min(0), SerializeField]
    private float distance = 6.5f;

    private Ray rayCast;
    private RaycastHit hitInfo;
    private RaycastHit oldHitInfo;
    private bool repeat = false;

    private bool holdingObject = false;

    [Header("Debug")]
    [Tooltip("If we are debugging the ray cast for interactions or not"), SerializeField]
    private bool rayCastDebugging;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();

        objectList = CollectObjects();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    public bool HoldingObject()
    {
        return holdingObject;
    }

    private GameObject[] CollectObjects()
    {
        Transform ObjectsHolder = transform.GetChild(1);

        if (ObjectsHolder.childCount <= 0)
        {
            Debug.LogWarning("ObjectsHolder in Player is empty");
            return null;
        }

        GameObject[] objects = new GameObject[ObjectsHolder.childCount];

        for (int i = 0; i < ObjectsHolder.childCount; i++)
        {
            objects[i] = ObjectsHolder.GetChild(i).gameObject;
        }

        return objects;
    }

    private void Interact()
    {
        Camera mainCamera = transform.GetChild(0).GetComponent<Camera>();
        rayCast = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(rayCast, out hitInfo, distance + 2))
        {
            if (repeat || !hitInfo.transform.Equals(oldHitInfo.transform))
            {
                if (hitInfo.transform.gameObject.CompareTag("GrabbableObject") && hitInfo.distance < distance)
                {
                    repeat = true;
                    UI.ShowGrabInstructions(true);

                    if (hitInfo.transform.TryGetComponent<Object>(out Object objectScript)) {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            PickedUpObject(objectScript.ObjectGrabbed());
                            holdingObject = true;
                        }
                    }
                    else
                        Debug.LogWarning("Object missing Object script");
                }
                else
                {
                    repeat = false;
                    UI.ShowGrabInstructions(false);
                }
                    
                oldHitInfo = hitInfo;
            }
        }
    }

    private bool PickedUpObject(string objectName)
    {
        if (objectList.Length <= 0)
        {
            Debug.LogWarning("objectList is empty. Can not see objects.");
            return false;
        }

        foreach (GameObject item in objectList)
        {
            if (objectName.Contains(item.name))
            {
                item.SetActive(true);
                return true;
            }
        }

        Debug.LogWarning("object not found in objectList. Can not see object being grabbed");
        return false;
    }


    private void OnDrawGizmos()
    {
        // Shows when debug is turned on and cursor isn't visible
        if (rayCastDebugging && !Cursor.visible)
        {
            Debug.Log("Ray hit: " + hitInfo.collider);

            Gizmos.color = Color.red; // pick color
            Gizmos.DrawLine(rayCast.origin, hitInfo.point); // draws the ray cast
            Gizmos.DrawRay(rayCast.origin, rayCast.direction);
        }
        else
            return;
    }

}
