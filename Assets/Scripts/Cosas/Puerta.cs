using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

	private Animator _anim;

	public List<Clone> clones = new List<Clone>();

	public Clone clonePose;

	private AudioSource _audio;

	public AudioClip c_Abrir;

	public AudioClip c_Incorrecto;

	private string key;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();

        key = clones[Random.Range(0, clones.Count - 1)].Seed;
        Debug.Log(key);

        clonePose.Seed = key;
        clonePose.ChangeSkin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

    	if(col.tag == "Player")
    	{
    		Debug.Log(col.transform.GetComponent<PlayerMovements>().Seed);
    		if(col.transform.GetComponent<PlayerMovements>().Seed == key)
    		{
    			_anim.SetBool("Abierta", true);
    			_audio.clip = c_Abrir;
    			_audio.Play();
    		}else
    		{
    			_audio.clip = c_Incorrecto;
    			_audio.Play();
    		}
    		
    	}
    }
}
