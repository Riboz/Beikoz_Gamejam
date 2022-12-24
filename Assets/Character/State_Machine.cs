using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Machine : MonoBehaviour
{
    // Start is called before the first frame update
    private string Current_State;
    Animator an;
    Transform points;

    public bool Can_Attack=true;
    void Start()
    {
          
        an=GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Animator_State_Machine(string New_state)
    {
     if(Current_State==New_state)
     {
        return;
     }
     
     Current_State=New_state;
     an.Play(Current_State);
    }
    
   
    
    
}
