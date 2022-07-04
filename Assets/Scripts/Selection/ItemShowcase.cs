using Quinbay.Catalog;
using UnityEngine;

namespace Quinbay.Selection
{
    public class ItemShowcase : MonoBehaviour
    {
        [SerializeField] private ItemSelector itemSelector;

        private GameObject currentItemOnDisplay = null;

        private void OnEnable()
        {
            itemSelector.OnSelectionChanged += DisplayItem;
        }

        private void OnDisable()
        {
            itemSelector.OnSelectionChanged -= DisplayItem;
        }

        private void DisplayItem(CatalogItem item)
        {
            if (currentItemOnDisplay != null)
            {
                GameObject toDelete = currentItemOnDisplay;
                currentItemOnDisplay = null;
                Destroy(toDelete);
            }

            currentItemOnDisplay = Instantiate(item.Prefab, transform.position, transform.rotation, transform);
        }
    }
}
