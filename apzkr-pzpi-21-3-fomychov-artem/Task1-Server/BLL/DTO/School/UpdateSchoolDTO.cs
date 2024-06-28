namespace BLL.DTO
{
    public class UpdateSchoolDTO
    {
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