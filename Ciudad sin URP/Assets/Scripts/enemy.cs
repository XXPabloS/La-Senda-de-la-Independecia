using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] Transform[] Positions;
    [SerializeField] float objectSpeed;
    [SerializeField] float InPosIndexX;
    [SerializeField] float InPosIndexZ;
    
    public GameObject coches;
    int nextPosIndex;
    Transform nextPos;
    Transform inPos;

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {   
       // Instantiate(coches, new Vector3(InPosIndexX,0,InPosIndexZ), Quaternion.identity);
        //createGameObject();
        nextPos = Positions[0];//posicion final coche
        inPos = Positions[1];//posicion inicial coche
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

     //mover coches
    void MoveGameObject()
    {
        if (transform.position == nextPos.position)
        {
            nextPosIndex++;

            if (nextPosIndex >= Positions.Length)//coche llega posicion final
            {
                nextPosIndex = 0;
                coches.transform.position = inPos.position;//mover coche posicion inicial
                //Destroy(coches.gameObject);//eliminar coches          
            }

            nextPos = Positions[0];
        }
        else
        {
            //movimiento coche
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, objectSpeed * Time.deltaTime);
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                audioData.Play(0);
                break;
            default:
                break;
        }
    }
}
