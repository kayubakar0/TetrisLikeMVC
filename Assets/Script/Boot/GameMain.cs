using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TetrisLike.Module.DataTetromino;

namespace TetrisLike.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return null;
        }

        protected override IController[] GetDependencies()
        {
            return new IController[]
            {
                new DataTetrominoController()
            };
        }

        protected override IEnumerator StartInit()
        {
            yield return null;
        }
    }
}
