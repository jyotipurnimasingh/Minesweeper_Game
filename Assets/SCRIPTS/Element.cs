using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public bool mine;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    public GameOver GameOver;
    public Winner Winner;
    public AudioSource gameoverSound;
 
    private float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreScript.scoreValue = 0;
        if (DifficultyScript.e)
        {
            z = 0.05f;
        }
        else if (DifficultyScript.m)
        {
            z = 0.15f;
        }
        else if (DifficultyScript.h)
        {
            z = 0.25f;
        }



        mine = Random.value < z;
        ScoreScript.scoreValue = 0;

        // Register in Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.elements[x, y] = this;
    }

    void Update()
    {
        if(TimeScript.zero)
        {
            GameOver.gameOver();
            TimeScript.zero = false;


        }
    }

    public void loadTexture(int adjacentCount)
    {
        if (mine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
        }
    }
    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }
    void OnMouseUpAsButton()
    {
        // It's a mine
        if (mine)
        {
            Playfield.uncoverMines();
            // game over
            GameOver.gameOver();
            gameoverSound.Play();
        }
        // It's not a mine
        else if(isCovered())
        {

            TimeScript.reset = true;
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Playfield.adjacentMines(x, y));

            Playfield.FFuncover(x, y, new bool[Playfield.w, Playfield.h]);

            // find out if the game was won now
            if (Playfield.isFinished())
            {
                Winner.winner();
               
            }
            //print("you win");

        }
    }
}
