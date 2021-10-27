using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScript : MonoBehaviour
{
    Preview screen;
    [SerializeField] GameObject title;
    [SerializeField] GameObject lvlSelect;
    private void Start()
    {
        screen = GetComponent<Preview>();
    }
    public void Quit()
    {
      //  Application.Quit();
    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelLoad()
    {
        if (screen.curr > -1) { }
      SceneManager.LoadScene(screen.curr);
    }
    public void SelectToTitle(bool inTitle)
    {
        title.SetActive(!inTitle);
        lvlSelect.SetActive(inTitle);
    }

}
