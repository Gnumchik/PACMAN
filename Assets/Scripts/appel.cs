using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class appel : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI _text;
    public static int _number = 0;
    private GameObject player;
    public int bonuskall = 177;

    [SerializeField] public AudioClip audioClip;
    private AudioSource audioSource;
    private void Start()
    {
        _number = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            _number++;
            _text.text = _number.ToString();
            
            Destroy(gameObject);
           
        }


        if(_number == bonuskall)
        {
            SceneManager.LoadScene(1);
        }

    }
}
