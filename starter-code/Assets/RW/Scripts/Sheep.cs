using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed; 
    public float gotHayDestroyDelay; 
    private bool hitByHay; 
    private bool dropped;
    public float dropDestroyDelay; 
    private Collider myCollider; 
    private Rigidbody myRigidbody; 
    private SheepSpawner sheepSpawner;
    public float heartOffset; 
    public GameObject heartPrefab; 
    public float SheepSpeedIncreaseModifier = 4f;
    
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
     //   runSpeed += SheepSpeedIncreaseModifier * Time.deltaTime;
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }



    private void Drop()
    {
        GameStateManager.Instance.DroppedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
        dropped = true;
        myRigidbody.isKinematic = false; 
        myCollider.isTrigger = false; 
        Destroy(gameObject, dropDestroyDelay); 
        SoundManager.Instance.PlaySheepDroppedClip();
    }

    private void HitByHay()
    {
        hitByHay = true; 
        runSpeed = 0;

        sheepSpawner.RemoveSheepFromList(gameObject);
        Destroy(gameObject, gotHayDestroyDelay);
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0; 
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.SavedSheep();
    }


    private void OnTriggerEnter(Collider other) 
    {
    //sheepSpawner.RemoveSheepFromList(gameObject);
    
        if (other.CompareTag("Hay") && !hitByHay) 
        {
            Destroy(other.gameObject); 
            HitByHay(); 
        }

        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;

    }

    public void SetRunSpeed (float speed)
    {
        runSpeed = speed;
    }
} 
