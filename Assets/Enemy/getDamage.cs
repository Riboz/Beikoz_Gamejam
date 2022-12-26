using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class getDamage : MonoBehaviour

    {
    
       public ParticleSystem partik;
        Rigidbody2D rb;
    void OnTriggerEnter2D(Collider2D coll)
    {
     if(coll.gameObject.tag=="Enemy")
     {
        if(coll.GetComponent<Enemy>().death==false)
        {
            Instantiate(partik,coll.transform.position,Quaternion.identity);
            StopCoroutine(ohayo());
            coll.GetComponent<Enemy>().Enemy_Hurt(1);
            this.gameObject.transform.DOScale(new Vector3(0,0,0),1f);
            Destroy(this.gameObject,0.6f);
            
            e.Instance.Shake_Camera(2,0.5f);
        } 
        else return;
    }
    }
    void Start()
{
    StartCoroutine(ohayo());
    
 Destroy(this.gameObject,1.5f);
}
IEnumerator ohayo()
{
    this.gameObject.transform.DOScale(new Vector3(0.8f,0.8f,0),0.5f);
    yield return new WaitForSeconds(0.5f);
    this.gameObject.transform.DOScale(new Vector3(1f,1f,0),0.5f);
     yield return new WaitForSeconds(0.5f);
    

}
    // Start is called before the first frame update
   
}
    
