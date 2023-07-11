using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed = 10f;

    private void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        float horirontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = transform.right * horirontal + transform.up * vertical;

        this.transform.Translate(movement.normalized * _speed * Time.deltaTime);
    }
}
