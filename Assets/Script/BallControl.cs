using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public AudioSource hitSound;
    //Vector2 defaultVelocity;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //mengambil rigidbody component dari sebuah bole
        Invoke("GoBall", 2); //memanggil function GoBall dlm 2 detik
        rb2d.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = rb2d.velocity + (rb2d.velocity * 0.002f);
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2); //akan random nilai diantara 0-1
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15)); //add force memberikan tenaga
            //liat doc add force disini https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void ResetBall() //ini kita buat nilai transform jadi 0
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(-0.79f, 0.18f);
    }

    void BolaMasuk()
    {
        rb2d.velocity = Vector2.zero;
        ResetBall();
        Invoke("GoBall", 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hitSound.Play();
        AudioController.instance.DefaultHitSound();
        if (collision.collider.CompareTag("Player")) //jika terkena player
        {
            Vector2 velocity;
            velocity.x = rb2d.velocity.x;
            
            //mengambil nilai velocity player
            velocity.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = velocity;
        }
    }
}
