using System.Collections.Generic;
using Quinbay.Catalog;
using UnityEngine;

namespace Quinbay.UI
{
    public class CartCanvas : MonoBehaviour
    {
        [SerializeField] private Transform cartItemsParent;
        [SerializeField] private GameObject cartItemPrefab;

        private List<CatalogItem> cartItems = new List<CatalogItem>();

        private void Awake()
        {
            foreach (Transform child in cartItemsParent)
            {
                Destroy(child.gameObject);
            }
        }

        public void AddItemToCart(CatalogItem item)
        {
            if (cartItems.Contains(item)) return;
            cartItems.Add(item);

            CartItem newCartItem = Instantiate(cartItemPrefab, cartItemsParent).GetComponent<CartItem>();
            newCartItem.SetItem(this, item);
        }

        public void RemoveItemFromCart(CatalogItem toRemove)
        {
            cartItems.Remove(toRemove);
        }
    }
}
