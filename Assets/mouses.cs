using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouses : MonoBehaviour
{
   public The_Player_EYE ege;
   public GameObject clickedEyehole,yedek;

   void OnTriggerEnter2D(Collider2D colling)
   {
if(colling.gameObject.CompareTag("eyehole"))
{
   if(!ege.a)
   {
       ege.canplaced=true;
       ege.eyehole_trans=colling.transform;
       
       yedek = colling.gameObject;
   }

 
}

   }
   
  
   
 
   void Update()
   {
         Vector3 tatake=Camera.main.ScreenToWorldPoint(Input.mousePosition);
         this.transform.position=tatake;

         if(Input.GetMouseButtonDown(1))
         {
            clickedEyehole = yedek;
            ege.targetEyeHole = clickedEyehole;
         }
   }
}
