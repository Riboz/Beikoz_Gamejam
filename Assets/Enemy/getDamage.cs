using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDamage : MonoBehaviour

    {
        ParticleSystem partik;
        Rigidbody2D rb;
    void OnTriggerEnter2D(Collider2D coll)
    {
     if(coll.gameObject.tag=="Enemy")
     {
        if(coll.GetComponent<Enemy>().death==false)
        {
            coll.GetComponent<Enemy>().Enemy_Hurt(1);
            Destroy(this.gameObject);
        } 
        else return;
    }
    }
    void Start()
{
    Destroy(partik,1.5f);
 Destroy(this.gameObject,1.5f);
}
    // Start is called before the first frame update
   
}
    
