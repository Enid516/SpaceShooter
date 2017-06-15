using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    /** 爆炸效果*/
    public GameObject explosion;
    public GameObject playerExplosion;

    public int score;
    private GameController gameController;

    private void Start()
    {
        GameObject gameComtrollerObject = GameObject.FindWithTag("GameController");
        if (gameComtrollerObject != null)
        {
            gameController = gameComtrollerObject.GetComponent<GameController>();
        }
        if (gameComtrollerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Asteroid")
        {
            return;
        }
     
        Instantiate(explosion, transform.position, transform.rotation);
        
        if (other.tag == "Player")
        {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
           
        }

        gameController.addScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
