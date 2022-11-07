using System.Runtime.Serialization;
using System.Xml.Linq;

namespace WebApi.Entities.Models
{
    public partial class FileInner
    {
        

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "fileName")]
        public string? FileName { get; set; }
        [DataMember(Name = "fileType")]
        public string? FileType { get; set; }

        [DataMember(Name = "size")]
        public int? Size { get; set; }


        [DataMember(Name = "fileContent")]
        public string? FileContent { get; set; }

    }
}
