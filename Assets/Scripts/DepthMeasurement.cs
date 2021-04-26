using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthMeasurement : MonoBehaviour
{
    public Text label;
    public GameObject player;

    float depth = 123f;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        var fromPosition = transform.position;
        var toPosition = player.transform.position;
        var direction = toPosition - fromPosition;

        Debug.DrawRay(fromPosition, direction, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 4000, 1 << 8))
        {
            if (hit.collider != null && hit.collider.tag.Equals("Player"))
            {
                depth = hit.distance;
            }

            depth = startY - depth;
            var player = GameObject.FindWithTag("Player");

            if (depth >= player.GetComponent<StatsController>().MaxHullDepth)
            {
                player.GetComponent<IAttackable>().Attack(new AttackInfo
                {
                    Damage = 2 * Time.deltaTime
                });
            }
        }

        label.text = $"Depth: {depth.ToString("n2")}m";
    }
}
