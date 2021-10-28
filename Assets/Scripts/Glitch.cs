using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    
    [SerializeField] int life=1;
    [SerializeField] GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            Death();
        }
    }    
    void Death()
    {

           
            life--;
            if (life == 0)
            {
                effect.SetActive(true);
                gameObject.SetActive(false);
            }
        SheepManager._instance.KillLead();
        
    }
}
