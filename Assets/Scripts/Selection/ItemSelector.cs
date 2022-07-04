using Quinbay.Catalog;
using UnityEngine;
using UnityEngine.Events;

namespace Quinbay.Selection
{
    public abstract class ItemSelector : MonoBehaviour
    {
        public abstract CatalogItem SelectedItem { get; protected set; }

        public abstract UnityAction<CatalogItem> OnSelectionChanged { get; set; }
    }
}