using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform arrivalPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            Sheep other = collision.GetComponent<Sheep>();
            if (other.GetSType() == Sheep.Type.Lead)
            {
                collision.transform.position = arrivalPoint.position;
            }
        }
    }
}
