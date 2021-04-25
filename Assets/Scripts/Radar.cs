using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    public float insideRadarDistance = 20;
    public float blipSizePercentage = 5;
    public RawImage background;
    public GameObject rawImageBlip;
    private Transform playerTransform;

    private float radarWidth, radarHeight, blipHeight, blipWidth;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        background = GetComponent<RawImage>();

        radarHeight = background.rectTransform.rect.height;
        radarWidth = background.rectTransform.rect.width;

        blipHeight = radarHeight * blipSizePercentage / 100;
        blipWidth = radarWidth * blipSizePercentage / 100;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveAllBlips();

        FindAllBlipsForTag("Enemy");
        FindAllBlipsForTag("PickUp");
    }

    private void RemoveAllBlips()
    {
        var blips = GameObject.FindGameObjectsWithTag("Blip");

        foreach (var blip in blips)
            Destroy(blip);
    }

    private void FindAllBlipsForTag(string tag)
    {
        var playerPosition = playerTransform.position;
        var targets = GameObject.FindGameObjectsWithTag(tag);

        foreach (var target in targets)
        {
            var targetPosition = target.transform.position;
            var distanceToTarget = Vector3.Distance(targetPosition, playerPosition);

            if (distanceToTarget <= insideRadarDistance)
            {
                var normalisedTargetPos = NormalisedPosition(playerPosition, targetPosition);
                var blipPosition = CalculateBlipPosition(normalisedTargetPos);

                DrawBlip(blipPosition);
            }
        }
    }

    private void DrawBlip(Vector3 blipPosition)
    {
        GameObject blipGO = (GameObject)Instantiate(rawImageBlip);

        blipGO.transform.SetParent(transform.parent);

        RectTransform rt = blipGO.GetComponent<RectTransform>();

        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, blipPosition.x, blipWidth);

        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, blipPosition.y, blipHeight);
    }

    private Vector2 CalculateBlipPosition(Vector3 normalisedTargetPos)
    {
        // find angle from player to target
        float angleToTarget = Mathf.Atan2(normalisedTargetPos.x, normalisedTargetPos.z) * Mathf.Rad2Deg;

        // direction player facing
        float anglePlayer = playerTransform.eulerAngles.y;

        // subtract player angle, to get relative angle to object
        // subtract 90
        // (so 0 degrees (same direction as player) is UP)
        float angleRadarDegrees = angleToTarget - anglePlayer - 90;

        // calculate (x,y) position given angle and distance
        float normalisedDistanceToTarget = normalisedTargetPos.magnitude;
        float angleRadians = angleRadarDegrees * Mathf.Deg2Rad;
        float blipX = normalisedDistanceToTarget * Mathf.Cos(angleRadians);
        float blipY = normalisedDistanceToTarget * Mathf.Sin(angleRadians);

        // scale blip position according to radar size
        blipX *= radarWidth / 2;
        blipY *= radarHeight / 2;

        // offset blip position relative to radar center
        blipX += radarWidth / 2;
        blipY += radarHeight / 2;

        return new Vector2(blipX, blipY);
    }

    private Vector3 NormalisedPosition(Vector3 playerPosition, Vector3 targetPosition)
    {
        float normalisedyTargetX = (targetPosition.x - playerPosition.x) / insideRadarDistance;
        float normalisedyTargetZ = (targetPosition.z - playerPosition.z) / insideRadarDistance;

        return new Vector3(normalisedyTargetX, 0, normalisedyTargetZ);
    }
}
