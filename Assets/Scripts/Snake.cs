using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Vector2 SnakesDirection = Vector2.right;

    public List<Transform> _segments;

    public Transform segmentPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            SnakesDirection = Vector2.up;
        }   
        else if(Input.GetKeyDown(KeyCode.S)) { SnakesDirection = Vector2.down; }
        else if (Input.GetKeyDown(KeyCode.D)) { SnakesDirection = Vector2.right; }
        else if(Input.GetKeyDown(KeyCode.A)) { SnakesDirection = Vector2.left;}
    }

    private void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i-1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + SnakesDirection.x, Mathf.Round(this.transform.position.y) + SnakesDirection.y, 0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
    }
}
