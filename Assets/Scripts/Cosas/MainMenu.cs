using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	private bool play = false;
	private bool credits = false;

	public GameObject Credits;
	public GameObject Controls;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && credits)
        {
        	credits = false;
        }

        Credits.SetActive(credits);

        if(Input.anyKeyDown && play)
        {
        	SceneManager.LoadScene("Nivel_0", LoadSceneMode.Single);
        }
    }

    public void PlayButton()
    {
    	play = true;
    	Controls.SetActive(true);
    }

    public void CreditsButton()
    {
    	credits = true;
    }
}
