using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace TetrisLike.Module.Menu
{
    public class MenuView : BaseView
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;
        
        public void Initialize(UnityAction onPlay, UnityAction onExit)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(onPlay);
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(onExit);
        }
    }
}
