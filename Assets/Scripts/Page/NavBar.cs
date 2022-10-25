using System;
using System.Collections;
using System.Collections.Generic;
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
        
        [SerializeField] private GameObject mainPage = null;
        [SerializeField] private GameObject shopPage = null;
        [SerializeField] private GameObject settingsPage = null;

        #endregion

        #region Buttons

        [Header("Buttons")] 
        
        [SerializeField] private Button btnMainPage = null;
        [SerializeField] private Button btnShopPage = null;
        [SerializeField] private Button btnSettingsPage = null;

        #endregion

        #endregion

        #region Fields

        private List<GameObject> _activePages = new List<GameObject>();

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
            // Later Create Page From Its Own Class
            
            foreach (GameObject activePage in _activePages)
            {
                Destroy(activePage);
            }

            GameObject instance = Instantiate(mainPage, mainCanvasRectTransform);
            instance.transform.SetAsLastSibling();
            
            _activePages.Add(instance);
        }

        #endregion
        
        #region Event: OnShopPageButtonClicked

        private void OnShopPageButtonClicked()
        {
            // Later Create Page From Its Own Class

            foreach (GameObject activePage in _activePages)
            {
                Destroy(activePage);
            }

            GameObject instance = Instantiate(shopPage, mainCanvasRectTransform);
            instance.transform.SetAsLastSibling();
            
            _activePages.Add(instance);
        }

        #endregion
        
        #region Event: OnSettingsPageButtonClicked

        private void OnSettingsPageButtonClicked()
        {
            // Later Create Page From Its Own Class

            foreach (GameObject activePage in _activePages)
            {
                Destroy(activePage);
            }
            
            GameObject instance = Instantiate(settingsPage, mainCanvasRectTransform);
            instance.transform.SetAsLastSibling();
            
            _activePages.Add(instance);
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

