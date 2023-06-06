using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pen : MonoBehaviour
{
    public GameObject pen;
    public GameObject Document;
    public string[] Gg;

    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("stay");
        if (Input.GetKey(KeyCode.R))
        {
            pen.SetActive(true);
            Document.GetComponent<DialogManager>().message = Gg;

        }
    } 

}
