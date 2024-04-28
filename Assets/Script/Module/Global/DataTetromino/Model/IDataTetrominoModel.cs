using Agate.MVC.Base;
using UnityEngine;

namespace TetrisLike.Module.DataTetromino
{
    public interface IDataTetrominoModel : IBaseModel
    {
        GameObject[] TetrominoVariant { get; }
    }
}
