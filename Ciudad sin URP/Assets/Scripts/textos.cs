using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using UnityEngine.UI;

public class textos : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject TextObject;
    //public GameObject Player;

    //public GameObject Pickup;
    [Header("Conversations")]
    public NPCConversation Conversation;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        TextObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    public void objectospickup()
    {
        TextObject.SetActive(true);
        ConversationManager.Instance.StartConversation (Conversation);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                TextObject.SetActive(true);
                ConversationManager.Instance.StartConversation (Conversation);
                break;
            /* case "PickUp":
                TextObject.SetActive(true);
                ConversationManager.Instance.StartConversation(Conversation);

            break;*/
            default:
                break;
        }
    }
}
