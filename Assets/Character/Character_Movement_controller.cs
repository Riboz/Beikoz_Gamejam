using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character_Movement_controller : MonoBehaviour
{
    // Start is called before the first frame update
    static bool isdeath_=false;

    public bool isWalking;
    public string Which_statu;
    public GameObject Stuff,MagicBullet;
    public Transform Thebullet_pos;
    Vector3 last_Bulletpos;
    private Rigidbody2D rb;
    public bool Can_Attack,tru=true;
    public AudioSource source;
    public AudioClip attack;
    
    State_Machine St_mac;
   [SerializeField]private float can,Speed_Movement;
   IEnumerator The_SHAKE_WAND()
   {
while(tru)
{ 
 Stuff.transform.DOLocalRotate(new Vector3(0,0,15),0.2f);
    yield return new WaitForSeconds(0.3f);
    Stuff.transform.DOLocalRotate(new Vector3(0,0,-15),0.2f);
      yield return new WaitForSeconds(0.3f);
           
}        
   }
   
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        St_mac=GetComponent<State_Machine>();
        
    }
    private void Character_All_Direction_Movement()
    {
     float Move_Horizontal= Input.GetAxisRaw("Horizontal");
     float Move_Vertical= Input.GetAxisRaw("Vertical");
       if(Move_Horizontal<0)
       {
       
         GetComponent<SpriteRenderer>().flipX=true;
        
    
         Stuff.GetComponent<Transform>().transform.localPosition=new Vector3(0.4f,0,0);
         
       }
       else if(Move_Horizontal>0)
       {
          GetComponent<SpriteRenderer>().flipX=false;
          Stuff.GetComponent<Transform>().transform.localPosition=new Vector3(-0.4f,0,0);
       }
     rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
     
      if(Move_Horizontal<0 || Move_Horizontal>0)
     {
        
        Stuff.transform.position=Vector3.MoveTowards(Stuff.transform.position,new Vector3(Stuff.transform.position.x,Stuff.transform.position.y+Mathf.Sin(5*Time.time)/15,0),1);
     
        
     }
     if(Move_Horizontal!=0||Move_Vertical!=0)
     {
         isWalking=true;
         St_mac.Animator_State_Machine("Run");
         StartCoroutine(The_SHAKE_WAND());
     }

     else
     {
      isWalking=false;
      StopCoroutine(The_SHAKE_WAND());
      rb.rotation=0;
       St_mac.Animator_State_Machine("idle");
     }
    }
     public void Update()
    {
      if(!isdeath_)
      {
        Attack_the_Player();
      }
    
    }
    void FixedUpdate()
    {
      if(!isdeath_)
      {
      Character_All_Direction_Movement();
      }
       
    }
   
     IEnumerator The_attack()
     {
      GameObject Bullet = Instantiate(MagicBullet,Thebullet_pos.position,Quaternion.identity);
      source.PlayOneShot(attack);

      for(int i=0;i<=30;i++)
      {
      if(Bullet!=null) 
      {Bullet.transform.position=Vector2.Lerp(Bullet.transform.position,last_Bulletpos,25*Time.deltaTime);
        yield return new WaitForSeconds(0.018f);
      }
     
      }

       yield   return new WaitForSeconds(0.1f); 
      
        Can_Attack=true;
         yield break;
     }
     public void can_look(int hasar)
     {
       
      can-=hasar;
      if(can>0)
      {
        StartCoroutine(gethurts());
      }
      else
      {
        StopCoroutine(gethurts());
        StartCoroutine(getdeath());
        
      }
    
     }
     IEnumerator gethurts()
    {
         e.Instance.Shake_Camera(3,0.5f);
        yield return new WaitForSeconds(0.3f);
        yield break; 
    }
    IEnumerator getdeath()
    {
         Speed_Movement=0;
         this.transform.DOLocalRotate(new Vector3(0,0,270),1);
          this.transform.DOScale(new Vector3(0,0,0),1);
             e.Instance.Shake_Camera(5,1f);
        yield return new WaitForSeconds(1f);
        Destroy(this);
        yield break;

    }
     public void Attack_the_Player()
     {
       Vector3 tatake=Camera.main.ScreenToWorldPoint(Input.mousePosition);

       if(Input.GetMouseButton(0) && Can_Attack )
       {
       
        // particule ve ekran sarsıntısı
         last_Bulletpos=tatake;

       StartCoroutine(The_attack());
         
         Can_Attack=false;
       }
       
     }
     
}
