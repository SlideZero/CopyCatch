using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] soundtrack;

    private AudioSource _ausioSourceBGM;

    private void Awake()
    {
        _ausioSourceBGM = GetComponent<AudioSource>();
    }

    void Start()
    {
        _ausioSourceBGM.clip = soundtrack[0];
        _ausioSourceBGM.Play();
    }

    void Update()
    {
        if(!_ausioSourceBGM.isPlaying)
        {
            _ausioSourceBGM.clip = soundtrack[1];
            _ausioSourceBGM.Play();
            _ausioSourceBGM.loop = true;
        }
    }
}
