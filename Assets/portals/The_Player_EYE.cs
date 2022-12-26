using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Player_EYE : MonoBehaviour
{
    public GameObject Which_Eye;
    public bool kere,a;
    public Transform eyehole_trans;

    public GameObject targetEyeHole;
    public AudioSource source;
    public AudioClip pickUpSound;

   
   void Start()
   {
    
   }
   public bool  canplaced=false;
     
    public Transform Eye_PLACED_Head;
     
 void OnTriggerStay2D(Collider2D Gemcoll)
 {
    if(Gemcoll.gameObject.tag=="kick"||Gemcoll.gameObject.tag=="snare"||Gemcoll.gameObject.tag=="hat")
    {
        if(Input.GetKey(KeyCode.Space))
        {
           source.PlayOneShot(pickUpSound);
           Which_Eye=Gemcoll.gameObject;
           kere=true;
        }
    }
 }
   
     
 void Update()
 {
     
    if(Which_Eye!=null)
    {
       
         
       if(Input.GetMouseButtonDown(1))
       {
        a=true;
       }
      
        if(a&&canplaced)
        {   
            kere=false;

            if(Which_Eye.tag == "kick"){
                targetEyeHole.GetComponent<BeatReading>().kick = true;
            }
            else if (Which_Eye.tag == "snare"){
                targetEyeHole.GetComponent<BeatReading>().snare = true;
            }
            else if (Which_Eye.tag == "hat"){
                targetEyeHole.GetComponent<BeatReading>().hat = true;
            }
            else
            {
                return;
            }

            Which_Eye.transform.position=Vector2.MoveTowards(Which_Eye.transform.position,eyehole_trans.position,7*Time.deltaTime);
           
            if(Which_Eye.transform.position==eyehole_trans.transform.position)
            {
                Which_Eye.GetComponent<The_Eye_Activator>().Eye_active(true);
                Debug.Log("geldi");
                Which_Eye=null;
                a=false;
            }
        }
        else if(kere){Which_Eye.transform.position=Vector2.Lerp(Which_Eye.transform.position,Eye_PLACED_Head.position,7*Time.deltaTime);}
    }

    
 }
}
