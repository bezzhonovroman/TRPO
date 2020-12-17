using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordUpdater : MonoBehaviour
{
    public GameObject recordTemplate;
    // Start is called before the first frame update
    void Start()
    {
        int CountRecords = PlayerPrefs.GetInt("CountRecords");
        int CurrentScoreCount = PlayerPrefs.GetInt("ScoreCount");
        Debug.Log("CountRecords " + CountRecords);
        Debug.Log("CurrentScoreCount " + CurrentScoreCount);
        Debug.Log("CurrentName" + PlayerPrefs.GetString("CurrentName"));
        if (CurrentScoreCount != -1)
        {
            PlayerPrefs.SetString("Name" + CountRecords, PlayerPrefs.GetString("CurrentName")); ;
            PlayerPrefs.SetInt("Score" + CountRecords, CurrentScoreCount);
            PlayerPrefs.SetInt("ScoreCount", -1);
            PlayerPrefs.SetInt("CountRecords", ++CountRecords);
        }
        

        for (int i = 0; i < CountRecords; i++)
        {
            string name = PlayerPrefs.GetString("Name" + i);
            int ScoreCount = PlayerPrefs.GetInt("Score" + i);
            GameObject createdRecord = Instantiate(recordTemplate, transform);
            createdRecord.transform.SetAsFirstSibling();
            RecordController recordController = createdRecord.GetComponent<RecordController>();
            recordController.Name = name;
            recordController.Score = ScoreCount;
            
        }
    }
    
  
}
