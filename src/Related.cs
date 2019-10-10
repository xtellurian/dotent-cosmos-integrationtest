namespace src
{
    public class Related
    {
        public string Id { get; set; }
        public string ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}