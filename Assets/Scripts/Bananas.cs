using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : MonoBehaviour
{
    private Rigidbody2D rb;
    // private Vector2 screenBounds;
    // private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        // screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -24){
            Destroy(this.gameObject);
        }
    }
}
