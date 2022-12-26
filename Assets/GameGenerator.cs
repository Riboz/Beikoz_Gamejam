using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameGenerator : MonoBehaviour
{
    // Start is called before the first frame update7
    GameObject player;
    public GameObject The_Red,The_Black,_The_White;
    bool X=true;
    bool started=true;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(spawner());
    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.R))
      {
        SceneManager.LoadScene("Game_Level");
        BeatWheelBehaviour.Win=0;
      }
      if(Input.GetKeyDown(KeyCode.E)&&X)
      {
        X=false;

        StartCoroutine(spawner());
      }
      if(BeatWheelBehaviour.Win==15)
      {
        StopCoroutine(spawner());
        
      }
    }
    IEnumerator spawner()
    {
      while(started)
      {
       int The_to =Random.Range(0,100);
          if(The_to>=80)
          {
             int A=Random.Range(0,2);
            if(A==0)
            {
            float x=player.transform.position.x-18-(int)Random.Range(6,13);
             int B=Random.Range(0,2);
             if(B==0)
             {
              float y=player.transform.position.y+11+(int)Random.Range(6,13);
              Instantiate(The_Red,new Vector3(x,y,0),Quaternion.identity);
             }
             else if(B==1)
             {
              float y=player.transform.position.y-11-(int)Random.Range(6,13);
              Instantiate(The_Red,new Vector3(x,y,0),Quaternion.identity);
             }
            }
             if(A==1)
             {
              float x=player.transform.position.x+18+(int)Random.Range(6,13);
               int B=Random.Range(0,2);
             if(B==0)
             {
              float y=player.transform.position.y+11+(int)Random.Range(6,13);
              Instantiate(The_Red,new Vector3(x,y,0),Quaternion.identity);
             }
             else if(B==1)
             {
              float y=player.transform.position.y-11-(int)Random.Range(6,13);
              Instantiate(The_Red,new Vector3(x,y,0),Quaternion.identity);
             }
          }
          }
          else if(The_to<=80&&The_to>=50)
          {
               int A=Random.Range(0,2);
            if(A==0)
            {
            float x=player.transform.position.x-18-(int)Random.Range(6,13);
             int B=Random.Range(0,2);
             if(B==0)
             {
              float y=player.transform.position.y+11+(int)Random.Range(6,13);
              Instantiate(The_Black,new Vector3(x,y,0),Quaternion.identity);
             }
             else if(B==1)
             {
              float y=player.transform.position.y-11-(int)Random.Range(6,13);
              Instantiate(The_Black,new Vector3(x,y,0),Quaternion.identity);
             }
            }
             if(A==1)
             {
              float x=player.transform.position.x+18+(int)Random.Range(6,13);
               int B=Random.Range(0,2);
             if(B==0)
             {
              float y=player.transform.position.y+11+(int)Random.Range(6,13);
              Instantiate(The_Black,new Vector3(x,y,0),Quaternion.identity);
             }
             else if(B==1)
             {
              float y=player.transform.position.y-11-(int)Random.Range(6,13);
              Instantiate(The_Black,new Vector3(x,y,0),Quaternion.identity);
             }
          }
          
      }
          else if(The_to<50)
          {
           int A=Random.Range(0,2);
            if(A==0)
            {
            float x=player.transform.position.x-18-(int)Random.Range(6,13);
             int B=Random.Range(0,2);
             if(B==0)
             {
              float y=player.transform.position.y+11+(int)Random.Range(6,13);
              Instantiate(_The_White,new Vector3(x,y,0),Quaternion.identity);
             }
             else if(B==1)
             {
              float y=player.transform.position.y-11-(int)Random.Range(6,13);
              Instantiate(_The_White,new Vector3(x,y,0),Quaternion.identity);
             }
            }
             if(A==1)
             {
              float x=player.transform.position.x+18+(int)Random.Range(6,13);
               int B=Random.Range(0,2);
             if(B==0)
             {
              float y=player.transform.position.y+11+(int)Random.Range(6,13);
              Instantiate(_The_White,new Vector3(x,y,0),Quaternion.identity);
             }
             else if(B==1)
             {
              float y=player.transform.position.y-11+(int)Random.Range(6,13);
              Instantiate(_The_White,new Vector3(x,y,0),Quaternion.identity);
             }
          }
        }
        yield return new WaitForSeconds(3f);
      }
    }
    // Update is called once per frame
    
}
