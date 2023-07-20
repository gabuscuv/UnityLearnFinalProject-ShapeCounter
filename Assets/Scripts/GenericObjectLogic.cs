using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectLogic : MonoBehaviour
{
    bool overlap = false;
    //bool movable = true;
    Vector3 mousePos;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!overlap /*&& movable*/){ return; }

        TheShit();
    }

    void TheShit()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 13;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseDown() 
    {
        overlap = true;
    }

    void OnMouseUp() 
    {
        overlap = false;
    }

    void OnCollisionEnter(Collision collider) 
    {
        if (collider.gameObject.CompareTag("UnOverlapable")) 
        {
//            movable = false;
        }
    }


}
