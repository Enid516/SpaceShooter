using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public Done_Boundary boundary;
    private Rigidbody rigidbody;
    private bool isOver = true;
    //bolt
    /** 记录下一发子弹的时间*/
    private float nextFire;
    /** 用来控制子弹发射的时间间隔*/
    public float fireRate;
    /** 用来保存我们发射的子弹Prefab,告诉程序要发射的是哪一个子弹*/
    public GameObject shot;
    /** 用来保存子弹的发射点*/
    public Transform shotSqawn;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        //    transform.Translate(touchDeltaPosition.x * speed, 0.0f, touchDeltaPosition.y * speed);
        //    //transform.position = touchDeltaPosition;
        //}
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSqawn.position, shotSqawn.rotation);
        }
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}
