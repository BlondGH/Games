using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnerMove : MonoBehaviour
{
    private Rigidbody componentRigidbody;
    
    private void Update()
    {
        componentRigidbody = GetComponent<Rigidbody>();
        componentRigidbody.velocity = new Vector3(0, 0, 5);
    }
}
