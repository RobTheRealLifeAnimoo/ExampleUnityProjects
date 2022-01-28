using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Catcher : MonoBehaviour
{
    public TMP_Text score;
    public Animator animator;
    int scoreValue = 0;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Cube"){
            score.text = "Skóre: " + ++scoreValue;
            Destroy(other.gameObject);
            animator.SetTrigger("Catch");
            if (scoreValue > PlayerPrefs.GetInt("Highscore")){
                PlayerPrefs.SetInt("Highscore", scoreValue);
                PlayerPrefs.Save();
            }
        }
    }
}
