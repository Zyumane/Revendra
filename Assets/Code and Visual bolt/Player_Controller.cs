using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player_Controller : MonoBehaviour
{
    public float _speed = 1.5f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.W)) transform.position += Vector3.forward * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) transform.position += Vector3.back * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) transform.position += Vector3.left * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) transform.position += Vector3.right * _speed * Time.deltaTime;
        
        if(Input.GetKey(KeyCode.Space))
        {
            FireComd();
        }
    }

    void FireComd()
    {
        //var  =Instantiate()
    }
}
