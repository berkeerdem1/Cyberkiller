using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;
    public float endTime;
    public GameObject patlama;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, endTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {

            collision.GetComponent<playercontroller>().TakeDamage(10);
            Destroy(gameObject);
        }
        GameObject sil = Instantiate(patlama, transform.position, transform.rotation);
        Destroy(sil, 0.617f);

    }
}
