using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimation : MonoBehaviour
{
    public Animator startAnim;
    public dialogueManager dm;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        startAnim.SetBool("startOpen", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            startAnim.SetBool("startOpen", false);
            dm.EndDialogue();
        }
    }
}
