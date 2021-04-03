using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destinations : MonoBehaviour
{

	public List<Transform> destinations = new List<Transform>();
    
    public Vector3 NewDestiantion(Vector3 lastVector)
    {
    	int n = Random.Range(0, destinations.Count - 1);

    	

    	while(lastVector == destinations[n].position)
    	{
    		n = Random.Range(0, destinations.Count - 1);
    		
    	}

    	return destinations[n].position;
    }
}
