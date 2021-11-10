namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseTicketCreationModel
    {
        public MerchandiseTicketCreationModel(long employeeId, long sku)
        {
            EmployeeId = employeeId;
            Sku = sku;
        }

        /// <summary>
        /// Id сотрудника, которому выдается мерч
        /// </summary>
        public long EmployeeId { get; }
        
        /// <summary>
        /// Товарная позиция, которая выдается в качестве мерча
        /// </summary>
        public long Sku { get; }
    }
}