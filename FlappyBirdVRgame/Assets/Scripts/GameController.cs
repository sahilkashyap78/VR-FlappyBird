using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Bird bird;
    public GameObject[] blockprefabs;
    public float maximumSpawnDistance = 30f;
    private float spawnpointer = 0f;
    public TextMesh infotext;
    private float GameOverTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        spawnpointer = maximumSpawnDistance/3;
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.transform.position.z + maximumSpawnDistance > spawnpointer)
        {
            GameObject block = blockprefabs[Random.Range(0, blockprefabs.Length)];
            GameObject blockobject = Instantiate(block);
            blockobject.transform.position = new Vector3(0, 0, spawnpointer);
            spawnpointer += blockobject.GetComponent<Block> ().size;
        } 
        if(bird.dead==false)
        {

            infotext.text = "Score: " +Mathf.FloorToInt(bird.transform.position.z) ;
        }
        else
        {
            infotext.text = "GAME OVER!!!!\nFinal score: " + Mathf.FloorToInt(bird.transform.position.z);
            GameOverTimer -= Time.deltaTime;
            if(GameOverTimer<=0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
