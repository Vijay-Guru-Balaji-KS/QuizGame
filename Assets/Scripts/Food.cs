using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Food : MonoBehaviour
{
    public BoxCollider2D BoxRange;
    // Start is called before the first frame update
    
    void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.BoxRange.bounds;
        float xaxis = Random.Range(bounds.min.x,bounds.max.x);
        float yaxis = Random.Range(bounds.min.y,bounds .max.y);
        this.transform.position = new Vector3(Mathf.Round(xaxis), Mathf.Round(yaxis), 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            RandomizePosition();
        }
    }
}
