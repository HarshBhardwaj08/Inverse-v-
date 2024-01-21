using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public void SetUp(Vector3 position , float time )
    {
        transform.DOMove(position , time);
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        //damage player
        Destroy(gameObject , 0.1f);
    }
}
