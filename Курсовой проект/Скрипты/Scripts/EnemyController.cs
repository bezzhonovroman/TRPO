using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    private float direction = 1;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

   void OnTriggerEnter2D(Collider2D trigger)
    {
        
        if (trigger.gameObject.tag == "Trigger")
        {
            direction *= -1;
            sprite.flipX = !sprite.flipX;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (enemySpeed * Time.deltaTime * direction, 0);

    }
}
