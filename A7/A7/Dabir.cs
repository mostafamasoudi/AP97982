namespace A7
{
    public class Dabir : ICitizen ,ITeacher
    {
        private string _Name;
        private string _NationalId;
        private Degree _TopDegree;
        private string _ImgUrl;
        private double _Under100StudentCount;

        public string Name { get => _Name;set =>_Name=value; }
        public string NationalId { get => _NationalId; set => _NationalId = value; }
        public Degree TopDegree { get => _TopDegree; set => _TopDegree = value; }
        public string ImgUrl { get =>_ImgUrl;set => _ImgUrl=value; }
        public double Under100StudentCount { get => _Under100StudentCount; set => _Under100StudentCount=value; }


        public string Teach() =>
            $"{nameof(Dabir)} {this.Name} is teaching";
        public Dabir(string nationalid, string name, string imgurl, Degree topdegree,double under100studentcount)
        {
            this.Name = name;
            this.NationalId = nationalid;
            this.TopDegree = topdegree;
            this.ImgUrl = imgurl;
            this.Under100StudentCount = _Under100StudentCount;
        }
    }
}