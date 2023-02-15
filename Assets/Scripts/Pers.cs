using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pers : MonoBehaviour
{

    public float moveInputt = 10;
    public float speed = 60;
    public Vector2 dir = Vector2.zero;

    private int _hp = 3;
    public GameObject[] _number;
    public static Action Death;

    [SerializeField] GameObject[] health;

    void Start()
    {
        _hp = 3;
    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInputt = 10;
            dir = Vector2.left * speed;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInputt = 10;
            dir = Vector2.right * speed;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveInputt = 10;
            dir = Vector2.down * speed;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            moveInputt = 10;
            dir = Vector2.up * speed;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else
        {
            moveInputt = 0;
        }


        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Health();
        }
    }


    public Pers(GameObject[] health)
    {
        _number = health;
    }

    public void Health()
    {
        _hp--;
        _number[_hp].SetActive(false);
        if (_hp <= 0)
        {
            Death?.Invoke();
        }
        if (_hp <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }



}
