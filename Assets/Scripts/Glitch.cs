using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    
    [SerializeField] int life=1;
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
            SheepManager._instance.KillLead();
            life--;
            if (life == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
