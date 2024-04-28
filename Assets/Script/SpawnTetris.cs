using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetris : MonoBehaviour
{
    [SerializeField] private GameObject[] tetrominoVariant;
    
    void Start()
    {
        NewTetromino();
    }

    public void NewTetromino()
    {
        Instantiate(tetrominoVariant[Random.Range(0, tetrominoVariant.Length)], transform.position,
            Quaternion.identity);
    }
}
