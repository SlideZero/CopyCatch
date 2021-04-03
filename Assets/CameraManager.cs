using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public GameObject _cam;

	public Transform screen;
	public Transform normal;


	private float startTime;
	private float journeyLength;
	public float speed = 1.0F;
   

    // Update is called once per frame

    void Start()
    {
    	startTime = Time.time;
    	journeyLength = Vector3.Distance(_cam.transform.position, normal.position);
    }

    void Update()
    {

    	if(Input.GetKeyDown("left shift"))
    	{
    		startTime = Time.time;
    		journeyLength = Vector3.Distance(_cam.transform.position, screen.position);
    	}

    	if(Input.GetKeyUp("left shift"))
    	{
    		startTime = Time.time;
    		journeyLength = Vector3.Distance(_cam.transform.position, normal.position);
    	}




        if(Input.GetKey("left shift"))
        {
        	float distCovered = (Time.time - startTime) * speed;
        	float fractionOfJourney = distCovered / journeyLength;
        	_cam.transform.position = Vector3.Lerp(_cam.transform.position, screen.position, fractionOfJourney);
        	_cam.transform.rotation = Quaternion.Slerp(_cam.transform.rotation, screen.rotation, fractionOfJourney);
        }else
        {
        	float distCovered = (Time.time - startTime) * speed;
        	float fractionOfJourney = distCovered / journeyLength;
        	_cam.transform.position = Vector3.Lerp(_cam.transform.position, normal.position, fractionOfJourney);
        	_cam.transform.rotation = Quaternion.Slerp(_cam.transform.rotation, normal.rotation, fractionOfJourney);
        }
    }
}
