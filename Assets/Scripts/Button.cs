using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Door door;
    
    private bool _isClosed = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BlasterBolt"))
        {
            if (_isClosed)
            {
                door.Open();
                _isClosed = false;
            }
            else
            {
                door.Close();
                _isClosed = true;
            }
            
        }
    }
}
