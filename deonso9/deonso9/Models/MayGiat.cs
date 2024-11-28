using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace deonso9.Models
{
    public class MayGiat
    {
        [Key]
        [Required(ErrorMessage ="không được để chống trường này ")]
        public int MaSP { get; set; }

        [Required(ErrorMessage = "không được để chống trường này ")]
        [ StringLength(30,MinimumLength =2,ErrorMessage ="độ dài từ 2 => 30 ")]
        public string HangSX { get; set; }

        [Required(ErrorMessage = "không được để chống trường này ")]
        [DataType(DataType.Date)]
        public DateTime ngaySX { get; set; }

        [Required(ErrorMessage = "không được để chống trường này ")]
        public int KhoiLuongGiat { get; set; }

        [Required(ErrorMessage = "không được để chống trường này ")]
        public int DonGia { get; set; }

        [Required(ErrorMessage = "không được để chống trường này ")]
        public int SoLuong {  get; set; }

        [NotMapped]
        public int ThanhTien
        {
            get
            {
                double discount = 0;
                if (HangSX == "Panasonic")
                {
                    discount = 0.10; // 10% discount
                }
                else if (HangSX == "LG")
                {
                    discount = 0.05; // 5% discount
                }
                return (int)(DonGia * SoLuong * (1 - discount));
            }
        }
    }
}