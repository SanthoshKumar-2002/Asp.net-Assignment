using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities.Models
{
    public class FileModel
    {
        public Guid id { get; set; }
        
        public byte[] FormFile { get; set; } 
            }
}
