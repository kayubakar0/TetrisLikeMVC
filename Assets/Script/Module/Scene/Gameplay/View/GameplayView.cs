using UnityEngine;
using Agate.MVC.Base;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TetrisLike.Module.Gameplay
{
    public class GameplayView : ObjectView<IGameplayModel>
    {
        [Header("Text Component")]
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highScoreText;
        [SerializeField] private TMP_Text scoreTextPauseMenu;

        [Header("Button Component")]
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button playAgainButton;
        [SerializeField] private Button homeButton;
        
        //Panel Canvas
        [Header("Panel Component")]
        [SerializeField] private GameObject pausePanel;

        [Header("Tetromino Component")]
        [SerializeField] private GameObject spawnerObject;

        private int saveScore;
        
        public void Initialize(UnityAction pause, UnityAction home)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(pause);
            
            playAgainButton.onClick.RemoveAllListeners();
            playAgainButton.onClick.AddListener(pause);
            
            homeButton.onClick.RemoveAllListeners();
            homeButton.onClick.AddListener(home);

            // //Spawn Tetromino
            // SpawnTetromino(variants);
        }

        protected override void InitRenderModel(IGameplayModel model)
        {
            saveScore = model.Score;
            scoreText.text = $"Score : {saveScore.ToString()}";
            highScoreText.text = $"High Score : {model.HighScore.ToString()}";
        }

        protected override void UpdateRenderModel(IGameplayModel model)
        {
            saveScore = model.Score;
            scoreText.text = $"Score : {saveScore.ToString()}";
            highScoreText.text = $"High Score : {model.HighScore.ToString()}";
        }

        public void ActivatePausePanel(bool isActive)
        {
            pausePanel.SetActive(isActive);
            
            if (isActive) scoreTextPauseMenu.text = saveScore.ToString();
            
        }

        public void ActivateGameOverPanel(bool isOver)
        {
            ActivatePausePanel(isOver);
            playAgainButton.gameObject.SetActive(!isOver);
        }
        
        //Start show Tetromino
        public void SpawnTetromino(GameObject[] variant)
        {
            Instantiate(variant[Random.Range(0, variant.Length)], spawnerObject.transform.position,
            Quaternion.identity, spawnerObject.transform);
        }
    }
}
