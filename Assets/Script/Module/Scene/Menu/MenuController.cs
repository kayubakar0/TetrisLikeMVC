using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TetrisLike.Boot;
using TetrisLike.Utility;
using UnityEngine.SceneManagement;

namespace TetrisLike.Module.Menu
{
    public class MenuController : ObjectController<MenuController, MenuView>
    {
        public override void SetView(MenuView view)
        {
            base.SetView(view);
            view.Initialize(OnPlay, OnExit);
        }

        public void OnPlay()
        {
            SceneLoader.Instance.LoadScene(EnvScene.GamePlay);
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}
