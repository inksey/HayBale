using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // vector3 means they can change xyz
    public Vector3 movementSpeed;
    public Space space;

    void Start()
    {
        
    }

    void Update()
    {
        //changing translate on every frame and smooth it out 
        //space- how to translate on the world itself
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
