using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyObject());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5f);
        if (this.gameObject != null)
            Destroy(this.gameObject);
    }
}
