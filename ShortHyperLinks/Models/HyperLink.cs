using ShortHyperLinks.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ShortHyperLinks.Models
{
    public class HyperLink : ILinkModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^(http|https)://\S+$", ErrorMessage = "Введенная ссылка не соответствует требуемым стандартам!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле с изначальной ссылкой не может быть пустым!")]
        public string Link { get; set; }
        public string ShortLink { get; set; }
        public int Clicks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
