using Agate.MVC.Base;
using UnityEngine;

namespace TetrisLike.Module.Gameplay
{
    public interface IGameplayModel : IBaseModel
    {
        int Score { get; }
        int HighScore { get; }
    }
}
