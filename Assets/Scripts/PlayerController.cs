using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Text livesText;
    public Text winText;
    public Text loseText;
    public Text nextText;
    public Text countText;
    public float jump;
    public GameObject player;
    public AudioClip musicClip1;
    public AudioClip musicClip2;
    public AudioClip musicClip3;
    public AudioSource MusicSource;

    private int count;
    private int lives;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        nextText.text = "";
        SetLivesText();
        SetCountText();

        MusicSource.clip = musicClip1;
        MusicSource.Play();
    }

    
    void Update()
    {
        if(Input.GetKey("escape")){
            Application.Quit();
        }
        
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other){

    if(other.gameObject.CompareTag("Pick up")){
        
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
        if(count == 4){
            lives = 3;
        SetLivesText();
        }
    }

    if(other.gameObject.CompareTag("enemy")){

        other.gameObject.SetActive(false);
        lives = lives -1;
        SetCountText();
        SetLivesText();

    }
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if(collision.collider.tag == "Ground"){

                if(Input.GetKey(KeyCode.UpArrow)){

                    rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);

                }

        }
        if(collision.collider.tag == "Platform"){

                if(Input.GetKey(KeyCode.UpArrow)){

                    rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);

                }

        }

    }

        void SetCountText(){
            countText.text = "Count: " + count.ToString ();

            if(count >= 8){
                winText.text = "You Win!!!";
            } 

            if(count == 4){
                transform.position = new Vector2(-29.72f, transform.position.y);
            }
            if(count == 8){
                MusicSource.Stop();
                MusicSource.clip = musicClip2;
                MusicSource.Play();
            }
        }
        void SetLivesText(){
            livesText.text = "Lives: " + lives.ToString ();

            if(lives <= 0){
                loseText.text = "You lose...";
                player.gameObject.SetActive(false);
                MusicSource.Stop();
                MusicSource.clip = musicClip3;
                MusicSource.Play();
            }
            
        }

}
