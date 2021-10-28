using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencePlayer : MonoBehaviour
{
    [SerializeField]bool ultdr;
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
            Sheep player = collision.GetComponent<Sheep>();
            if (player.GetSType() == Sheep.Type.Lead && ultdr)
            {
                if (player.GetDir() == Vector2.down)
                {
                   // player.transform.position +=;
                    player.SetDir(Vector2.right);
                }
                else if (player.GetDir() == Vector2.up)
                {
                    player.SetDir(Vector2.left);
                }
                else if (player.GetDir() == Vector2.left)
                {
                    player.SetDir(Vector2.up);
                }
                else if (player.GetDir() == Vector2.right)
                {
                    player.SetDir(Vector2.down);
                }
            }
            else if (player.GetSType() == Sheep.Type.Lead && !ultdr)
            {
                if (player.GetDir() == Vector2.down)
                {
                    player.SetDir(Vector2.left);
                }
                else if (player.GetDir() == Vector2.up)
                {
                    player.SetDir(Vector2.right);
                }
                else if (player.GetDir() == Vector2.left)
                {
                    player.SetDir(Vector2.down);
                }
                else if (player.GetDir() == Vector2.right)
                {
                    player.SetDir(Vector2.up);
                }
            }
            player.PlayAnim();
        }
    }
}
