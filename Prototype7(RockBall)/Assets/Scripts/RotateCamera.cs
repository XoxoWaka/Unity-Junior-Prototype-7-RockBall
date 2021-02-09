﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //вращение  при пользовательском вводе
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * -rotationSpeed);
    }
}
