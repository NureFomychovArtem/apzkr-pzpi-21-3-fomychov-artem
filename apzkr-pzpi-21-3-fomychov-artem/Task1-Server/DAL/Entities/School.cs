namespace DAL.Entities
{
    public class School
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Повна назва закладу
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адреса школи
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Область
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }
    }
}