using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TetrisLike.Utility;

namespace TetrisLike.Boot
{
    public class SceneLoader : BaseLoader<SceneLoader>
    {
        protected override string SplashScene => EnvScene.SplashScreen;
    }
}
