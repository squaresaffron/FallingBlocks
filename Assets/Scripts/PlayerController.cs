using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    float screenHalfWidth;
    public event System.Action onPlayerDeath;

	// Use this for initialization
	void Start () {
        float playerHalfWidth = transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + playerHalfWidth;
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime); 

        if(transform.position.x < -screenHalfWidth)
        {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }
    
        if(transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            if(onPlayerDeath != null)
            {
                onPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
