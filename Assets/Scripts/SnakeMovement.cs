using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed;
    public float sensativity;
    public int value;
    public int Health = 1;
    public TextMeshPro PointsText;
    private Camera mainCamera;
    private Rigidbody componentRigidbody;
    private SnakeTail componentSnakeTail;
    private Vector3 touchLastPos;
    private float sidewaysSpeed;


    private void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();

    }
    private void Update() //controls
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition;
            sidewaysSpeed = delta.x * sensativity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }


    }
    private void FixedUpdate()
    {

        componentRigidbody.velocity = new Vector3(sidewaysSpeed, 0, ForwardSpeed);
        sidewaysSpeed = 0;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Debug.Log("Enter");
            value = collision.gameObject.GetComponent<Food>().Value;
            Health += value;
            PointsText.SetText(Health.ToString());
            Destroy(collision.gameObject);

            for (int i = 0; i < value; i++)
            {
                Health++;
                componentSnakeTail.AddCircle();
            }
        }
        else if (collision.gameObject.tag == "Block")
        {
            value = collision.gameObject.GetComponent<Block>().Value;
            if (value >= Health)
            {

                componentRigidbody.velocity = Vector3.zero;
            }
            else
            {
                Health -= value;
                PointsText.SetText(Health.ToString());
                Destroy(collision.gameObject);

                for (int i = 0; i < value; i++)
                {
                    Health--;
                    componentSnakeTail.RemoveCircle();
                }
            }
        }
        
    }
}
//if (Input.GetMouseButtonDown(0))
//{
//   touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
//}
//if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
