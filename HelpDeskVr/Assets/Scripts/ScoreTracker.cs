using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Score
{
    public int laptopsFixed;
    public int laptopsFailed;
    public string playerName;

    public override string ToString()
    {
        string str = playerName + "\t" +
                     laptopsFixed + "\t" + 
                     laptopsFailed + "\n";
        return str; 
    }
}

public class ScoreComparer : IComparer<Score>
{
    public int Compare(Score a, Score b)
    {
        // if a is bigger a goes first

        // if a is smaller a goes first
        if (a.laptopsFixed > b.laptopsFixed)
        {
            return -1;
        }
        else if (a.laptopsFixed == b.laptopsFixed)
        {
            if (a.laptopsFailed < b.laptopsFailed)
            {
                return -1;
            }
            else if (a.laptopsFailed == b.laptopsFailed)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 1;
        }
    }
}

public class ScoreTracker : MonoBehaviour {

    public Score currentScore;

    static string fileName = "Leaderboard.txt";

    void Start()
    {
        currentScore = new Score();
    }

    public void SetName( string name)
    {
        currentScore.playerName = name;
        saveData();
        Application.LoadLevel(3);
    }

    public void saveData()
    {
        var scores = loadData();

        var file = File.CreateText(fileName);

        foreach (Score score in scores)
        {
            file.WriteLine(score.playerName);
            file.WriteLine("{0}", score.laptopsFixed);
            file.WriteLine("{0}", score.laptopsFailed);
        }

        file.WriteLine(currentScore.playerName);
        file.WriteLine("{0}", currentScore.laptopsFixed);
        file.WriteLine("{0}", currentScore.laptopsFailed);
        file.Close();
        return;
    }

    static public List<Score> loadData()
    {
        var scores = new List<Score>();
        if (File.Exists(fileName))
        {
            var file = File.OpenText(fileName);
            bool finished = false;
            while (!finished)
            {
                Score score = new Score();
                score.playerName = file.ReadLine();
                if (score.playerName == null)
                {
                    finished = true;
                    break;
                }
                int.TryParse(file.ReadLine(), out score.laptopsFixed);
                int.TryParse(file.ReadLine(), out score.laptopsFailed);
                scores.Add(score);
            }
            file.Close();
        }
        return scores;
    }
}
