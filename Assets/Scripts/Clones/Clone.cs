using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Seeds;

public class Clone : MonoBehaviour
{
	private Vector3 target;

	public MaterialManager _mm;

	public GameObject player;

	public Renderer _render;

	public Destinations destinations;

	public string Seed;

	private int state = 0; // 0 - stop, 1 - destiantion, 2 - player direction

	NavMeshAgent agent;

	private float stopTimer = 0;

	public Animator _anim;

    // Start is called before the first frame update
	void Awake()
	{
		Seed = SeedsGenerator.GenerateRandomSeed();
	}

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        
        _mm.ChangeMaterials(_render, Seed);
    }

    // Update is called once per frame
    void Update()
    {

    	if(agent.velocity.magnitude < 1)
    	{
    		_anim.SetBool("Caminar", false);
    	}else
    	{
    		_anim.SetBool("Caminar", true);
    	}


    	if(state == 0)
    	{
    		//Estado stop
    		
    		agent.isStopped = true;

    		stopTimer += Time.deltaTime;

    		if(stopTimer > 1)
    		{
    			state = 1;
    			stopTimer = 0;
    		}

    	}else if(state == 1)
    	{
    		
    		agent.isStopped = false;
    		agent.SetDestination(target);


	        float dist = agent.remainingDistance;

	        if(dist <= 0.5f)
	        {
	        	GetNewTarget();
	        	state = Random.Range(0, 1);
	        }
    	}
        
    }


    public void GetNewTarget()
    {
    	target = destinations.NewDestiantion(target);
    }

    void OnCollisionEnter(Collision col)
    {
    	if(col.transform.tag == "Clone")
    	{
    		if(Vector3.Dot(transform.forward, col.transform.forward) < -0.3f)
    		{
    			GetNewTarget();
    			state = 0;
    		}
    		
    	}
    }

    public void ChangeSkin()
    {
    	_mm.ChangeMaterials(_render, Seed);
    }
}
