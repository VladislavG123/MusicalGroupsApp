namespace MusicalGroupApp
{
    public class Song : Entity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Mark { get; set; }
        public int Lenght { get; set; }

        public MusicalGroup MusicalGroup { get; set; }
    }
}