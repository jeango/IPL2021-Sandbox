using System;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private bool _canSpeak = false;

    private void Update()
    {
        if (!_canSpeak) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Hello there!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<ITalkable>() != null)
            _canSpeak = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<ITalkable>() != null)
            _canSpeak = false;
    }
    
}