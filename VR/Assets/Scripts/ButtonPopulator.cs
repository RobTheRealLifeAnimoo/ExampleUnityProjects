using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPopulator : MonoBehaviour
{
    Prop[] props;
    public GameObject button;
    Transform content;
    // Start is called before the first frame update
    void Start()
    {
        content = this.gameObject.transform;
        props = Resources.LoadAll<Prop>("Props");
        int x = -95;
        int y = 115;
        foreach(Prop p in props){
            GameObject btn = Instantiate(button, Vector3.zero, Quaternion.identity, content);

            btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y);
            //btn.GetComponent<RectTransform>().rect.Set(x, y, 50, 50);

            SpawnButton spawnedButton = btn.GetComponent<SpawnButton>();
            spawnedButton.prop = p;

            if(x >= 100){
                x = -95;
                y -= 60;
            } else{
                x += 65;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
