using Quinbay.Catalog;
using Quinbay.Selection;
using TMPro;
using UnityEngine;

namespace Quinbay.UI
{
    public class DetailsCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject productInfoCanvas;
        [SerializeField] private GameObject placeholderCanvas;
        
        [SerializeField] private ItemSelector itemSelector;
        [SerializeField] private CartCanvas cartCanvas;
   
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text categoryText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text pricePerUnitText;

        private CatalogItem selectedItem = null;

        private void Awake()
        {
            selectedItem = null;
            placeholderCanvas.SetActive(true);
            productInfoCanvas.SetActive(false);
        }

        private void OnEnable()
        {
            itemSelector.OnSelectionChanged += OnProductSelected;
        }

        private void OnDisable()
        {
            itemSelector.OnSelectionChanged -= OnProductSelected;
        }

        private void OnProductSelected(CatalogItem newItem)
        {
            placeholderCanvas.SetActive(false);
            productInfoCanvas.SetActive(true);

            titleText.text = newItem.Name;
            categoryText.text = newItem.Category.ToString();
            descriptionText.text = newItem.Description;
            pricePerUnitText.text = $"Price: INR {newItem.PricePerUnit.ToString()} per Unit";

            selectedItem = newItem;
        }

        public void AddItemToCart()
        {
            if (selectedItem == null) return;
            
            cartCanvas.AddItemToCart(selectedItem);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(Debug_AddItemToCart))]
        private void Debug_AddItemToCart()
        {
            AddItemToCart();
        }
#endif
    }
}
