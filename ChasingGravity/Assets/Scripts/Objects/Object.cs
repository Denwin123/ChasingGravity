using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ObjectGrabbed()
    {
        StartCoroutine(RemoveObject());
        return gameObject.name;
    }

    private IEnumerator RemoveObject()
    {
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }
}
