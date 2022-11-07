using System.Runtime.Serialization;
using System.Xml.Linq;

namespace WebApi.Entities.Models
{
    public partial class FileDTO
    {
        

        [DataMember(Name = "id")]
        public Guid id { get; set; }

       

        [DataMember(Name = "fileName")]
        public string? file_name { get; set; }


        [DataMember(Name = "fileType")]
        public string? file_type { get; set; }


        [DataMember(Name = "size")]
        public int? size { get; set; }


        [DataMember(Name = "fileContent")]
        public string? file_content { get; set; }

    }
}
