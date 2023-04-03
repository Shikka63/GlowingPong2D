using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] public KeyCode moveUp;
    [SerializeField] public KeyCode moveDown;
    [SerializeField] public float speed;
    [SerializeField] public float boundY;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var racketVelocity = rb2d.velocity;
        if (ScoreSystem.instance.isPaused == false)
        {
            if (Input.GetKey(moveUp))
            {
                //Debug.Log("jalan keatas");
                racketVelocity.y = speed;
            }
            else if (Input.GetKey(moveDown))
            {
                //Debug.Log("jalan kebawah");
                racketVelocity.y = -speed;
            }
            //else if (Input.GetKeyDown(KeyCode.P) && ScoreSystem.instance.isPaused == false)
            //{
            //    ScoreSystem.instance.Paused("Game Paused!");
            //}
            else
            {
                racketVelocity.y = 0;
            }
            rb2d.velocity = racketVelocity;
        }
        //if (Input.GetKeyDown(KeyCode.P));
        //{
        //    ScoreSystem.instance.isPaused = !ScoreSystem.instance.isPaused;
        //    if (ScoreSystem.instance.isPaused == true)
        //    {
        //        ScoreSystem.instance.Paused("Game Paused!");
        //    }
        //    else
        //    {
        //        ScoreSystem.instance.Resume();
        //    }
            
        //}


        var racketPosition = transform.position;
        if (racketPosition.y > boundY)
        {
            racketPosition.y = boundY;
        } else if (racketPosition.y < -boundY)
        {
            racketPosition.y = -boundY;
        }
        transform.position = racketPosition;
    }
}
