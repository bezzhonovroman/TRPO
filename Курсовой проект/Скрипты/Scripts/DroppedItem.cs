using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Bag.Instance.AddCoin(1);
            Destroy(gameObject);
           
        }
    }

    public void Explode()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-75f, 75f), Random.Range(0f, 30f)));
    }
}

