using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<string> workObject;
    [SerializeField] List<GameObject> BoxTarget;
    private ISpawnManager spawnManager;
    private IGroundBehaviour groundBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<ISpawnManager>();
        groundBehaviour = GameObject.Find("Ground").GetComponent<IGroundBehaviour>();
        Randomzing();

        //groundBehaviour.OnFinishGame.AddListener(GameOver);
    }

    // Update is called once per frame
    void GameOver()
    {
        spawnManager.SetGameActivity(false);
    }

    private void Randomzing() 
    {
        int ItemToSelect;
        workObject = spawnManager.GetObjectToSpawnNames();
        for (int targetcount = 0; targetcount < BoxTarget.Count; targetcount++)
        {
                ItemToSelect = Random.Range(0, workObject.Count);
                BoxTarget[targetcount].GetComponent<ICounter>().PushKeyword(workObject[ItemToSelect]);
                
                workObject.RemoveAt(ItemToSelect);
        }

        groundBehaviour.SetAllowList(workObject);
    }
}
