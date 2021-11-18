using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeMerchAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.ItemAggregate
{
    public class Item : Entity
    {
        public Sku Sku { get; }
        public Name Name { get; private set; }
        public ClothingSize ClothingSize { get; private set; }
        public ItemType ItemType { get; }

        public Item(
            Sku sku,
            Name name,
            ClothingSize clothingSize,
            ItemType itemType)
        {
            Sku = sku;
            ItemType = itemType;
            SetName(name);
            SetClothingSize(clothingSize);
        }

        private void SetName(Name name)
        {
            if (name is null) throw new ArgumentNullException($"{nameof(name)} is null.");

            if (string.IsNullOrEmpty(name.Value) || string.IsNullOrWhiteSpace(name.Value))
            {
                throw new EmptyNameException($"{nameof(name.Value)} is empty.");
            }

            Name = name;
        }

        private void SetClothingSize(ClothingSize clothingSize)
        {
            if (clothingSize is not null
                && (ItemType.Equals(ItemType.TShirt)
                    || ItemType.Equals(ItemType.Sweatshirt)))
            {
                ClothingSize = clothingSize;
                return;
            }

            if (clothingSize is null)
            {
                ClothingSize = null;
                return;
            }

            throw new ClothingSizeException($"Item with type {ItemType.Name} cannot get size.");
        }
    }
}