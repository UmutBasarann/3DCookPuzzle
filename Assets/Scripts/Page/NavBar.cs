using System;
using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Core;
using CP.Scripts.Manager.Page;
using CP.Scripts.Page.Main;
using CP.Scripts.Page.Settings;
using CP.Scripts.Page.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace CP.Scripts.Page.NavBar
{
    public class NavBar : MonoBehaviour
    {
        #region SerializeField

        #region Canvas

        [Header("Main Canvas")]
        
        [SerializeField] private RectTransform mainCanvasRectTransform = null;

        #endregion

        #region Pages

        [Header("Pages")]
        
        [SerializeField] private MainPage mainPage = null;
        [SerializeField] private ShopPage shopPage = null;
        [SerializeField] private SettingsPage settingsPage = null;

        #endregion

        #region Buttons

        [Header("Buttons")] 
        
        [SerializeField] private Button btnMainPage = null;
        [SerializeField] private Button btnShopPage = null;
        [SerializeField] private Button btnSettingsPage = null;

        #endregion

        #endregion

        #region Fields

        private PageManager _pageManager;
        
        #endregion

        #region Awake | Start | Update

        private void Start()
        {
            _pageManager = Game.Instance.PageManager;
        }

        #endregion

        #region OnEnable | OnDisable

        private void OnEnable()
        {
            AddEvents();
        }

        private void OnDisable()
        {
            RemoveEvents();
        }

        #endregion

        #region Event: OnMainPageButtonClicked

        private void OnMainPageButtonClicked()
        {
            if (_pageManager.ActivePage != null && _pageManager.ActivePage.activeInHierarchy)
            {
                Destroy(_pageManager.ActivePage);
            }
            
            GameObject mainPageInstance = mainPage.CreatePage(mainPage.gameObject, mainCanvasRectTransform);
            _pageManager.DeclareActivePage(mainPageInstance);
        }

        #endregion
        
        #region Event: OnShopPageButtonClicked

        private void OnShopPageButtonClicked()
        {
            if (_pageManager.ActivePage != null && _pageManager.ActivePage.activeInHierarchy)
            {
                Destroy(_pageManager.ActivePage);
            }
            
            GameObject shopPageInstance = shopPage.CreatePage(shopPage.gameObject, mainCanvasRectTransform);
            _pageManager.DeclareActivePage(shopPageInstance);
        }

        #endregion
        
        #region Event: OnSettingsPageButtonClicked

        private void OnSettingsPageButtonClicked()
        {
            if (_pageManager.ActivePage != null && _pageManager.ActivePage.activeInHierarchy)
            {
                Destroy(_pageManager.ActivePage);
            }
            
            GameObject settingsPageInstance = settingsPage.CreatePage(settingsPage.gameObject, mainCanvasRectTransform);
            _pageManager.DeclareActivePage(settingsPageInstance);
        }

        #endregion

        #region AddEvents

        private void AddEvents()
        {
            btnMainPage.onClick.AddListener(OnMainPageButtonClicked);
            btnShopPage.onClick.AddListener(OnShopPageButtonClicked);
            btnSettingsPage.onClick.AddListener(OnSettingsPageButtonClicked);
        }

        #endregion

        #region Remove Events

        private void RemoveEvents()
        {
            btnMainPage.onClick.RemoveAllListeners();
            btnShopPage.onClick.RemoveAllListeners();
            btnSettingsPage.onClick.RemoveAllListeners();
        }

        #endregion


    }
}

