namespace PoolTrackerBackEnd.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Points { get; set; }

        public bool IsNew => this.Id == default (int);

    }
}
