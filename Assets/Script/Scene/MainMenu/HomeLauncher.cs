using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TetrisLike.Boot;
using TetrisLike.Module.Menu;
using TetrisLike.Utility;

namespace TetrisLike.MainMenu
{
    public class HomeLauncher : SceneLauncher<HomeLauncher, HomeView>
    {
        // Use the same name with the scene that we add in build setting
        public override string SceneName => EnvScene.MainMenu;

        private MenuController _menu;
        
        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new MenuController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _menu.SetView(_view.MenuView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
