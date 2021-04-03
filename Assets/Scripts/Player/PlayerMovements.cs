using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;

public class PlayerMovements : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float swapDistance = 0f;

    public float groundDistance = 0.2f;
    public LayerMask ground;
    public float gravity = -9.81f;

    private bool _isGrounded = true;
    public Transform _groundChecker;
    private Vector3 _velocity;

    private float turnSmoothVelocity;
    private string _seed;
    private Clone cloneComponent;
    private Vector3 _direction;

    public MaterialManager _mm;
    public Renderer _render;

    public Animator _anim;
    private AudioSource _audio;

    public string Seed
    {
        get { return _seed; }
        set { _seed = value; }
    }

    public Vector3 Direction
    {
        get { return _direction; }
    }

    void Start()
    {
    	_audio = GetComponent<AudioSource>();
        Seed = SeedsGenerator.GenerateRandomSeed();
        _mm.ChangeMaterials(_render, _seed);
    }

    void Update()
    {
        Movement();
       // SwapSeedInfo();
        Swap();
        GravitySampler();
    }

    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        cloneComponent = (Clone)SeedsGenerator.characterDetection<Clone>(transform.position, transform.TransformDirection(Vector3.forward), swapDistance, layerMask);
    }

    private void Swap()
    {
        if(cloneComponent != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            	{
                	Seed = SeedsGenerator.SeedSwap(cloneComponent, Seed);
                	_mm.ChangeMaterials(_render, _seed);
                	_audio.Play();
            	}
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _direction = new Vector3(horizontal, 0f, vertical).normalized;
        _anim.SetBool("Caminar", false);

        if (_direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _anim.SetBool("Caminar", true);

            controller.Move(_direction * speed * Time.deltaTime);
        }
    }

    private void GravitySampler()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }

    public void ChangeSkin()
    {
    	_mm.ChangeMaterials(_render, Seed);
    }

    // TESTING ONLY
    //private void SwapSeedInfo()
    //{
    //    if(Input.GetKeyDown(KeyCode.P))
    //    {
    //        Debug.Log(Seed);
    //    }
    //}

    //RaycastHit hit;
    //if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, swapDistance, layerMask)) {
    //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

    //    if (hit.collider.gameObject.GetComponent<Clone>())
    //    {
    //        cloneComponent = hit.collider.gameObject.GetComponent<Clone>();
    //    }
    //}
    //else
    //{
    //    cloneComponent = null;
    //}
}
