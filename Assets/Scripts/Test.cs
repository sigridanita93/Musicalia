using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // For a flying note
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }
    
    void Update()
    {
        
    }
}
