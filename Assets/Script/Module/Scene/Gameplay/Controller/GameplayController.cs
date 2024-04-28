using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using TetrisLike.Boot;
using TetrisLike.Module.DataTetromino;
using TetrisLike.Utility;

namespace TetrisLike.Module.Gameplay
{
    public class GameplayController : ObjectController<GameplayController, GamePlayModel, IGameplayModel, GameplayView>
    {
        private bool _isPaused;
        private DataTetrominoController _dataTetromino;
        
        public override IEnumerator Initialize()
        {
            _model.GetHighScore();
            yield return base.Initialize();
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override void SetView(GameplayView view)
        {
            base.SetView(view);
            //Get high score from model
            
            view.Initialize(Pause, Home);
            SpawnTetromino();
        }

        public void SpawnTetromino()
        {
            _view.SpawnTetromino(_dataTetromino.Model.TetrominoVariant);
        }

        private void Pause()
        {
            if (_isPaused)
            {
                ResumeGame();
                Debug.Log("RESUME");
            }
            else
            {
                PauseGame();
                Debug.Log("PAUSE");
            }

        }
        
        private void PauseGame()
        {
            Time.timeScale = 0f;
            _isPaused = true;
            _view.ActivatePausePanel(true);
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
            _isPaused = false;
            _view.ActivatePausePanel(false);
        }
        
        private void Home()
        {
            SceneLoader.Instance.LoadScene(EnvScene.MainMenu);
        }

        public void IncrementScore()
        {
            _model.AddScore(1);
            if (_model.Score >= _model.HighScore)
            {
                _model.SetHighScore(_model.Score);
            }
        }

        public void GameOver()
        {
            _view.ActivateGameOverPanel(true);
        }
    }
}
