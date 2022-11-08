using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CP.Scripts.Gameplay.Cook
{
    public class Recipe : MonoBehaviour
    {
        #region SerializeFields

        [SerializeField] private Image imgFirstIngredient = null;
        [SerializeField] private Image imgSecondIngredient = null;
        [SerializeField] private Image imgThirdIngredient = null;

        #endregion

        #region Fields

        private List<Sprite> _ingredients = new List<Sprite>();

        #endregion

        #region Awake | Start | Update



        #endregion

        #region Set: Ingredients

        public void SetIngredients(Sprite firstIngredient, Sprite secondIngredient, Sprite thirdIngredient)
        {
            imgFirstIngredient.sprite = firstIngredient;
            imgSecondIngredient.sprite = secondIngredient;
            imgThirdIngredient.sprite = thirdIngredient;
        }

        #endregion

        #region Add: Ingredient

        public void AddIngredient(Sprite ingredient)
        {
            _ingredients.Add(ingredient);
        }

        #endregion

        #region Get: IngredientsCount

        public List<Sprite> GetIngredients()
        {
            return _ingredients;
        }

        #endregion
    }
}
