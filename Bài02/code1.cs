using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSpeed
{
    // =========================================================
    // A. ABSTRACT CLASS PHUONG TIEN
    // =========================================================
    public abstract class PhuongTien
    {
        // Private Fields - Encapsulation
        private string _maPT;
        private string _tenHang;
        private int _namSanXuat;
        private decimal _giaGoc;

        // Property MaPT
        public string MaPT
        {
            get => _maPT;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _maPT = "PT000";
                else
                    _maPT = value.Trim();
            }
        }

        // Property TenHang
        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên hãng không được để trống!");

                _tenHang = value.Trim();
            }
        }

        // Property NamSanXuat
        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                int namHienTai = DateTime.Now.Year;

                if (value < 1900 || value > namHienTai)
                    throw new ArgumentException("Năm sản xuất không hợp lệ!");

                _namSanXuat = value;
            }
        }

        // Property GiaGoc
        public decimal GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Giá gốc phải lớn hơn 0!");

                _giaGoc = value;
            }
        }

        // Constructor
        protected PhuongTien(
            string maPT,
            string tenHang,
            int namSanXuat,
            decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }

        // Abstract Method - Polymorphism
        public abstract decimal TinhGiaLanBanh();

        // Virtual Method
        public virtual string GetInfo()
        {
            return $"Mã PT: {MaPT}, " +
                   $"Hãng: {TenHang}, " +
                   $"Năm SX: {NamSanXuat}, " +
                   $"Giá gốc: {GiaGoc:N0} VNĐ";
        }
    }


    // =========================================================
    // B. CLASS OTO
    // =========================================================
    public class OTo : PhuongTien
    {
        private int _soChoNgoi;
        private double _dungTichDongCo;

        public int SoChoNgoi
        {
            get => _soChoNgoi;
            set
            {
                if (value <= 0)
                    throw new ArgumentException(
                        "Số chỗ ngồi phải lớn hơn 0!");

                _soChoNgoi = value;
            }
        }

        public double DungTichDongCo
        {
            get => _dungTichDongCo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException(
                        "Dung tích động cơ phải lớn hơn 0!");

                _dungTichDongCo = value;
            }
        }

        public OTo(
            string maPT,
            string tenHang,
            int namSanXuat,
            decimal giaGoc,
            int soChoNgoi,
            double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        // Override Abstract Method
        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
            {
                // Giá gốc + 12% lệ phí trước bạ + 30% thuế TTĐB
                return GiaGoc
                       + GiaGoc * 0.12m
                       + GiaGoc * 0.30m;
            }

            // Xe trên 9 chỗ:
            // Giá gốc + 10% lệ phí trước bạ
            return GiaGoc + GiaGoc * 0.10m;
        }

        // Override Virtual Method
        public override string GetInfo()
        {
            return base.GetInfo()
                   + $", Số chỗ: {SoChoNgoi}"
                   + $", Dung tích động cơ: {DungTichDongCo} cc";
        }
    }


    // =========================================================
    // C. CLASS XE MAY
    // =========================================================
    public class XeMay : PhuongTien
    {
        private int _dungTichXylanh;

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException(
                        "Dung tích xy-lanh phải lớn hơn 0!");

                _dungTichXylanh = value;
            }
        }

        public XeMay(
            string maPT,
            string tenHang,
            int namSanXuat,
            decimal giaGoc,
            int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        // Override Abstract Method
        public override decimal TinhGiaLanBanh()
        {
            if (DungTichXylanh < 175)
            {
                // Giá gốc + 2% thuế trước bạ
                return GiaGoc + GiaGoc * 0.02m;
            }

            // Giá gốc + 5% thuế trước bạ
            return GiaGoc + GiaGoc * 0.05m;
        }

        public override string GetInfo()
        {
            return base.GetInfo()
                   + $", Dung tích xy-lanh: {DungTichXylanh} cc";
        }
    }


    // =========================================================
    // D. CLASS QUAN LY PHUONG TIEN
    // =========================================================
    public class QuanLyPhuongTien
    {
        // List chứa các object thuộc lớp cha
        private readonly List<PhuongTien> _dsPhuongTien;

        public QuanLyPhuongTien()
        {
            _dsPhuongTien = new List<PhuongTien>();
        }

        // 1. AddPhuongTien
        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt == null)
                throw new ArgumentNullException(nameof(pt));

            _dsPhuongTien.Add(pt);
        }

        // 2. DisplayAll
        public void DisplayAll()
        {
            if (_dsPhuongTien.Count == 0)
            {
                Console.WriteLine("Danh sách phương tiện đang trống!");
                return;
            }

            Console.WriteLine(
                "========== DANH SÁCH PHƯƠNG TIỆN ==========");

            foreach (PhuongTien pt in _dsPhuongTien)
            {
                Console.WriteLine(pt.GetInfo());
                Console.WriteLine(
                    $"Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
                Console.WriteLine("--------------------------------------------");
            }
        }

        // 3. FindMaxGiaLanBanh
        public PhuongTien? FindMaxGiaLanBanh()
        {
            if (_dsPhuongTien.Count == 0)
                return null;

            return _dsPhuongTien
                .OrderByDescending(pt => pt.TinhGiaLanBanh())
                .First();
        }

        // 4. SearchByName
        public List<PhuongTien> SearchByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<PhuongTien>();

            return _dsPhuongTien
                .Where(pt =>
                    pt.TenHang.Contains(
                        keyword.Trim(),
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }


    // =========================================================
    // PROGRAM - TEST CASE
    // =========================================================
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var ql = new QuanLyPhuongTien();

            // =================================================
            // TC01 - Validation Năm sản xuất
            // =================================================
            Console.WriteLine("===== TC01: VALIDATION NĂM SẢN XUẤT =====");

            try
            {
                var otoLoi = new OTo(
                    "OT999",
                    "Toyota",
                    1850,              // Sai
                    1_000_000_000m,
                    5,
                    2000);

                Console.WriteLine("TC01 FAILED");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"TC01 PASSED: {ex.Message}");
            }


            // =================================================
            // TC02 - Tính giá lăn bánh Ô tô
            // =================================================
            Console.WriteLine();
            Console.WriteLine("===== TC02: GIÁ LĂN BÁNH Ô TÔ =====");

            var oto = new OTo(
                "OT001",
                "Toyota",
                2024,
                1_000_000_000m,
                5,
                2000);

            decimal giaOto = oto.TinhGiaLanBanh();

            Console.WriteLine($"Giá gốc: {oto.GiaGoc:N0} VNĐ");
            Console.WriteLine($"Giá lăn bánh: {giaOto:N0} VNĐ");

            if (giaOto == 1_420_000_000m)
                Console.WriteLine("TC02 PASSED");
            else
                Console.WriteLine("TC02 FAILED");


            // =================================================
            // TC03 - Tính giá lăn bánh Xe máy
            // =================================================
            Console.WriteLine();
            Console.WriteLine("===== TC03: GIÁ LĂN BÁNH XE MÁY =====");

            var xeMay = new XeMay(
                "XM001",
                "Honda",
                2024,
                50_000_000m,
                150);

            decimal giaXeMay = xeMay.TinhGiaLanBanh();

            Console.WriteLine($"Giá gốc: {xeMay.GiaGoc:N0} VNĐ");
            Console.WriteLine(
                $"Giá lăn bánh: {giaXeMay:N0} VNĐ");

            if (giaXeMay == 51_000_000m)
                Console.WriteLine("TC03 PASSED");
            else
                Console.WriteLine("TC03 FAILED");


            // =================================================
            // TC04 - Polymorphism
            // =================================================
            Console.WriteLine();
            Console.WriteLine("===== TC04: ĐA HÌNH =====");

            // Quan trọng:
            // List kiểu PhuongTien nhưng chứa OTo + XeMay
            ql.AddPhuongTien(oto);
            ql.AddPhuongTien(xeMay);

            ql.DisplayAll();

            Console.WriteLine("TC04 PASSED");


            // =================================================
            // TC05 - Tìm giá lăn bánh lớn nhất
            // =================================================
            Console.WriteLine();
            Console.WriteLine("===== TC05: TÌM GIÁ LĂN BÁNH MAX =====");

            PhuongTien? max = ql.FindMaxGiaLanBanh();

            if (max != null)
            {
                Console.WriteLine("Phương tiện có giá lăn bánh cao nhất:");
                Console.WriteLine(max.GetInfo());
                Console.WriteLine(
                    $"Giá lăn bánh: {max.TinhGiaLanBanh():N0} VNĐ");

                if (max == oto)
                    Console.WriteLine("TC05 PASSED");
                else
                    Console.WriteLine("TC05 FAILED");
            }

            // =================================================
            // Test thêm SearchByName
            // =================================================
            Console.WriteLine();
            Console.WriteLine("===== TEST SEARCH BY NAME =====");

            List<PhuongTien> ketQua =
                ql.SearchByName("toyota");

            foreach (PhuongTien pt in ketQua)
            {
                Console.WriteLine(pt.GetInfo());
            }

            Console.WriteLine();
            Console.WriteLine("Nhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}

