using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Machine : MonoBehaviour
{
    // Start is called before the first frame update
    private string Current_State;
    public GameObject Slash;
    Animator an;
    Transform points;
    public Transform []Attack_Spawn_Transfrom;
    public bool Can_Attack=true;
    void Start()
    {
          points=Attack_Spawn_Transfrom[1];
        an=GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Animator_State_Machine(string New_state)
    {
     if(Current_State==New_state)
     {
        return;
     }
     an.Play(New_state);
     Current_State=New_state;
    }
    public void Update()
    {
     Attack();
    }
    
    IEnumerator Can_Attack_CollActive_Co(Transform Point)
    {
        
       
        yield return new WaitForSeconds(0.2f);
        Collider2D[] Coll=Physics2D.OverlapBoxAll(new Vector2(Point.position.x,Point.position.y),new Vector2(0.5f,0.5f),0);
       foreach(Collider2D Enemy in Coll)
        {
         // enemye hasar veren fonksiyon çalıştırır.
        }
        yield return new WaitForSeconds(0.2f);
        Can_Attack=true;
        yield break;
    }
    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&Can_Attack)
        {
            Can_Attack=false;
        if(Current_State=="Right")
        {   
            Instantiate(Slash,Attack_Spawn_Transfrom[1].position,Quaternion.Euler(0,0,0));
            Animator_State_Machine("Right_Attack");
        StartCoroutine(Can_Attack_CollActive_Co(Attack_Spawn_Transfrom[1]));
    
        }
        else if(Current_State=="Left")
        {
             Instantiate(Slash,Attack_Spawn_Transfrom[3].position,Quaternion.Euler(0,0,-180));
            Animator_State_Machine("Left_Attack");
            StartCoroutine(Can_Attack_CollActive_Co(Attack_Spawn_Transfrom[3]));
           
        }
        else if(Current_State=="Down")
        {
             Instantiate(Slash,Attack_Spawn_Transfrom[2].position,Quaternion.Euler(0,0,-90));
            Animator_State_Machine("Down_Attack");
             StartCoroutine(Can_Attack_CollActive_Co(Attack_Spawn_Transfrom[2]));
             
        }
        else if(Current_State=="Up")
        {
             Instantiate(Slash,Attack_Spawn_Transfrom[0].position,Quaternion.Euler(0,0,90));
            Animator_State_Machine("Up_Attack");
            StartCoroutine(Can_Attack_CollActive_Co(Attack_Spawn_Transfrom[0]));
          
        }
        }
    }
    
}
