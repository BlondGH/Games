using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;
    private List<Transform> snakeCircles = new List<Transform> ();
    private List<Vector3> positions = new List<Vector3> ();
    public int Length = 1;

    public TextMeshPro PointsText;
    void Start()
    {
        positions.Add(SnakeHead.position);
        PointsText.SetText(Length.ToString());
        AddCircle();


    }

    // Update is called once per frame
    void Update()
    {
        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;
        if (distance > CircleDiameter)
        {
            Vector3 direction = ((Vector3)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }
        for ( int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }
    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        Length++;
        PointsText.SetText(Length.ToString());

    }
    public void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
    }
}
