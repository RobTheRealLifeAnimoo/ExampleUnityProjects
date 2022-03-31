using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnButton : MonoBehaviour
{
    public Prop prop;
    public TMP_Text objName;
    public TMP_Text objDesc;
    Transform levelParent;

    void Awake()
    {
        levelParent = GameObject.FindGameObjectWithTag("Level Builder Parent").transform;
        objName = GameObject.FindGameObjectWithTag("Object Name").GetComponent<TMP_Text>();
        objDesc = GameObject.FindGameObjectWithTag("Object Description").GetComponent<TMP_Text>();
    }

    public void OnClick(){
        GameObject i = Instantiate(prop.objectModel, Vector3.zero, Quaternion.identity, levelParent);
        Rigidbody rb = i.AddComponent<Rigidbody>();
        BoxCollider col = i.AddComponent<BoxCollider>();
        XRGrabInteractable grab = i.AddComponent<XRGrabInteractable>();
        col.isTrigger = true;
        rb.useGravity = false;
         
    }

    public void OnHover(BaseEventData d){
        objName.text = prop.objectName;
        objDesc.text = prop.objectDescription;
    }
}
