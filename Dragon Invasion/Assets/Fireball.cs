using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public GameObject burst;
    public ParticleSystem ps;
    public ParticleSystem ps2;
    public Collider2D col;
    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Update()
    {
        if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col.gameObject.tag == "Obstacle")
        {
            Instantiate(burst, transform.position, Quaternion.identity);
            ps.Stop();
            ps2.Stop();
            speed = 0;
            col.enabled = false;
        }
    }
}
