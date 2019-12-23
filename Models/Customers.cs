using System.ComponentModel.DataAnnotations.Schema; 

namespace Advantage.API.Models
{
    public class Customer
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}
        public string Name { get; set;}
        public string Email{ get; set;}
        public string State { get; set;}       
    }

}