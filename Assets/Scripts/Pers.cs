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

    public bool enamyEat = false;
    public GameObject[] enemy;
    public GameObject bonys;

    public NextEnemyWalker[] nextEnemyWalker;

    [SerializeField] GameObject[] health;

    void Start()
    {
        _hp = 3;
    }
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3);
        enamyEat = false;
    }

    void Update()
    {
        if (enamyEat == false)
        {
            enemy[0].GetComponent<SpriteRenderer>().color = new Color(255, 165, 0);
            enemy[1].GetComponent<SpriteRenderer>().color = new Color(0, 234, 255);
            enemy[2].GetComponent<SpriteRenderer>().color = new Color(11, 255, 0);
            enemy[3].GetComponent<SpriteRenderer>().color = new Color(255, 0, 205);
        }
        if(enamyEat == true)
        {
            StartCoroutine(ExecuteAfterTime());   
        }


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
        if(collision.gameObject.tag == "Enemy" && enamyEat == false)
        {
            Health();
        }
        if(collision.gameObject.tag == "Bonus")
        {
            enamyEat = true;
            Destroy(bonys);
            enemy[0].GetComponent<SpriteRenderer>().color = Color.blue;
            enemy[1].GetComponent<SpriteRenderer>().color = Color.blue;
            enemy[2].GetComponent<SpriteRenderer>().color = Color.blue;
            enemy[3].GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (enamyEat == true && collision.gameObject.tag == "Enemy")
        {
            nextEnemyWalker[0].Start();
            nextEnemyWalker[1].Start();
            nextEnemyWalker[2].Start();
            nextEnemyWalker[3].Start();
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
