using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public string Which_statu;
    public GameObject Stuff;
    private Rigidbody2D rb;
    
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
     
     rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
     
      if(Move_Vertical<0 || Move_Horizontal>0)
     {
       if(Move_Horizontal<0)
       {
         GetComponent<SpriteRenderer>().flipX=true;
       }
       if(Move_Horizontal>0)
       {
         GetComponent<SpriteRenderer>().flipX=false;
       }
        Which_statu="Run";
        
     }

     else
     {
      Which_statu="Idle";
     }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Character_All_Direction_Movement();

        St_mac.Animator_State_Machine(Which_statu);
        
    }
     void Update()
     {

     }
     void Mouse_Click()
     {
      Vector2 The_ROTATER=Camera.main.ScreenToWorldPoint(Input.mousePosition);

      float rotations= Mathf.Atan2(The_ROTATER.x,The_ROTATER.y)*Mathf.Rad2Deg-45;

      Stuff.GetComponent<Rigidbody2D>().SetRotation(rotations);


     }
}
