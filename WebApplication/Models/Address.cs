using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace WebApplication.Models
{
    [Table("address", Schema = "public")]
    public class Address
    {
        private int Address_id;

        [Key]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int address_id
        {
            get { return Address_id; }
            set { Address_id = value; }
        }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, MinimumLength = 3)]
        public string surname { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(40, MinimumLength = 3)]
        public string address { get; set; }
        [Required]
        public int building { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int flat { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int rent { get; set; }

        public Address()
        {
            try
            {
                address_id = 0;
                surname = "";
                address = "";
                building = 0;
                flat = 0;
                rent = 0;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }
        public virtual ICollection<AddressUser> AddressUsers { get; set; }
        public Address(int addressId, string surname, string nameOfAddress, int numberOfBuilding, int numberOfFlat,
            int rent)
        {
            this.address_id = addressId;
            this.surname = surname;
            this.address = nameOfAddress;
            this.building = numberOfBuilding;
            flat = numberOfFlat;
            this.rent = rent;
        }

        public override string ToString()
        {
            PropertyInfo[] properties = GetType().GetProperties();
            StringBuilder str = new StringBuilder("");

            foreach (PropertyInfo f in properties)
            {
                str.Append(f.Name + " = " + f.GetValue(this) + ", ");
            }

            return Convert.ToString(str);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}