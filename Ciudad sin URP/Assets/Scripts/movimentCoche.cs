using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movimentCoche : MonoBehaviour
{
    [Header("objetos")]
    private Rigidbody rb;

    [Header("movimiento Jugador")]
    public float speed = 1;

    private float movementX;

    private float movementY;

    //public float vel = 1;
    [Header("Canvas")]
    private int count;

    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Entregas: " + count.ToString();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "PickUp":
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();

                break;
            case "Finish":
                SceneManager.LoadScene("Main Scene"); // El nombre de la escena que desea cambiar
                break;
            default:
                break;
        }
    }
}
