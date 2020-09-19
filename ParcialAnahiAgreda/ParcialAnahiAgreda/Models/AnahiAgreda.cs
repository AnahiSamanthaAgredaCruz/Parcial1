using System.ComponentModel.DataAnnotations;

namespace ParcialAnahiAgreda.Models
{
    public class AnahiAgreda
    {
        [Key]
        public string CodeThreeLetter { get; set; }
        public Region region_lista { get; set; }
        public enum Region
        {
            Africa,
            Oceania,
            Asia,
            Europa,
            Americas
        }

        public string Nombre { get; set; }

        public int Area { get; set; }
        public int CallingCodes { get; set; }
     
    public languages_lista languages_{ get; set; }
    public enum languages_lista
    {
       
        Español,
        Ingles,
        Chino
    }

    public string  flag { get; set; }
}
}