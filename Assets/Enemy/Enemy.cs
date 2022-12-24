using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public int can=5;
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
        this.gameObject.transform.position=Vector2.MoveTowards(this.gameObject.transform.position,player.transform.position,1*Time.deltaTime);
    }
   public void Enemy_Hurt(int hasar)
    {
      can-=1;
      if(can>5)
      {
        StartCoroutine(gethurt());
      }
      else
      {
        StopCoroutine(gethurt());
        StartCoroutine(getdeath());
        
      }
    }
    IEnumerator gethurt()
    {
         st.Animator_State_Machine("Hurt");
        yield return new WaitForSeconds(0.15f);
    yield break; 
    }
    IEnumerator getdeath()
    {
         st.Animator_State_Machine("death");
        yield return new WaitForSeconds(0.2f);
        Destroy(this);
        yield break;

    }
}
