using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
    public GameObject controllate;
    private bool selecr = false;

    public void MenuControl()
    {
        if(Input.GetKey("tab")){
            if(selecr==false){
                controllate.SetActive(true);
                selecr = true;
            }
            else if(selecr==true){
                controllate.SetActive(false);
                selecr = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MenuControl();
    }
}
