namespace ShopingWebsite.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheweek { get; }
        Pie? GetPieById(int id);
        IEnumerable<Pie> SearchPies(string searchQuery); 
    }
}
