using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hero.Instance.GetDamage();
        lives--;
        Debug.Log("у червяка " + lives);
    }

    /*if (lives < 1)
        Die();*/
}
