using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    private Transform camarita;
    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        camarita = transform.Find("Main Camera");
    }
    
    void Update()
    {
        Debug.DrawRay(camarita.position, camarita.forward * rayDistance, Color.blue);
        if(Input.GetKey("e"))
        {
            RaycastHit hit; //Contiene la información al objeto que estamos mirando
            if(Physics.Raycast(camarita.position, camarita.forward, out hit, rayDistance, LayerMask.GetMask("Object_Interactive")))
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}
