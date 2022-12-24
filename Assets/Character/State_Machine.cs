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
    
   
    
    
}
