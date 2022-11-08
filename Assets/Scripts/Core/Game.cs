using CP.Scripts.Manager.Page;
using CP.Scripts.Manager.Pool;
using CP.Scripts.Page;
using CP.Scripts.Page.Game;
using CP.Scripts.Page.Main;
using UnityEngine;

namespace CP.Scripts.Core
{
    public class Game : MonoBehaviour
    {
        #region SerializeFields

        [Header("Pool Manager")]
        [SerializeField] private PoolManager poolManager = null;
        public PoolManager PoolManager => poolManager;

        [Header("Page")]
        [SerializeField] private SelectionPage selectionPage = null;

        [SerializeField] private GamePage gamePage = null;

        [SerializeField] private GameWonPage gameWonPage = null;
        [SerializeField] private GameLostPage gameLostPage = null;

        [Header("Main Canvas")]
        [SerializeField] private Canvas mainCanvas = null;
        
        [Header("Rect Transform")] 
        [SerializeField] private RectTransform safeAreaRectTransform = null;

        #endregion

        #region Fields

        internal static Game Instance { get; private set; }
        public PageManager PageManager { get; private set; }

        private GameObject _selectionPageInstance;
        private GameObject _gamePageInstance;
        private GameObject _gameWonPageInstance;
        private GameObject _gameLostPageInstance;

        #endregion

        #region Awake | Start | Update

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
            }
            else
            {
                Destroy(Instance);
            }
            
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            PageManager = new PageManager();
            CreateSelectionPage();
            
            SelectionPage.OnPlayButtonClicked += OnPlayButtonClicked;
            GamePage.OnGameWon += OnGameWon;
            GamePage.OnGameLost += OnGameLost;
        }
        
        #endregion

        #region Get: ScaleFactor

        public float GetScaleFactor()
        {
            return mainCanvas.scaleFactor;
        }

        #endregion
        
        #region StartGame

        private void StartGame()
        {
            Destroy(_selectionPageInstance);

            _gamePageInstance = gamePage.CreatePage(gamePage.gameObject, safeAreaRectTransform);
            PageManager.DeclareActivePage(_gamePageInstance);
            
        }

        #endregion

        #region CreateSelectionPage

        private void CreateSelectionPage()
        {
            _selectionPageInstance = selectionPage.CreatePage(selectionPage.gameObject, safeAreaRectTransform);
            PageManager.DeclareActivePage(_selectionPageInstance);
        }

        #endregion
        
        #region Event: OnPlayButtonClicked

        private void OnPlayButtonClicked()
        {
            StartGame();
            
            SelectionPage.OnPlayButtonClicked -= OnPlayButtonClicked;
        }

        #endregion

        #region Event: OnGameWon

        private void OnGameWon()
        {
            Destroy(_gamePageInstance);

            _gameWonPageInstance = gameWonPage.CreatePage(gameWonPage.gameObject, safeAreaRectTransform);
            PageManager.DeclareActivePage(_gameWonPageInstance);

            GameWonPage.OnGameWonContinueButtonClicked += OnGameWonContinueButtonClicked;
        }

        #endregion
        
        #region Event: OnGameLost

        private void OnGameLost()
        {
            Destroy(_gamePageInstance);

            _gameLostPageInstance = gameLostPage.CreatePage(gameLostPage.gameObject, safeAreaRectTransform);
            PageManager.DeclareActivePage(_gameLostPageInstance);

            GameLostPage.OnGameLostContinueButtonClicked += OnGameLostContinueButtonClicked;
        }

        #endregion
        
        #region Event: OnGameWonContinueButtonClicked

        private void OnGameWonContinueButtonClicked()
        {
            Destroy(_gameWonPageInstance);

            CreateSelectionPage();
            
            SelectionPage.OnPlayButtonClicked += OnPlayButtonClicked;

            GameWonPage.OnGameWonContinueButtonClicked -= OnGameWonContinueButtonClicked;
            GamePage.OnGameWon -= OnGameWon;

        }

        #endregion
        
        #region Event: OnGameLostContinueButtonClicked

        private void OnGameLostContinueButtonClicked()
        {
            Destroy(_gameLostPageInstance);

            CreateSelectionPage();
            
            SelectionPage.OnPlayButtonClicked += OnPlayButtonClicked;

            GameLostPage.OnGameLostContinueButtonClicked -= OnGameLostContinueButtonClicked;
            GamePage.OnGameLost -= OnGameLost;
        }

        #endregion
    }
}

