using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    TMP_Dropdown levelSelect;
    Button start;
    Button info;
    Button quit;
    
    // Start is called before the first frame update
    void Start()
    {
       levelSelect.ClearOptions();
       List<TMPro.TMP_Dropdown.OptionData> scenes;
       for(int i = 1; i < SceneManager.sceneCount; i++ ){
           //scenes.Add(SceneManager.GetSceneByBuildIndex(i));
       }
       
       //levelSelect.AddOptions(); 
    }

    public void GameStart(){

    }

    public void Info(){

    }

    public void Quit(){
        
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }
}
