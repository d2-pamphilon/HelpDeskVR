﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Score
{
    public int laptopsFixed;
    public int laptopsFailed;
    public string playerName;
}

public class ScoreTracker {

    public Score currentScore;

    public List<Score> scores; 

    string fileName = "Leaderboard.txt";

    public void saveData()
    {
        var file = File.CreateText(fileName);
        file.WriteLine(currentScore.playerName);
        file.WriteLine("{0}", currentScore.laptopsFixed);
        file.WriteLine("{0}", currentScore.laptopsFailed);
        file.Close();
        return;
    }

    public void loadData()
    {
        scores = new List<Score>();
        if (File.Exists(fileName))
        {
            var file = File.OpenText(fileName);
            bool finished = false;
            while (!finished)
            {
                Score score = new Score();
                score.playerName = file.ReadLine();
                if (score.playerName == "")
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
        return;
    }
}
