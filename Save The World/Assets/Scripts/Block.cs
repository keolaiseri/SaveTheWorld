using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    //Cached Reference
    Level level;
    
    

    public void Start()
    {
        
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockDestroyed();
        
        

    }

    private void BlockDestroyed()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed(); 

    }

    private void TriggerSparklesVFX()
    {

        GameObject sparkles = Instantiate(blockSparklesVFX);

    }




}
