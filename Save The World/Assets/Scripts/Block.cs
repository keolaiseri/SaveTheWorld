using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Cached Reference
    Level level;
    GameStatus gameStatus;
    

    public void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockDestroyed();
        gameStatus.AddToScore();

    }

    private void BlockDestroyed()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        

    }
}
