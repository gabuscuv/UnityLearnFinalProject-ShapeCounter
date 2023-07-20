using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GroundBehaviour : MonoBehaviour,IGroundBehaviour
{

    //public UnityEvent OnFinishGame;

    List<string> allowlist;

    void Start() 
    {
        //OnFinishGame = new UnityEvent();
        allowlist = new List<string>();
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Testing");
    }

    public void SetAllowList(List<string> allowList) 
    {
        this.allowlist = allowList;
    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Testing2");
        if (!allowlist.Contains(collider.gameObject.name))
        {
            //OnFinishGame.Invoke(this);
        }

        Destroy(collider.gameObject);
    }
}
