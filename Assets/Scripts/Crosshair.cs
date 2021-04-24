using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D sprite;

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (sprite.width / 2);
        float yMin = (Screen.height / 2) - (sprite.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, sprite.width, sprite.height), sprite);
    }
}
