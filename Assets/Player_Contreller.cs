using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Contreller : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    int count = 0;
    public int x;
    public Text ScoreText, WinText;
    int TargetCount = 18;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            //objeyi topla
            //collision.gameObject.SetActive(false);
            Destroy(other.gameObject);
            count++;
            Debug.Log(ScoreText);

            ScoreText.text = "Score :" + count.ToString();

            Debug.Log(count);
            if (count >= TargetCount)
            {
                // Oyunu kazandık
                WinText.gameObject.SetActive(true);
            }
  
        }

    }
}
    