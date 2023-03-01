using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{

    public GameObject Portal;
    public GameObject Player;


    void Start()
    {

    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
        }
    }


    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.01f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }
}
