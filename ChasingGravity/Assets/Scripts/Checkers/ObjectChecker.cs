using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    GameManager GM;
    PlayerInteraction PI;

    [Header("Object Checker")]
    [Tooltip("How far you can go from all objects"), Min(0), SerializeField]
    private float distance = 6.5f;

    [Tooltip("How long you can be away from object till losing"), Min(0), SerializeField]
    private int countdownTimer;
    private bool timerInteruption = false;


    [Header("Debug")]
    [Tooltip("If we are debugging the sphere cast for Object Checker or not"), SerializeField]
    private bool sphereCastDebugging;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        PI = transform.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.CheckSphere(transform.position, distance, 1 << 8, QueryTriggerInteraction.Ignore))
        {
            if (!PI.HoldingObject())
            {
                StartCoroutine(CountDown());
                timerInteruption = false;
            }
            else
            {
                timerInteruption = true;
            }
        }
        else
        {
            timerInteruption = true;
        }

    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(countdownTimer);

        if (!timerInteruption)
        {
            GM.ResetArea();
        }
    }

    private void OnDrawGizmos()
    {
        // Shows when debug is turned on and cursor isn't visible
        if (sphereCastDebugging && !Cursor.visible)
        {
            Debug.Log("Object is within sphere: " + Physics.CheckSphere(transform.position, distance, 1 << 8, QueryTriggerInteraction.Ignore));

            Gizmos.color = Color.cyan; // pick color
            Gizmos.DrawSphere(transform.position, distance);
        }
        else
            return;
    }
}
