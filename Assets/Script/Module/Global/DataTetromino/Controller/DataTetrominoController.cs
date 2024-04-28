using System.Collections;
using UnityEngine;
using Agate.MVC.Base;

namespace TetrisLike.Module.DataTetromino
{
    public class DataTetrominoController : DataController<DataTetrominoController, DataTetrominoModel, IDataTetrominoModel>
    {
        public override IEnumerator Initialize()
        {
            SetTetrominoData();
            yield return base.Initialize();
            
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        private void SetTetrominoData()
        {
            Debug.Log(_model);
            _model.SetTetrominoVariant();
        }
    }
}
