using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenClicked : MonoBehaviour
{
    MeshRenderer thisMesh = new MeshRenderer();
    // Start is called before the first frame update
    void OnSelect()
    {
        thisMesh = gameObject.GetComponent<MeshRenderer>();
        thisMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
