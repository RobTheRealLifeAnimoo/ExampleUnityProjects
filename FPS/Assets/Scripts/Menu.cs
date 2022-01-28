using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    // Start is called before the first frame updat
    void Start(){
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void Info(){
        infoText.gameObject.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }
}
