using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RollCommand : MonoBehaviour
{

    private Vector3 target;
    public float speed = 1.0f;
    
    public void OnEnable()
    {
        target = transform.position;
    }

    public void Roll()
    {
        Transform cursor = GameManager.GetCursorPosition();
        if (cursor)
        {
            target = cursor.position;
        }
    }

    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}
