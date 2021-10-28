using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            effect.SetActive(true);
            SheepManager._instance.KillLead();
            LevelManager._instance.SheepIsIn();
        }
    }
}
