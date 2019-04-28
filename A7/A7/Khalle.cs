namespace A7
{
    public class Khalle : ICitizen ,ITeacher
    {
        private string _Name;
        private string _NationalId;
        private Degree _TopDegree;
        private string _ImgUrl;
        public string Name { get => _Name;set =>_Name=value; }

        public string NationalId { get => _NationalId; set => _NationalId=value; }

        public Degree TopDegree { get =>_TopDegree; set => _TopDegree=value; }

        public string ImgUrl { get =>_ImgUrl;set => _ImgUrl=value; }

        public string Teach()=>$"{nameof(Khalle)} {this.Name} is teaching";
        public Khalle( string nationalid, string name, string imgurl,Degree topdegree)
        {
            this.Name = name;
            this.NationalId = nationalid;
            this.TopDegree = topdegree;
            this.ImgUrl = imgurl;
        }
        
    }
}