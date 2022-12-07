using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{


 public GameObject PickUp;
 public GameObject NPC;

 public Transform t;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Player":
                PickUp.gameObject.SetActive(false);
                // t.GetComponent<textos>().objectospickup();
                NPC.GetComponent<textos>().objectospickup(); 
            break;

            default: break;
        }
    }
}
