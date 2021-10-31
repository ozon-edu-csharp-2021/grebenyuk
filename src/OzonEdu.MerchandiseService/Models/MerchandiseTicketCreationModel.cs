namespace OzonEdu.MerchandiseService.Models
{
    public class MerchandiseTicketCreationModel
    {
        public MerchandiseTicketCreationModel(long employeeId, int itemId)
        {
            EmployeeId = employeeId;
            ItemId = itemId;
        }

        /// <summary>
        /// Id сотрудника, которому выдается мерч
        /// </summary>
        public long EmployeeId { get; }
        
        /// <summary>
        /// Id предмета, который выдается в качестве мерча
        /// </summary>
        public int ItemId { get; }
    }
}