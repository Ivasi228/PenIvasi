using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject == Hero.Instance.gameObject)
    {
        Hero.Instance.GetDamage();
    }
}
}