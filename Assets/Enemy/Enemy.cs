using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
   public bool death;
    public int can=5,speed,Hasar;
    Animator animator;
    State_Machine st;
    private void Start()
    {
        animator=GetComponent<Animator>();
        st=GetComponent<State_Machine>();
        player=GameObject.FindGameObjectWithTag("Player");

    }
public void FixedUpdate()
{
    Enemy_Movement();
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
         st.Animator_State_Machine("Hurt");
        yield return new WaitForSeconds(0.15f);
        yield break; 
    }
    IEnumerator getdeath()
    {
         st.Animator_State_Machine("death");
         death=true;
        yield return new WaitForSeconds(0.2f);
         Destroy(this.gameObject);
        yield break;

    }
}
