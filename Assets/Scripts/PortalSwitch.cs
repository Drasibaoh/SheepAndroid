using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSwitch : MonoBehaviour
{
   [SerializeField] SpriteRenderer firstArrival;
    [SerializeField] List<Sprite> portals;
    [SerializeField] SpriteRenderer secondArrival;
    Transform destination;
    private void Start()
    {
        switchPos();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            Sheep other = collision.GetComponent<Sheep>();
            if (other.GetSType() == Sheep.Type.Lead)
            {
                collision.transform.position = destination.position;
            }
        }
    }
    public void switchPos()
    {
        if (destination == firstArrival.transform)
        {
            /* firstArrival.sprite = portals[0];
             secondArrival.sprite = portals[1];*/
            firstArrival.color = Color.black;
            secondArrival.color = Color.white;
            destination = secondArrival.transform;
        }
        else
        {
            /* firstArrival.sprite = portals[1];
             secondArrival.sprite = portals[0];*/
            firstArrival.color = Color.white;
            secondArrival.color = Color.black;
            destination = firstArrival.transform;
        }
    }
}
