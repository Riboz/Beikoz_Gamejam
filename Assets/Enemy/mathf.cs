using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mathf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         this.transform.position=Vector3.MoveTowards(this.transform.position,new Vector3(this.transform.position.x,this.transform.position.y+Mathf.Sin(5*Time.time)/180,0),1);
    }
}
