using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CP.Scripts.Core;
using CP.Scripts.Gameplay;
using CP.Scripts.Gameplay.Cook;
using CP.Scripts.Gameplay.DragDrop;
using CP.Scripts.Interface.Page;
using CP.Scripts.Manager.Pool;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CP.Scripts.Page.Game
{
    public class GamePage : MonoBehaviour, IPage
    {
        #region Event | Action

        public static event Action OnGameWon;
        public static event Action OnGameLost;

        #endregion
        
        #region SerializeFields

        [SerializeField] private Recipe recipe = null;
        [SerializeField] private RectTransform vegetableContainer = null;
        [SerializeField] private Image vegetable = null;

        #endregion

        #region Fields

        private PoolManager _poolManager;

        private List<GameObject> _pooledObjects = new List<GameObject>();
        private List<GameObject> _selectedIngredients = new List<GameObject>();
        private Sprite[] _vegSprites;

        private Sprite _firstIngredient;
        private Sprite _secondIngredient;
        private Sprite _thirdIngredient;

        #endregion
        
        #region Awake | Start | Update

        private void Awake()
        {
            _poolManager = Core.Game.Instance.PoolManager;

            LoadImages();
        }

        private void Start()
        {
            SetIngredients();
            PoolVegetables();

            Droppable.OnIngredientDropped += OnIngredientDropped;
        }
        
        #endregion
        
        #region CreatePage

        public GameObject CreatePage(GameObject page, Transform parent)
        {
            if (parent is null)
            {
                Debug.LogError("Please use 'Simulator' to get the best experience.");
            }
            
            GameObject instance = Instantiate(page, parent);
            instance.transform.SetAsLastSibling();
            return instance;
        }

        #endregion

        #region LoadImages

        private void LoadImages()
        {
            _vegSprites = Resources.LoadAll<Sprite>("Sprites/Vegetables");
        }

        #endregion

        #region PoolVegetables

        private void PoolVegetables()
        {
            _poolManager.Pool(vegetable.gameObject, vegetableContainer, Random.Range(50, 70), out _pooledObjects);

            _pooledObjects[0].GetComponent<Image>().sprite = _firstIngredient;
            _pooledObjects[1].GetComponent<Image>().sprite = _secondIngredient;
            _pooledObjects[2].GetComponent<Image>().sprite = _thirdIngredient;

            for (var i = 4; i < _pooledObjects.Count; i++)
            {
                var pooledObject = _pooledObjects[i];
                Image vegImage = pooledObject.GetComponent<Image>();
                vegImage.sprite = _vegSprites[Random.Range(0, 25)];

                pooledObject.transform.localPosition = new Vector3(Random.Range(-350, 350), Random.Range(-450, 450));
            }
        }

        #endregion

        #region Set: Ingredients

        private void SetIngredients()
        {
            _firstIngredient = _vegSprites[Random.Range(0, 25)];
            _secondIngredient = _vegSprites[Random.Range(0, 25)];
            _thirdIngredient = _vegSprites[Random.Range(0, 25)];
            
            recipe.SetIngredients(_firstIngredient, _secondIngredient, _thirdIngredient);
            recipe.AddIngredient(_firstIngredient);
            recipe.AddIngredient(_secondIngredient);
            recipe.AddIngredient(_thirdIngredient);
        }

        #endregion
        
        #region Event: OnIngredientDropped

        private void OnIngredientDropped(GameObject selectedIngredient)
        {
           _selectedIngredients.Add(selectedIngredient);
           
           Debug.Log($"Selected Ingredient Count: {_selectedIngredients.Count}");

           List<Sprite> currentIngredients = recipe.GetIngredients();

           if (_selectedIngredients.Count != currentIngredients.Count)
           {
               return;
           }

           for (var i = 0; i < _selectedIngredients.Count; i++)
           {
               Sprite selectedIngredientSprite = _selectedIngredients[i].GetComponent<Image>().sprite;
               
               if (currentIngredients[i] != selectedIngredientSprite)
               {
                   Debug.Log("You lost :(");

                   if (OnGameLost != null)
                   {
                       OnGameLost();
                       Droppable.OnIngredientDropped -= OnIngredientDropped;
                   }
                   
                   return;
               }
               
               if (currentIngredients[i] == selectedIngredientSprite)
               {
                   Debug.Log("You won :)");

                   if (OnGameWon != null)
                   {
                       OnGameWon();
                       Droppable.OnIngredientDropped -= OnIngredientDropped;
                   }
                   
                   return;
               }
           }
        }

        #endregion
    }
    
}
