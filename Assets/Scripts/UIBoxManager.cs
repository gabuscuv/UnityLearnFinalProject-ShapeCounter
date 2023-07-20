using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBoxManager : MonoBehaviour, IUIBoxManager
{

    public TextMeshProUGUI CounterText,
            CounterFailedText,
            CurrentFigureText;

    // Start is called before the first frame update
    public void SetFailed(int counter) 
    {
        CounterFailedText.text = "Failed: " + counter;
    }
    public void SetPassed(int counter) 
    { 
        CounterText.text = "Success: " + counter;
    }
    public void SetType(string type) 
    {
        CurrentFigureText.text = type;
    }
    
}
