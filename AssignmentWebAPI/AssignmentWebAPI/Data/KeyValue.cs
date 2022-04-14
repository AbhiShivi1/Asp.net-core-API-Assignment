using System.ComponentModel.DataAnnotations;
namespace AssignmentWebAPI.Data
{
    public class KeyValue
    {   [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
