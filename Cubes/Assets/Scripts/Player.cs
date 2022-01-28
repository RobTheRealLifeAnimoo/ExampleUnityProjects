using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector2 moveInput;
    public TMP_Text timeDisplay;
    Vector3 move;
    CharacterController controller;
    PlayerInput input;
    Camera cam;
    float speed = 6f;
    public float timeValue = 300;

    bool pauseButton;
    bool pause;
    public Button menu;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        cam = Camera.main;
    }

    void Update()
    {
        if(timeValue > 0){
            timeValue -= Time.deltaTime;
        }else{
            SceneManager.LoadScene(0);
        }


        TimeDisplay(timeValue);
        move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.SimpleMove(move * speed);
    }

    void TimeDisplay(float time)
    {
        if(time < 0){
            time = 0;
        }

        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        timeDisplay.text = min + ":" + sec;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnPause(InputValue value){
        pauseButton = value.isPressed;
        if(pauseButton){
            pause = !pause;
        }
        PauseGame();
    }

    
    void PauseGame ()
    {
        if(pause)
        {
            Time.timeScale = 0;
            menu.gameObject.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            menu.gameObject.SetActive(false);
        }
    }
}
