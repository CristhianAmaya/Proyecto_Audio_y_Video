using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Object_Interactive");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            if(hit.collider.tag == "Object_Interactive")
            {
                if(Input.GetKey("e"))
                {
                    hit.collider.transform.GetComponent<interaccion>().ActivarObjeto();
                }
            }
        }
    }
}
