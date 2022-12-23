using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
   [SerializeField]private float Speed_Movement;
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    private void Character_All_Direction_Movement()
    {
     float Move_Horizontal= Input.GetAxisRaw("Horizontal");
     float Move_Vertical= Input.GetAxisRaw("Vertical");
     
     rb.velocity=new Vector2(Move_Horizontal,Move_Vertical).normalized*Speed_Movement;
     if(Move_Vertical>0 && Move_Horizontal>0)
     {
      Debug.Log("sağ yukarı");
     }
     else if(Move_Vertical>0&&Move_Horizontal==0)
     {
        Debug.Log("YUKARI");
     }
     else if(Move_Vertical<0 && Move_Horizontal==0)
     {
        Debug.Log("AŞAĞI");
     }
     else if(Move_Vertical<0 && Move_Horizontal>0)
     {
        Debug.Log("sağ aşağı çapraz");
     }
     else if(Move_Vertical<0 && Move_Horizontal<0)
     {
        Debug.Log("sol aşağı çapraz");
     }
     else if(Move_Vertical==0 && Move_Horizontal>0)
     {
        Debug.Log("sağ ");
     }
     else if(Move_Vertical==0 && Move_Horizontal<0)
     {
        Debug.Log("sol ");
     }
     else if(Move_Vertical>0 && Move_Horizontal<0)
     {
        Debug.Log("sol yukarı ");
     }
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Character_All_Direction_Movement();
    }
}
