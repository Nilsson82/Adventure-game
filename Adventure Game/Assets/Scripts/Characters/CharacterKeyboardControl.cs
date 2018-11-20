﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKeyboardControl : CharacterBaseControl
{
	
    // Update is called once per frame
    void Update ()
    {
        UpdateDirection();
        UpdateAction();
    }

    void UpdateAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnActionPressed();
        }
    }

    void UpdateDirection()
    {
        Vector2 newDirection = Vector2.zero;

        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            newDirection.y = 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newDirection.y = -1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newDirection.x = 1;
        }

        SetDirection(newDirection);


    }
}
