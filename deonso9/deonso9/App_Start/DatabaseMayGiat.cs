using deonso9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace deonso9.App_Start
{
    public class DatabaseMayGiat : DropCreateDatabaseAlways<MayGiatDataContext>
    {
        protected override void Seed(MayGiatDataContext context)
        {
            context.MayGiats.Add(
                new MayGiat
                {
                    MaSP = 001,
                    HangSX = "Panasonic",
                    ngaySX = new DateTime(2023, 4, 17),
                    KhoiLuongGiat = 15,
                    DonGia = 25000000,
                    SoLuong = 37,
                    
                });
            context.MayGiats.Add(
                new MayGiat
                {
                    MaSP = 002,
                    HangSX = "LG",
                    ngaySX = new DateTime(2023, 6, 24),
                    KhoiLuongGiat = 12,
                    DonGia = 10000000,
                    SoLuong = 25
                });
            context.MayGiats.Add(
                new MayGiat
                {
                    MaSP = 003,
                    HangSX = "SamSung",
                    ngaySX = new DateTime(2024, 6, 28),
                    KhoiLuongGiat = 15,
                    DonGia = 35000000,
                    SoLuong = 68
                });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}