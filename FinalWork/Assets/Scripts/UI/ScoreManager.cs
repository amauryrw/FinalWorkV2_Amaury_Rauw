using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int goodResponses = 0;
    private int badResponses = 0;

    private List<string> badResponsesList = new List<string>(); 


    private void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGoodResponse()
    {
        goodResponses++;
        Debug.Log("Bonne réponse ! Total bonnes réponses : " + goodResponses);
    }

    public void AddBadResponse()
    {
        badResponses++;
        Debug.Log("Mauvaise réponse. Total : " + badResponses);
    }

    public int GetGoodResponse()
    {
        return goodResponses;
    }

    public int GetBadResponse()
    {
        return badResponses;
    }

    public int GetTotalTentatives()
    {
        return goodResponses + badResponses;
    }

    public float GetPourcentage()
    {
        if (GetTotalTentatives() == 0) return 0f;
        return (float)goodResponses / GetTotalTentatives() * 100f;
    }
}
