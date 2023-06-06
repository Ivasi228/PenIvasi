using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public string [] message;
    public bool dialogStart=false;

    void Start()
    {
        
        panelDialog.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            panelDialog.SetActive(true);
            dialog.text = message[0];
            dialogStart = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panelDialog.SetActive(false);
        dialogStart = false;
    }

    private void Update()
    {
        if (dialogStart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                dialog.text = message[1];
            }
        }
    }
}