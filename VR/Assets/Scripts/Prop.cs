using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prop", menuName = "Objects/Prop")]
public class Prop : ScriptableObject
{
    
    public string objectName;
    public string objectDescription;
    public GameObject objectModel;
}
