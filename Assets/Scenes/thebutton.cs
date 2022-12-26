using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class thebutton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonus;
   IEnumerator loli()
   {
    
    buttonus.transform.DOScale(new Vector3(1.2f,1.2f,0),1f);
     yield return new WaitForSeconds(1f);
      SceneManager.LoadScene("Game_Level");
   }
   public void buttonchange()
    {
      StartCoroutine(loli());
    }
}
