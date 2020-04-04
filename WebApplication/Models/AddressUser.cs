using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication.Models
{
    [Table("address_user", Schema = "public")]
    public class AddressUser
    {
        [Key, Column(Order = 1)]
        public int address_user_id { get; set; }
        
        public int address_id { get; set; }
      
        public int user_id { get; set; }
        
        [ForeignKey("address_id"),Column(Order = 2)]
        public Address Address { get; set; }
        [ForeignKey("user_id"),Column(Order = 3)]
        public User User { get; set; }
    }
}