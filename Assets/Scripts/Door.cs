using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject pen;

    bool dialogStart = false;

    int clickCount = 0;
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogStart = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogStart = false;
    }

    private void Update()
    {
        if (dialogStart == true)
        {
            if (pen.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    clickCount++;
                    GetComponent<DialogManager>().message[0] = GetComponent<DialogManager>().message[1];
                    if (clickCount == 2)
                        SceneManager.LoadScene("AnimationOne");
                }
            }
        }
    }
    
}
