using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatReading : MonoBehaviour
{
    public bool kick;
    public bool snare;
    public bool hat;
    public GameObject currentBeatCircle;
    public bool isColliding;
    public bool isBeatObjectRight;

    private void Start()
    {
        isBeatObjectRight = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {

       
        
        if (col.gameObject.CompareTag("kick") && col.gameObject.GetComponent<The_Eye_Activator>().Eyeactive==true)
        {
            kick = true;
            snare = false;
            hat = false;
            isColliding = true;
             currentBeatCircle = col.gameObject;
        }
        else if (col.gameObject.CompareTag("snare")&& col.gameObject.GetComponent<The_Eye_Activator>().Eyeactive==true)
        {
            kick = false;
            snare = true;
            hat = false;
            isColliding = true;
             currentBeatCircle = col.gameObject;
        }
        else if (col.gameObject.CompareTag("hat")&& col.gameObject.GetComponent<The_Eye_Activator>().Eyeactive==true)
        {
            kick = false;
            snare = false;
            hat = true;
            isColliding = true;
             currentBeatCircle = col.gameObject;
        }

       
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        kick = false;
        snare = false;
        hat = false;
        isColliding = false;
    }
    

    void Update()
    {
  
        if (isBeatObjectRight == false)
        {
            Destroy(currentBeatCircle);
            isBeatObjectRight = true;
        }
        
 
    }

}
