using System;
using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Core;
using CP.Scripts.Interface.Page;
using CP.Scripts.Manager.Pool;
using UnityEngine;

namespace CP.Scripts.Page.Game
{
    public class GamePage : MonoBehaviour, IPage
    {

        #region SerializeFields

        [SerializeField] private RectTransform dropContainer = null;

        [SerializeField] private GameObject dropZone = null;

        #endregion

        #region Fields

        private PoolManager _poolManager;

        #endregion
        
        #region Awake | Start | Update

        private void Awake()
        {
            _poolManager = Core.Game.Instance.PoolManager;
            
            _poolManager.Pool(dropZone, dropContainer, 3);
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
    }
    
}
