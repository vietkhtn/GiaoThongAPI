namespace HumanResource.ApplicationCore.Entities
{
    public class Law : BaseEntity
    {
        public int Chuong { get; set; }

        public string NoiDungChuong { get; set; }

        public int Muc { get; set; }

        public string NoiDungMuc { get; set; }

        public int DieuLuat { get; set; }

        public string NoiDungDieuLuat { get; set; }

        public int Khoan { get; set; }

        public string NoiDungKhoan { get; set; }

        public string Diem { get; set; }
    }
}