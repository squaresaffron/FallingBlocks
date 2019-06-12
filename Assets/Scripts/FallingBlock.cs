﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    float speed;
    public Vector2 speedMinMax;
    float visibleHeightThreshold;

    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
