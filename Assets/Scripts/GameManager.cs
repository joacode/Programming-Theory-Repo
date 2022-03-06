using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    public GameObject title;

    public Button restartButton;

    public TextMeshProUGUI BallsText;
    public TextMeshProUGUI gameOver;

    private float maxY = 10;
    private float rangeX = 20;
    private float rangeZ = 10;
    private float rangeIndex;
    
    private int index;
    private int sphereCounter;
    private int parameter;

    public bool isGameActive = false;

    // Start is called before the first frame update
    public void StartGame(int diff)
    {
        parameter = diff;

        sphereCounter = 12;

        transform.position = SpawnPos(parameter);

        isGameActive = true;

        title.SetActive(false);

        BallsText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

            if (sphereCounter >= 12 && isGameActive)
            {
                RandomIndex();

                Instantiate(prefabs[index], SpawnPos(parameter), transform.rotation);

                sphereCounter--;
            }

            if (FindObjectsOfType<SphereBehaviour>().Length == 0 && sphereCounter > 0 && isGameActive)
            {
                RandomIndex();

                Instantiate(prefabs[index], SpawnPos(parameter), transform.rotation);

                sphereCounter--;

            }
            else if (FindObjectsOfType<SphereBehaviour>().Length == 0 && sphereCounter == 0 && isGameActive)
            {
                Debug.Log("Game Over");

                isGameActive = false;

                restartButton.gameObject.SetActive(true);
                gameOver.gameObject.SetActive(true);

            }

            if (sphereCounter >= 0)
            {
                BallsText.text = "Throws left: " + sphereCounter;    
            }
            else if ((sphereCounter < 0))
            {
                BallsText.text = "Throws left: 0";
            }
            
                
    }

    public void UpdateCounter(int plus)
    {
        sphereCounter += plus;
    }

    void RandomIndex()
    {
        rangeIndex = Random.Range(0f, 1f);

        if (rangeIndex < 0.8f)
        {
            index = 0;
        }
        else
        {
            index = 1;
        }
    }

    // Random position to spawn
    Vector3 SpawnPos(int difficulty)
    {
        Vector3[] randomPos = new Vector3[3];

        if (index == 1)
        {
            maxY = 10f - 3.5f;
        }
        else
        {
            maxY = 10f;
        }

        randomPos[0] = new Vector3(Random.Range(-rangeX, -10), maxY, Random.Range(-rangeZ, rangeZ));
        randomPos[1] = new Vector3(Random.Range(-rangeX, 0), maxY, Random.Range(-rangeZ, rangeZ));
        randomPos[2] = new Vector3(Random.Range(-rangeX, rangeX), maxY, Random.Range(-rangeZ, rangeZ));

        return randomPos[difficulty];
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

