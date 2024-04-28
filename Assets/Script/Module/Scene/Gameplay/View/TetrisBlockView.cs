using System;
using Agate.MVC.Base;
using TetrisLike.Scene.Gameplay;
using UnityEngine;

namespace TetrisLike.Module.Gameplay
{
    public class TetrisBlockView : MonoBehaviour
    {
        public Vector3 rotationPoint;
        private float _previousTime;
        private float _fallTime = 0.5f;

        public static int height = 20;
        public static int width = 10;

        private int _score;
        private bool _isStopLooping;

        private static Transform[,] _grid = new Transform[width, height];

        private GameLauncher _gameLauncher;

        private void Start()
        {
            _gameLauncher = FindObjectOfType<GameLauncher>();
        }

        private void Update()
        {
            if (IsGameOver())
            {
                if (_isStopLooping) return;
                
                _gameLauncher.GameOver();
                _isStopLooping = true;
                return;
            }
        
            if (transform.hierarchyCount == 0) Destroy(this.gameObject);
        
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                transform.position += Vector3.left;
                if (!ValidMove())
                {
                    transform.position -= Vector3.left;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.position += Vector3.right;
                if (!ValidMove())
                {
                    transform.position -= Vector3.right;
                }
            } 
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Rotate
                transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, 90);
                if (!ValidMove())
                {
                    transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, -90);
                }
            }

            if (Time.time - _previousTime > (Input.GetKey(KeyCode.DownArrow) ? _fallTime/10 : _fallTime))
            {
                transform.position += Vector3.down;
                if (!ValidMove())
                {
                    transform.position -= Vector3.down;
                    //Save grid position
                    AddToGrid();

                    //Check Lines
                    CheckLines();
                
                    //Stop movement and spawn new tetromino
                    this.enabled = false;
                    _gameLauncher.SpawnTetromino();
                }
                _previousTime = Time.time;
            }
        }

        private void AddToGrid()
        {
            foreach (Transform child in transform)
            {
                var childPosition = child.position;
                int roundedX = Mathf.RoundToInt(childPosition.x);
                int roundedY = Mathf.RoundToInt(childPosition.y);

                _grid[roundedX, roundedY] = child;
            }
        }

        private void CheckLines()
        {
            for (int i = height - 1; i >= 0; i--)
            {
                if (HasLine(i))
                {
                    DeleteLine(i);
                    RowDown(i);
                }
            }
        }

        private bool HasLine(int i)
        {
            for (int j = 0; j < width; j++)
            {
                if (_grid[j, i] == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void DeleteLine(int i)
        {
            for (int j = 0; j < width; j++)
            {
                Destroy(_grid[j,i].gameObject);
                
                //Addscore
                _score += 1;
                _gameLauncher.IncrementScore();
                
                _grid[j, i] = null;
            }
        }

        private void RowDown(int i)
        {
            for (int y = i; y < height; y++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (_grid[j,y] != null)
                    {
                        _grid[j, y - 1] = _grid[j, y];
                        _grid[j, y] = null;
                        _grid[j, y - 1].transform.position -= Vector3.up;
                    }
                }
            }
        }
    
        private bool IsGameOver()
        {
            for (int i = 0; i < width; i++)
            {
                if (_grid[i, height - 1] != null)
                {
                    return true; // There is a block at the top, game over
                }
            }
            return false;
        }

        private bool ValidMove()
        {
            foreach (Transform child in transform)
            {
                var childPosition = child.position;
                int roundedX = Mathf.RoundToInt(childPosition.x);
                int roundedY = Mathf.RoundToInt(childPosition.y);

                if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
                {
                    return false;
                }

                if (_grid[roundedX, roundedY] != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
