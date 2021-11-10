namespace OzonEdu.MerchandiseService.HttpModels
{
    public class Item
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public int ClothingSizeId { get; set; }
        public int ItemTypeId { get; set; }
    }
}