using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public Animator _animTelon;

	public string nextSceneName;

	private float GameOverTime;
	public float GameOverTimer = 30.0f;
	public RectTransform manecilla;

	private bool cerrado = false;

	private float time = 0;

	private AudioSource _audio;


    // Start is called before the first frame update
    void Start()
    {
        GameOverTime = GameOverTimer;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cerrado)
        {
        	time += Time.deltaTime;

        	if(time > 1.2f)
        	{
        		SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        	}
        }

        //GameOver timer
        GameOverTime -= Time.deltaTime;

        float porcentaje = 1 - (GameOverTime / GameOverTimer);

        Debug.Log(porcentaje);

        manecilla.eulerAngles = new Vector3(0,0, -360 * porcentaje);

        if(porcentaje >= 0.75f)
        {
        	_audio.pitch = 1.5f;
        }

        if(porcentaje >= 1)
        {
        	_audio.Stop();
        	_animTelon.SetBool("GameOver", true);

        	if(Input.anyKeyDown && GameOverTime <= -2)
        	{
        		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        	}
        }
    }


    void OnTriggerEnter(Collider col)
    {
    	if(col.tag == "Player")
    	{
    		_animTelon.SetBool("cerrar", true);
    		cerrado = true;
    		time = 0;
    	}
    }
}
