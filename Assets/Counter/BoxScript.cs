using TMPro;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public TextMeshProUGUI BestScoreText;
    private AudioSource source;

    public int Count;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        // load data from file
        MainManager.Instance.LoadParam();

        Count = 0;

        CounterText.gameObject.SetActive(true);
        BestScoreText.gameObject.SetActive(true);

        CounterText.text = "Points : " + Count;
        BestScoreText.text = "Best Score: " + MainManager.Instance.bestScore;
    }

    void Update()
    {
        if (Count > MainManager.Instance.bestScore)
        {
            MainManager.Instance.bestScore = Count;

            BestScoreText.text = "Best Score: " + MainManager.Instance.bestScore;
        }
        else
        {
            BestScoreText.text = "Best Score: " + MainManager.Instance.bestScore;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Sphere")
        {
            source.Play();

            Count += 1;
            CounterText.text = "Points : " + Count;

            if (Count > MainManager.Instance.bestScore)
            {
                MainManager.Instance.bestScore = Count;

                BestScoreText.text = "Best Score: " + MainManager.Instance.bestScore;
            }

            MainManager.Instance.UpdateCounter(1);

            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "Hat")
        {
            source.Play();

            Count += 5;
            CounterText.text = "Points : " + Count;

            if (Count > MainManager.Instance.bestScore)
            {
                MainManager.Instance.bestScore = Count;

                BestScoreText.text = "Best Score: " + MainManager.Instance.bestScore;
            }

            MainManager.Instance.UpdateCounter(5);

            Destroy(collision.gameObject);
        }
    }
}
