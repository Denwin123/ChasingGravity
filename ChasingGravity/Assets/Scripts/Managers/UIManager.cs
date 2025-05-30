using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("Player UI")]
    [Tooltip("Instructions that pop up when the player is looking at something grabbable"), SerializeField]
    private GameObject GrabInstructions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGrabInstructions(bool showState)
    {
        GrabInstructions.SetActive(showState);
    }
}
