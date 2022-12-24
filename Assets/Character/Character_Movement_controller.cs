using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public string Which_statu;
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
     
     
     
      if(Move_Vertical>0&&Move_Horizontal==0)
     {
        Debug.Log("YUKARI");
         Which_statu="Up";
         rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
       
     }
     else if(Move_Vertical<0 && Move_Horizontal==0)
     {
        Debug.Log("AŞAĞI");
          Which_statu="Down";
          rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
     }
     else if(Move_Vertical==0 && Move_Horizontal>0)
     {
        Debug.Log("sağ ");
        Which_statu="Right";
        rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
     }
     else if(Move_Vertical==0 && Move_Horizontal<0)
     {
        Which_statu="Left";
        Debug.Log("sol ");
        rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
     }
    else if(Move_Vertical==0&&Move_Horizontal==0)
    {
      rb.velocity=Vector2.zero;
    }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Character_All_Direction_Movement();

        St_mac.Animator_State_Machine(Which_statu);
        
    }
}
