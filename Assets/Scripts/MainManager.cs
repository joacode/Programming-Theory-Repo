using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int sphereCounter;

    // ENCAPSULATI0N

    public int bestScore; // backing field
    public int T_bestScore
    {
        get { return bestScore; } // getter returns backing field
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative best score!");
            }
            else
            {
                bestScore = value; // setter uses backing field
            }
        }

    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateCounter(int plus)
    {
        sphereCounter += plus;
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
    }
    public void SaveParam()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadParam()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScore;
        }
    }
}
