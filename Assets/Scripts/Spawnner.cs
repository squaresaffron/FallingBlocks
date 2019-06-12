using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour {

    public GameObject fallingBlocks;
    public Vector2 SpawnTimeMinMax;
    float nextSpawmTime;
    public float spawnAngleMax;
    Vector2 screenHalfSize;

    public Vector2 spawnSizeMinMax;
    
    // Use this for initialization
    void Start () {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawmTime)
        {
            float SpawnTime = Mathf.Lerp(SpawnTimeMinMax.y, SpawnTimeMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawmTime = Time.time + SpawnTime;
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y); 
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);
            GameObject newBlock = (GameObject) Instantiate(fallingBlocks, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector3.one * spawnSize; 
        }
	}
}
