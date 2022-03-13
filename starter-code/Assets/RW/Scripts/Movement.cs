/*  using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Movement : MonoBehaviour
 {
     float currentSpeed = 0f;
     float maxSpeed = 10f;
     public float movementSpeed = 5.0f;
     public GameObject player;
     private float screenCenterX;

     public float accelerationTime = 60;    
     private float minSpeed ;
     private float time ;
 
     private void Start()
     {
         // save the horizontal center of the screen
         screenCenterX = Screen.width * 0.5f;
         minSpeed = currentSpeed; 
         time = 0 ;
     }
 
 
     private void Update()
     {
         // https://docs.unity3d.com/ScriptReference/Mathf.SmoothStep.html
         currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime );
         transform.position -= transform.forward * currentSpeed * Time.deltaTime;
         time += Time.deltaTime ;
         // ....
     } */ 