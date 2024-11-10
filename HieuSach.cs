using System;
using System.Collections.Generic;

namespace HieuSach
{
    public class Sach
    {
        public string TieuDe { get; private set; }
        public string TacGia { get; private set; }
        public string TheLoai { get; private set; }
        public string NgayXuatBan { get; private set; }

        public Sach(string tieuDe, string tacGia, string theLoai, string ngayXuatBan)
        {
            TieuDe = tieuDe;
            TacGia = tacGia;
            TheLoai = theLoai;
            NgayXuatBan = ngayXuatBan;
        }
    }

    public class HieuSach
    {
        private List<Sach> sachList = new List<Sach>();

        public void Hello()
        {
            Console.WriteLine("Xin Chao Ban!");
        }

        public bool IsAdmin(string tenDangNhap)
        {
            if (tenDangNhap != "admin") return false;
            Console.Write("Nhap mat khau: ");
            string matKhau = Console.ReadLine();
            if (matKhau != "admin")
            {
                Console.WriteLine("Sai Mat Khau Cua Admin");
                return false;
            }
            return true;
        }

        public int TimTTSach(string tenSach)
        {
            for (int i = 0; i < sachList.Count; i++)
            {
                if (sachList[i].TieuDe == tenSach)
                {
                    return i;
                }
            }
            return -1;
        }

        public void XuLiYCAdmin(char luaChon)
        {
            switch (luaChon)
            {
                case '1':
                    Console.Write("Nhap Tieu De: ");
                    string tieuDe = Console.ReadLine();
                    Console.Write("Nhap Tac Gia: ");
                    string tacGia = Console.ReadLine();
                    Console.Write("Nhap The Loai: ");
                    string theLoai = Console.ReadLine();
                    Console.Write("Nhap Ngay Xuat Ban: ");
                    string ngayXuatBan = Console.ReadLine();

                    Sach sachMoi = new Sach(tieuDe, tacGia, theLoai, ngayXuatBan);
                    sachList.Add(sachMoi);
                    Console.WriteLine("Da Them Sach Thanh Cong");
                    break;

                case '2':
                    Console.Write("Nhap Ten Sach Muon Xoa: ");
                    string tenSachXoa = Console.ReadLine();
                    int indexXoa = TimTTSach(tenSachXoa);
                    if (indexXoa != -1)
                    {
                        sachList.RemoveAt(indexXoa);
                        Console.WriteLine("Xoa Sach Thanh Cong");
                    }
                    else
                    {
                        Console.WriteLine("Khong Tim Thay Sach Can Xoa");
                    }
                    break;

                case '3':
                    Console.Write("Nhap Ten Sach Muon Sua: ");
                    string tenSachSua = Console.ReadLine();
                    int indexSua = TimTTSach(tenSachSua);
                    if (indexSua != -1)
                    {
                        Console.Write("Nhap Tieu De Moi: ");
                        string tieuDeSua = Console.ReadLine();
                        Console.Write("Nhap Tac Gia Moi: ");
                        string tacGiaSua = Console.ReadLine();
                        Console.Write("Nhap The Loai Moi: ");
                        string theLoaiSua = Console.ReadLine();
                        Console.Write("Nhap Ngay Xuat Ban Moi: ");
                        string ngayXuatBanSua = Console.ReadLine();

                        Sach sachSua = new Sach(tieuDeSua, tacGiaSua, theLoaiSua, ngayXuatBanSua);
                        sachList[indexSua] = sachSua;
                        Console.WriteLine("Sua Sach Thanh Cong");
                    }
                    else
                    {
                        Console.WriteLine("Khong Tim Thay Sach Can Sua");
                    }
                    break;

                default:
                    Console.WriteLine("Khong Truy Cap Duoc Lenh Admin");
                    break;
            }
        }

        public void XuLiYCKhach(char luaChon)
        {
            switch (luaChon)
            {
                case 'a':
                    Console.Write("Nhap Ten Sach Muon Tim Kiem: ");
                    string tenSach = Console.ReadLine();
                    int indexTim = TimTTSach(tenSach);
                    if (indexTim != -1)
                    {
                        Sach sach = sachList[indexTim];
                        Console.WriteLine("Thong Tin Sach:");
                        Console.WriteLine($"Tieu De: {sach.TieuDe}");
                        Console.WriteLine($"Tac Gia: {sach.TacGia}");
                        Console.WriteLine($"The Loai: {sach.TheLoai}");
                        Console.WriteLine($"Ngay Xuat Ban: {sach.NgayXuatBan}");
                    }
                    else
                    {
                        Console.WriteLine("Khong Tim Thay Sach");
                    }
                    break;

                case 'b':
                    Console.WriteLine("***Danh Sach Sach***");
                    foreach (var sach in sachList)
                    {
                        Console.WriteLine($"Tieu De: {sach.TieuDe}");
                        Console.WriteLine($"Tac Gia: {sach.TacGia}");
                        Console.WriteLine($"The Loai: {sach.TheLoai}");
                        Console.WriteLine($"Ngay Xuat Ban: {sach.NgayXuatBan}");
                        Console.WriteLine("-----");
                    }
                    break;

                default:
                    Console.WriteLine("Khong Truy Cap Duoc Lenh Khach");
                    break;
            }
        }

        public void MenuAdmin()
        {
            char luaChon;
            do
            {
                Console.WriteLine("Menu Admin:");
                Console.WriteLine("1. Them Sach");
                Console.WriteLine("2. Xoa Sach");
                Console.WriteLine("3. Sua Sach");
                Console.WriteLine("a. Tim Sach");
                Console.WriteLine("b. Danh Sach Sach");
                Console.WriteLine("0. Thoat");

                Console.Write("Nhap Lua Chon: ");
                luaChon = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (luaChon == '0') break;

                if (luaChon == '1' || luaChon == '2' || luaChon == '3')
                {
                    XuLiYCAdmin(luaChon);
                }
                else if (luaChon == 'a' || luaChon == 'b')
                {
                    XuLiYCKhach(luaChon);
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le.");
                }

            } while (luaChon != '0');
        }


        public void MenuKhach()
        {
            char luaChon;
            do
            {
                Console.WriteLine("Menu Khach:");
                Console.WriteLine("a. Tim Sach");
                Console.WriteLine("b. Danh Sach Sach");
                Console.WriteLine("0. Thoat");

                Console.Write("Nhap Lua Chon: ");
                luaChon = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (luaChon == '0') break;

                XuLiYCKhach(luaChon);

            } while (luaChon != '0');
        }

        public void DangNhapMenu()
        {
            Console.WriteLine("Nhap Ten Dang Nhap: ");
            string tenDangNhap = Console.ReadLine();
            if (IsAdmin(tenDangNhap))
            {
                MenuAdmin();
            }
            else
            {
                MenuKhach();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HieuSach hieuSach = new HieuSach();
            hieuSach.Hello();

            while (true)
            {
                hieuSach.DangNhapMenu();
            }
        }
    }
}
