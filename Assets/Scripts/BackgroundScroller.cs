using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D colliders;
    public Rigidbody2D rb; 

    public int screensCleared = 0;
    private float screenheight;
    public float scrollSpeed = -2f;
    public int screenMultiplier;
    private int[] enemyPos = new int[] {0,-3,3,-6,6};

    // Start is called before the first frame update
    void Start()
    {
        colliders = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        screenheight = colliders.size.y;
        colliders.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
        ResetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -screenheight * 2){
            Vector2 resetPosition = new Vector2(0, screenheight * 2f);
            transform.position = (Vector2) transform.position + resetPosition;
            screensCleared = screensCleared + 1;
            if (screensCleared == 10 * screenMultiplier){
                StartCoroutine(NextLevel());
            }
            ResetEnemy();
        }
    }

    void ResetEnemy(){
        transform.GetChild(0).GetChild(0).localPosition = new Vector3(enemyPos[Random.Range(0,5)],Random.Range(-8,3), -1);
        transform.GetChild(0).GetChild(1).localPosition = new Vector3(enemyPos[Random.Range(0,5)],Random.Range(4,16), -1);
    }

    IEnumerator NextLevel(){
        GameObject thePlayer = GameObject.Find("Player");
        PlayerController player = thePlayer.GetComponent<PlayerController>();
        PlayerPrefs.SetInt("totalscore", (PlayerPrefs.GetInt("totalscore") + player.score));
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
