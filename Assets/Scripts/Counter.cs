using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour, ICounter
{
    private IUIBoxManager uiBoxManager;

    [SerializeField] private GameObject uiBoxManagerGameObject;
    private Score score;

    [SerializeField] private int MAXSpawn = 15;

    private string typeString;

    public void PushKeyword(string figure) 
    {
        typeString = figure;
        uiBoxManager.SetType(figure);
    }

    private void Start()
    {
        uiBoxManager = uiBoxManagerGameObject.GetComponent<IUIBoxManager>();
        list = new List<GameObject>();
        score = new Score();
    }

    public Score GetScore() 
    {
        return score;
    }

    // private Span<HeapGenericObjectStruct> list;
    private List<GameObject> list;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(typeString))
        {
            score.Passed += 1;
            uiBoxManager.SetPassed(score.Passed);
        }
        else 
        { 
            score.Failed += 1;
            uiBoxManager.SetFailed(score.Failed);
        }

        list.Add(other.gameObject);
        
        while (list.Count > MAXSpawn) 
        {
            Destroy(list[0]);
            list.RemoveAt(0);
            //Destroy(list.Pop());
        }
    }
}
