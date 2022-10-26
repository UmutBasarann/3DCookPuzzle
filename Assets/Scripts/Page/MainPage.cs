using System;
using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Interface.Page;
using CP.Scripts.Manager.Page;
using UnityEngine;
using UnityEngine.UI;

namespace CP.Scripts.Page.Main
{
    public class MainPage : MonoBehaviour ,IPage
    {
        #region SerializeFields

        [SerializeField] private Button btnPlay = null;
        [SerializeField] private Button btnChest = null;

        #endregion
        
        #region Fields


        #endregion

        #region OnEnable

        private void OnEnable()
        {
            AddEvents();
        }

        #endregion

        #region OnDisable

        private void OnDisable()
        {
            RemoveEvents();
        }

        #endregion

        #region CreatePage
        
        public GameObject CreatePage(GameObject page, Transform parent)
        {
            GameObject instance = Instantiate(page, parent);
            instance.transform.SetAsLastSibling();
            return instance;
        }

        #endregion

        #region AddEvents

        private void AddEvents()
        {
            
        }

        #endregion

        #region RemoveEvents

        private void RemoveEvents()
        {
            
        }

        #endregion

        
    }
}

