using Quinbay.Catalog;
using TMPro;
using UnityEngine;

namespace Quinbay.UI
{
    public class CartItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        
        private CatalogItem item;
        private CartCanvas cart;

        public void SetItem(CartCanvas cart, CatalogItem toSet)
        {
            this.item = toSet;
            this.cart = cart;
            nameText.text = item.Name;
        }

        public void RemoveItem()
        {
            this.cart.RemoveItemFromCart(item);
            Destroy(this.gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(Debug_RemoveItemFromCart))]
        private void Debug_RemoveItemFromCart()
        {
            RemoveItem();
        }
#endif
    }
}
