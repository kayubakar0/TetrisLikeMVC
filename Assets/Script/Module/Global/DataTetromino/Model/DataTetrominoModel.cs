using Agate.MVC.Base;
using UnityEngine;

namespace TetrisLike.Module.DataTetromino
{
    public class DataTetrominoModel : BaseModel, IDataTetrominoModel
    {
        public GameObject[] TetrominoVariant { get; private set; }

        public void SetTetrominoVariant()
        {
            TetrominoVariant = Resources.LoadAll<GameObject>("Prefabs/Tetromino");
            Debug.Log("Add Data");
        }
    }
}
