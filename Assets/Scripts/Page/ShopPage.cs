using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Interface.Page;
using CP.Scripts.Manager.Page;
using UnityEngine;
using UnityEngine.UI;

namespace CP.Scripts.Page.Shop
{
    public class ShopPage : MonoBehaviour, IPage
    {
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

