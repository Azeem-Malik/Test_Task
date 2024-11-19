using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScripTest : MonoBehaviour
{
    public int enemyCount=2, playerScore=1;
    public GameObject player, enemy,particle;
    public Rigidbody2D playerbody;
    public float moveSpeed;
    public Text enemeyCountText, playerScoreText;
    public AudioSource audioClip;
    // Start is called before the first frame update
    void Start()
    {
        playerbody=GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemey"))
        {
            Debug.LogError("Collided");
            Destroy(enemy);
            enemyCount--;
            playerScore++;
            playerbody.isKinematic = true;
           
            particle.SetActive(true);
            audioClip.Play();
        }
    }

    private void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * moveSpeed;
        Vector2 move=new Vector3(transform.position.x+10, transform.position.y); 
        //playerbody.MovePosition(playerbody.position + move * Time.fixedDeltaTime);
        playerbody.AddForce(move);
        playerScoreText.text = playerScore.ToString();
        enemeyCountText.text = enemyCount.ToString();
    }

}
