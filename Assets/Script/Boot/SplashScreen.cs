using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;

namespace TetrisLike.Boot
{
    public class SplashScreen : BaseSplash<SplashScreen>
    {
        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }
    }
}
