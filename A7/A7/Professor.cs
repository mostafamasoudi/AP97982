namespace A7
{
    public class Professor : ICitizen, ITeacher
    {
        private string _Name;
        private string _NationalId;
        private Degree _TopDegree;
        private string _ImgUrl;

        public string Name { get => _Name; set => _Name = value; }
        public string NationalId { get => _NationalId; set => _NationalId = value; }
        public Degree TopDegree { get => _TopDegree; set => _TopDegree = value; }
        public string ImgUrl { get => _ImgUrl; set => _ImgUrl = value; }
        public double ResearchCount { get; set; }

        public string Teach() =>
            $"{nameof(Professor)} {this.Name} is teaching";

        public Professor(string nationalid, string name, string imgurl, Degree topdegree,double researchcount)
        {
            this.Name = name;
            this.NationalId = nationalid;
            this.TopDegree = topdegree;
            this.ImgUrl = imgurl;
            this.ResearchCount = researchcount;
        }
    }
}