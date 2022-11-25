using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerMDBlayer.Model
{
    public class YouTubeViewerEF
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set;  }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }
        [Required]
        public bool IsSubscribed { get; set; }
        [Required]
        public bool IsMember { get; set; }

        public YouTubeViewerEF(Guid id, string username, bool isSubscribed, bool isMember)
        {
            Id = id;
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }

        public YouTubeViewerEF()
        {

        }
   
        public override string ToString()
        {
            return $"Id: {Id}, Username: {Username}, IsSubscribed: {IsSubscribed}, IsMember: {IsMember}";
        }
    }
}
