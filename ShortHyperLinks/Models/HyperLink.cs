using ShortHyperLinks.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ShortHyperLinks.Models
{
    public class HyperLink : ILinkModel
    {
        private int _id;
        private string _link;
        private string _shortLink;
        private string _hash;
        private int _clicks;
        private DateTime _created;
        private DateTime _updated;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [RegularExpression(@"^(http|https)://\S+$", ErrorMessage = "Введенная ссылка не соответствует требуемым стандартам!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле с изначальной ссылкой не может быть пустым!")]
        public string Link
        {
            get { return _link; }
            set 
            { 
                _link = value;
                Hash = Guid.NewGuid().ToString();
                Updated = DateTime.Now;
            }
        }

        public string ShortLink
        {
            get { return _shortLink; }
            set 
            { 
                _shortLink = value;
                Updated = DateTime.Now;
            }
        }

        public string Hash
        {
            get { return _hash; }
            set
            {
                _hash = value;
                Clicks = 0;
                Updated = DateTime.Now;
            }
        }

        public int Clicks
        {
            get { return _clicks; }
            set 
            { 
                _clicks = value;
                Updated = DateTime.Now;
            }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public DateTime Updated
        {
            get { return _updated; }
            set { _updated = value; }
        }

        public HyperLink()
        {
            Clicks = 0;
            Created = DateTime.Now;
            Updated = DateTime.Now;
            Hash = Guid.NewGuid().ToString();
        }

        public HyperLink(string link)
        {
            Clicks = 0;
            Created = DateTime.Now;
            Updated = DateTime.Now;
            Hash = Guid.NewGuid().ToString();

            Link = link;

        }

        public HyperLink(string link, HostString host)
        {
            Clicks = 0;
            Created = DateTime.Now;
            Updated = DateTime.Now;
            Hash = Guid.NewGuid().ToString();

            Link = link;
            ShortLink = $"{host}/link/{Hash}";

        }
    }
}
