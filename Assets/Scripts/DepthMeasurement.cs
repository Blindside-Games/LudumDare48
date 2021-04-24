using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthMeasurement : MonoBehaviour
{
    public Text label;
    public GameObject floor;

    float depth = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var fromPosition = transform.position;
        var toPosition = floor.transform.position;
        var direction = toPosition - fromPosition;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.collider != null && hit.collider.tag.Equals("Terrain"))
            {
                depth = hit.distance;
            }
        }

        label.text = $"Depth: {depth.ToString("n2")}m";
    }
}
