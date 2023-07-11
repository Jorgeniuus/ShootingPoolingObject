using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    [SerializeField] private float speedBullet;

    private void Update()
    {
        this.transform.position += transform.up * speedBullet * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
