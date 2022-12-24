using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public string Which_statu;
    public GameObject Stuff;
    private Rigidbody2D rb;
    public Transform The_point;
    public Camera cameras; 
    
    
    State_Machine St_mac;
   [SerializeField]private float Speed_Movement;
    
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
       }
       else if(Move_Horizontal>0)
       {
         GetComponent<SpriteRenderer>().flipX=false;
       }
     rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
     
      if(Move_Vertical<0 || Move_Horizontal>0)
     {
       
      
        Which_statu="Run";
        
     }

     else
     {
      return;
     }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Character_All_Direction_Movement();
    }
     void Update()
     {
Mouse_Click();
     }
     void Mouse_Click()
     {
      Stuff.transform.position=Vector2.MoveTowards(this.transform.position,The_point.position,5);

     }
}
