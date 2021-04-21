using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float movespeed = 15;
    public int health = 3;
    public int score;
    public int scoremultiplier;
    public Animator animator;
    public int[] scoreArray = new int[] {0, 0, 0, 0};
    public int levelIndex;
    public AudioSource audio;
    public AudioSource audio2;
    public AudioSource audio3;
    private bool facingRight;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove){
            float moveDirection = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveDirection * movespeed, 0);
            Flip(moveDirection);
            animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        }
        scoreArray[levelIndex] = score;
    }

    private void Flip(float horizontal){
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;

            transform.localScale = scale;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy")){
            if(health == 1){
                StartCoroutine(Die());
            }else{
                audio2.Play();
                health = health - 1;
                animator.SetFloat("Health", Mathf.Abs(health));
            }
        }
        if (other.gameObject.CompareTag("Banana")){
            audio3.Play();
            score = score + (10 * scoremultiplier);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BananaBunch")){
            audio3.Play();
            score = score + (50 * scoremultiplier);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Vine")){
            canMove = false;
            StartCoroutine(Freeze());
            //Debug.Log("Vine!");
        }
    }

    IEnumerator Freeze(){
        rb.velocity = new Vector2(0,0);
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(0.15f);
        canMove = true;
    }

    IEnumerator Die(){
        health = health - 1;
        canMove = false;
        audio.Play();
        animator.SetFloat("Health", Mathf.Abs(health));
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetInt("totalscore", (PlayerPrefs.GetInt("totalscore") + score));
        SceneManager.LoadScene("GameOver");
    }
}
