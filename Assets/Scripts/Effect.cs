using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    float time;
    [SerializeField] float animtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isActiveAndEnabled)
        {
            time += Time.deltaTime;
            if (time >= animtime)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
