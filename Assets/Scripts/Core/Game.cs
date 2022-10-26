using System;
using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Manager.Page;
using CP.Scripts.Page.Main;
using UnityEngine;

namespace CP.Scripts.Core
{
    public class Game : MonoBehaviour
    {
        #region SerializeFields

        [Header("Page")] 
        [SerializeField] private MainPage mainPage = null;

        [Header("Rect Transform")] 
        [SerializeField] private RectTransform mainCanvasRectTransform = null;

        #endregion

        #region Fields

        public static Game Instance { get; private set; }
        public PageManager PageManager { get; set; }

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
            CreateMainPage();
        }

        #endregion

        #region CreateMainPage

        private void CreateMainPage()
        {
            GameObject mainPageInstance = mainPage.CreatePage(mainPage.gameObject, mainCanvasRectTransform);
            PageManager.DeclareActivePage(mainPageInstance);
        }

        #endregion
    }
}
