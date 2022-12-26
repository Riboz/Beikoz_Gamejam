using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatWheelBehaviour : MonoBehaviour
{
    private BeatReading beatReading;

    
    public bool songStartedPlaying = false;
    public bool portalStarted = false;
    public float timeCounter;
    private float beatStabilizer;
    public int beatCount = 0;
    public AudioSource source;
    public AudioClip levelMusic;
    public AudioClip hatSound;
    public AudioClip snareSound;
    public AudioClip kickSound;
    public AudioClip oofSound;
    public GameObject[] beatCircles;
    private GameObject beatObject;
  public static int Win=0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            portalStarted = true;
        }
        
        if (portalStarted == true)
        {
            timeCounter += Time.deltaTime;
       
            if (timeCounter % 0.25 < 0.05 && beatStabilizer < 0.01f)
            {
                getBeatCircleInfo();

                if (beatReading.isColliding == true)
                {
                    if (BeatChecker())
                    {
                        
                        beatReading.isBeatObjectRight = true;
                        BeatPlay();
                        if (songStartedPlaying == false && beatCount == 0)
                        {
                            source.PlayOneShot(levelMusic);
                            songStartedPlaying = true;
                        }
                    }
                    else
                    {
                        source.PlayOneShot(oofSound);
                        beatReading.isBeatObjectRight = false;
                    }
                }
                
                beatCircles[beatCount].GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
                beatCount += 1;
                beatStabilizer = 0.1f;
            }
            if (beatStabilizer > 0)
            {
                beatStabilizer -= Time.deltaTime;
            }
            else
            {
                beatCircles[beatCount].GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = true;
            }
            
        }
        
        if (beatCount == 16) beatCount = 0;
        

    }

    void BeatPlay()
    {
        if (beatReading.kick == true)
        {
            Win+=1;
            source.PlayOneShot(kickSound);
        }
        else if (beatReading.snare == true)
        {
            Win+=1;
            source.PlayOneShot(snareSound);
        }
        else if (beatReading.hat == true)
        {
            Win+=1;
            source.PlayOneShot(hatSound);
        }
    }

    void getBeatCircleInfo()
    {
        beatReading = beatCircles[beatCount].GetComponent<BeatReading>();
    }

    bool BeatChecker()
    {
        if (beatCount == 0 && beatReading.kick == false) return false;
        else if (beatCount == 1 && beatReading.hat == false) return false;
        else if (beatCount == 2 && beatReading.hat == false) return false;
        else if (beatCount == 3 && beatReading.hat == false) return false;
        else if (beatCount == 4 && beatReading.snare == false) return false;
        else if (beatCount == 5) return false;
        else if (beatCount == 6 && beatReading.hat == false) return false;
        else if (beatCount == 7) return false;
        else if (beatCount == 8 && beatReading.kick == false) return false;
        else if (beatCount == 9) return false;
        else if (beatCount == 10 && beatReading.hat == false) return false;
        else if (beatCount == 11) return false;
        else if (beatCount == 12 && beatReading.snare == false) return false;
        else if (beatCount == 13) return false;
        else if (beatCount == 14 && beatReading.hat == false) return false;
        else if (beatCount == 15) return false;
        return true;
    }

    
}
