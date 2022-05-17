using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
public bool canSpawn = true; 
public GameObject sheepPrefab; 
public List<Transform> sheepSpawnPositions = new List<Transform>(); 
//increase spawn rate - I added the = 2
public float timeBetweenSpawns = 2; 
//public float increment = .25;
////increase sheep speed
public float SheepSpeedIncreaseModifier = 4f;
//public float CurrentMovementSpeed = 1f;
public int numberSheepSaved;


private List<GameObject> sheepList = new List<GameObject>(); 


    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }


    void Update()
    {
    //increase sheep speed
    //CurrentMovementSpeed += SheepSpeedIncreaseModifier * Time.deltaTime;
    }


    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; 
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        //set sheep speed//
        sheepList.Add(sheep); 
        sheep.GetComponent<Sheep>().SetSpawner(this); 

      //  if numberSheepSaved is >3 set run speed to be more
        if (numberSheepSaved >3)
            {
                sheep.GetComponent<Sheep>().SetRunSpeed (numberSheepSaved *10/3); 
                //decrease times between spawns (-.2f)
            } 
    }
    //think about the condition  (numberSheepSaved >3) - this just happens once, 
    //if(sheepSaved % 3 == 0){} - don't set it to a set number (otherwise wont increase)
    // basespeed (10) * numberSheepSaved (30,60,90) - these number might be too fast
    //float runspeed =10;

    private IEnumerator SpawnRoutine() 
        {
            while (canSpawn) 
            {
                SpawnSheep(); 
                yield return new WaitForSeconds(timeBetweenSpawns); 
                //increase spawn
               // timeBetweenSpawns -= increment;
            }
        }

    public void RemoveSheepFromList(GameObject sheep)
            {
                sheepList.Remove(sheep);
            }

    public void DestroyAllSheep()
        {
            foreach (GameObject sheep in sheepList)
            {
                Destroy(sheep);
            }

            sheepList.Clear();
        }

    public void UpdateSheepSaved(int sheepSaved)
    {
        numberSheepSaved = sheepSaved;
    }
}
