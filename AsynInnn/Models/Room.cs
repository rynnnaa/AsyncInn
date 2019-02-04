using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide Id")]
        public string Name { get; set; }
        public Layout RoomLayout { get; set; }

        //Navigation Properties 

        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        [Display(Name="Studio")]
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
