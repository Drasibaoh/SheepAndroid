using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Preview : MonoBehaviour
{
    [SerializeField] Image preview;
    [SerializeField] List<Sprite> levels;
    public int curr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPre(int lvlInd)
    {
        preview.sprite = levels[lvlInd-1];
        curr = lvlInd;
    }
}
