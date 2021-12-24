using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Camera cam;
    public GameObject pauseMenu;
    CharacterController controller;
    float sensitivity = 2f;
    float speed = 3f;
    public Gun[] guns;
    GameObject gun;
    int slot = 0;
    int[] ammo;
    int[] storedAmmo;
    public Transform gunPivot;
    public TextMeshProUGUI ammoText;
    int points;
    public TextMeshProUGUI pointsText;
    int targets;
    public static bool pause;
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target").Length;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        ammo = new int[guns.Length];
        storedAmmo = new int[guns.Length];
        for(int i = 0; i < guns.Length; i++){
            storedAmmo[i] = guns[i].maxAmmo;
        }
        switchGun(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            Pause();
        }

        if(pause == false)
        {
            if(points == targets){
                SceneManager.LoadScene(0);
            }
            Vector3 move = transform.forward * Input.GetAxis("Vertical") * speed + transform.right * Input.GetAxis("Horizontal") * speed;
            Vector2 look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if((int)(Input.GetAxis("Mouse ScrollWheel") * 10 ) > 0){
                slot++;
                switchGun(slot);
            } else if((int)(Input.GetAxis("Mouse ScrollWheel") * 10 ) < 0){
                slot--;
                switchGun(slot);
            }

            cam.transform.Rotate(-look.y * sensitivity, 0, 0);
            controller.transform.Rotate(0, look.x * sensitivity, 0);
            controller.SimpleMove(move);
            
            Vector3 currentRotation = cam.transform.localEulerAngles;
            if (currentRotation.x > 180) currentRotation.x -= 360;
            currentRotation.x = Mathf.Clamp(currentRotation.x, -70, 70);
            cam.transform.localRotation = Quaternion.Euler(currentRotation);

            if(Input.GetAxis("Fire1") > 0 && ammo[slot] != 0){
                RaycastHit hit;
                if(Physics.Raycast(cam.transform.position, cam.gameObject.transform.forward, out hit, guns[slot].strength * 100)){
                    if(hit.collider.tag == "Target"){
                        hit.collider.gameObject.GetComponent<Target>().Destroy();
                        points++;
                        pointsText.text = string.Format("{0} Points", points);
                    }
                    ammo[slot]--;
                }
            }else if(ammo[slot] == 0 && storedAmmo[slot] > 0){
                storedAmmo[slot] -= guns[slot].maxClip;
                ammo[slot] = guns[slot].maxClip;
            } else if(ammo[slot] == 0 && storedAmmo[slot] == 0){
                Debug.Log("Out of Ammo");
            }
            ammoText.text = guns[slot].name.ToString() + " - " + ammo[slot].ToString() + "/" + storedAmmo[slot].ToString();
        }
    }

    void switchGun(int s){
        GameObject.Destroy(gun);
        if (slot > guns.Length - 1){
            slot = 0;
        } else if (slot < 0){
            slot = guns.Length - 1;
        }
        gun = Instantiate(guns[slot].model, gunPivot);
    }

    void Pause()
    {
        if(pause)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}