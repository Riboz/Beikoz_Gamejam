using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    
    public bool death;
    public int can=5,speed,tutulanspeed,Hasar;
    Animator animator;
    public int istenilen_dusurme_Olasilik;
    State_Machine st;
    public GameObject Goz;
    private void Start()
    {
      
        animator=GetComponent<Animator>();
        st=GetComponent<State_Machine>();
        player=GameObject.FindGameObjectWithTag("Player");

    }
     float timersa;
public void FixedUpdate()
{
    Enemy_Movement();
    if(!hasr)
    {
     timersa+=Time.deltaTime;
      if(timersa>0.75f)
      {
        speed=tutulanspeed;
         hasr=true;
         timersa=0;
      }
    }
}
    void Enemy_Movement()
    {
        this.gameObject.transform.position=Vector2.MoveTowards(this.gameObject.transform.position,player.transform.position,speed*Time.deltaTime);
    }
   public void Enemy_Hurt(int hasar)
    {

      can-=hasar;
      if(can>0)
      {
        StartCoroutine(gethurts());
      }
      else if(can==0 || can<0)
      {
        StopCoroutine(gethurts());
        StartCoroutine(getdeath());
        
      }
    }
    IEnumerator gethurts()
    {
      this.transform.DOScale(new Vector3(1.2f,1.2f,0),0.1f);
        speed=0;
        yield return new WaitForSeconds(0.15f);
        speed=tutulanspeed;
        yield break; 
    }
    IEnumerator getdeath()
    {
         speed=0;
         death=true;
         
         int dusurme_Olasilik=Random.Range(0,100);
         if(dusurme_Olasilik>=istenilen_dusurme_Olasilik)
         {
          Instantiate(Goz,this.transform.position,Quaternion.identity);
         }
         
        
          this.transform.DOScale(new Vector3(0,0,0),0.2f);
        yield return new WaitForSeconds(0.2f);
         Destroy(this.gameObject);
        yield break;

    }
    float timerika;
    bool hasr;
    void OnTriggerStay2D(Collider2D coll)
    {
      if(coll.gameObject.tag=="Player")
      {
        timerika+=Time.deltaTime;
        
        Character_Movement_controller avakado = coll.GetComponent<Character_Movement_controller>();
        if(avakado!=null&&hasr)
        {
          avakado.can_look(Hasar);
          hasr=false;
          speed=0;
        }
          if(timerika>0.5f)
        {
        
         hasr=true;
         timerika=0;
        }

        
        
      }
       
    }
}
