using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour, ISpawnManager
{
    bool isActiveGame = true;
    [SerializeField] List<GameObject> objectsToLunch;
    [SerializeField] List<GameObject> SpawnTargets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameActivity(bool status) 
    {
        isActiveGame = status;
    }

    public List<string> GetObjectToSpawnNames() 
    {
        List<string> names = new List<string>();
        foreach (var item in objectsToLunch) 
        { 
            names.Add(item.name);
        }

        return names;
    }

    private IEnumerator SpawnRandomObject() 
    {
        while (isActiveGame)
        {
            yield return new WaitForSeconds(1);
            var transform = GetRandomPosition();
            Instantiate(
                objectsToLunch
                    [
                        Random.Range(0, objectsToLunch.Count)
                    ],
                transform.position, transform.rotation
                );
        }
    }

    Transform GetRandomPosition() 
    {
        return SpawnTargets[Random.Range(0, SpawnTargets.Count)].transform;
    }
}
