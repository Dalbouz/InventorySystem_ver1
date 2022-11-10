using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform Target;
    public float SmoothSpeed = 10f;
    public Vector3 Offset;
    public float Delay = 0.5f;
    private Vector3 desiredPosition;
    private Vector3 smoothPosition;
    private float _timer;
    private bool _isMoving = false;

    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //_targetPos = Player.instance._direction;
        Offset = transform.position;
    }


    private void FixedUpdate()
    {
        if(Player.instance._horizontal != 0 || Player.instance._vertical != 0)
        {
            if (!_isMoving)
            {
                _timer = Time.time + Delay*Time.deltaTime;
                _isMoving = true;
            }
        }
        if(Time.time > _timer)
        {
            desiredPosition = Target.position + Offset;
            smoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
        if(Player.instance._horizontal == 0 && Player.instance._vertical == 0)
        {
            _isMoving = false;
        }
        //if(Player.instance._horizontal == 0 && Player.instance._vertical == 0)
        //{
        //    _timer = float.MaxValue;
        //}
        //if(Target.position.x != transform.position.x || Target.position.y != transform.position.y)
        //{
        //    StartCoroutine(StartFollowing());
        //}
        //desiredPosition = Target.position + Offset;
        //smoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
        //transform.position = smoothPosition;
        

    }

    IEnumerator StartFollowing()
    {
        yield return new WaitForSeconds(Delay);
        desiredPosition = Target.position + Offset;
        smoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }

    public void MoveCamera()
    {
        _timer = Time.time + Delay;
    }
}
