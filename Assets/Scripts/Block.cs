using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Block : MonoBehaviour
{
    public int Value;
    public TextMeshPro PointsText;
    Color lerpedColor = Color.white;
    Random rnd = new Random();

    void Start()
    {
        Value = rnd.Next(1,5);
        PointsText.SetText(Value.ToString());
        lerpedColor = Color.Lerp(Color.white, Color.red, (float)Value / 20f);
        this.GetComponent<Renderer>().material.color = lerpedColor;
    }
}
