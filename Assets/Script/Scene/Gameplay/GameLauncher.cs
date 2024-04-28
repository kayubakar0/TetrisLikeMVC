using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TetrisLike.Boot;
using TetrisLike.Module.Gameplay;
using TetrisLike.Utility;

namespace TetrisLike.Scene.Gameplay
{
    public class GameLauncher : SceneLauncher<GameLauncher, GameView>
    {
        // Use the same name with the scene that we add in build setting
        public override string SceneName => EnvScene.GamePlay;

        private GameplayController _gameplay;
        
        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {

            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new GameplayController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _gameplay.SetView(_view.GameplayView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        public void SpawnTetromino()
        {
            _gameplay.SpawnTetromino();
        }

        public void IncrementScore()
        {
            _gameplay.IncrementScore();
        }

        public void GameOver()
        {
            _gameplay.GameOver();
        }
    }
}
