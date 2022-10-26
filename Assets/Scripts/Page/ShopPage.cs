using CP.Scripts.Core;
using CP.Scripts.Data;
using CP.Scripts.Interface.Page;
using CP.Scripts.Manager.Pool;
using UnityEngine;

namespace CP.Scripts.Page.Shop
{
    public class ShopPage : MonoBehaviour, IPage
    {
        #region SerializeFields
        
        [Header("Rect Transform")] 
        [SerializeField] private RectTransform orangeButtonAreaRectTransform = null;
        [SerializeField] private RectTransform yellowButtonAreaRectTransform = null;

        #endregion

        #region Fields

        private PoolManager _poolManager;
        private GameObject _btnOrange;
        private GameObject _btnYellow;

        #endregion

        #region Awake | Start | Update

        private void Start()
        {
            LoadButtons();
            
            _poolManager = Game.Instance.PoolManager;

            PoolButtons();
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

        #region LoadButtons

        private void LoadButtons()
        {
            _btnOrange = Resources.Load<GameObject>(Paths.OrangeButtonPath);
            _btnYellow = Resources.Load<GameObject>(Paths.YellowButtonPath);
        }

        #endregion

        #region PoolButtons

        private void PoolButtons()
        {
            _poolManager.Pool(_btnOrange, orangeButtonAreaRectTransform, 6);
            _poolManager.Pool(_btnYellow, yellowButtonAreaRectTransform, 9);
        }

        #endregion
    }
}

