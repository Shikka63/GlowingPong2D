using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraShake;

public class Gawang : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            CameraShaker.Presets.ShortShake2D();
            AudioController.instance.GoaltHitSound();
            string gawangName = transform.name;
            //memanggil method Score di GameManager.cs
            ScoreSystem.instance.Score(gawangName);
            //memanggil method RestartGame() di BallControl.cs
            collision.gameObject.SendMessage("BolaMasuk", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
