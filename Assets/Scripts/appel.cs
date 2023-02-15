using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class appel : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI _text;
    public static int _number = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _number++;
            _text.text = _number.ToString();
            Destroy(gameObject);
           
        }
        if(_number == 112)
        {
            SceneManager.LoadScene(1);
        }
    }
}
