using UnityEngine;

public class Score
{
    public static int Count {get; set;}
    public static int BestScore => PlayerPrefs.GetInt(Strings.BestScore, 0);

    public static void SaveBestScore(){
        if(Count > BestScore){
            PlayerPrefs.SetInt(Strings.BestScore, Count);
        }
    }
}
