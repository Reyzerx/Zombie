using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {
        //Ouvrir canva avec les options de sensibilit� de la souris
    }

    public void Exit()
    {
        Application.Quit();
    }
}
