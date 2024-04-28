using UnityEngine;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace TetrisLike.Module.Gameplay
{
    public class GamePlayModel : BaseModel ,IGameplayModel
    {
        public int Score { get; protected set; }
        
        public int HighScore { get; protected set; }

        public void AddScore(int score)
        {
            Score += score;
            SetDataAsDirty();
        }

        public int GetHighScore()
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
            return HighScore;
        }

        public void SetHighScore(int score)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", score);
            SetDataAsDirty();
        }

        public void ResetScore()
        {
            Score = 0;
            SetDataAsDirty();
        }
    }
}
