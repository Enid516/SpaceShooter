using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    /** 障碍物的翻转幅度*/
    public float tumble;
	// Use this for initialization
	void Start () {
        Random.Range(0.01f,1);
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
}
