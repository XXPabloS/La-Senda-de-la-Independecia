using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerMainScene : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;

    private float movementX;

    private float movementY;

    public GameObject jugador;

    [SerializeField]
    Transform[] Positions;

    Transform SpawnPos;

    Transform TextoPos;

    AudioSource audioData;

    private RigidbodyConstraints originalConstraints;

    public VariableJoystick variableJoystick;

    public Animator anim;

    void Start()
    {
        jugador.tag = "Player";

        rb = GetComponent<Rigidbody>();
        originalConstraints = rb.constraints;

        SpawnPos = Positions[0]; //posicion Inicial jugador
        audioData = GetComponent<AudioSource>();

        anim = gameObject.GetComponent<Animator>();
        //        foreach (AnimationState state in anim)
        //        {
        //            state.speed = 0.5F;
        //       }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(variableJoystick.Vertical * speed,rb.velocity.y, variableJoystick.Horizontal * speed * -1);

        if (variableJoystick.Vertical != 0 || variableJoystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("Quieto", false);
        }
        else
            anim.SetBool("Quieto", true);
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Mision1":
                SceneManager.LoadScene("Scene Mision1");

                //Ahora lo hace el npc
                break;
            case "coches":
                jugador.transform.position = SpawnPos.position; //mover jugador posicion inicial
                break;
            case "SuSuelo":
                jugador.transform.position = SpawnPos.position; //mover jugador posicion inicials
                audioData.Play(0);
                break;
            case "CheckPoint":
                //check = true;
                SpawnPos = Positions[1]; //posicion Inicial jugador
                break;
            case "Finish":
                SceneManager.LoadScene("Main Scene"); // El nombre de la escena que desea cambiar
                break;
            default:
                break;
        }
    }

    public void velocidadtextos()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void velocidadNormal()
    {
        rb.constraints = originalConstraints;
    }

    public void TpMisionUno()
    {
        SceneManager.LoadScene("Scene Mision1");
    }

    public void TpMisionDos()
    {
        SceneManager.LoadScene("juego2");
    }

    public void TpMisionTres()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void TpCreditosFinales()
    {
        SceneManager.LoadScene("Creditos");
    }
}
