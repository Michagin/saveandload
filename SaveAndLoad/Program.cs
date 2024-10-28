using System;

namespace SaveAndLoad
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IValuable valuable1 = new Valuable
            {
                Category = "BOG",
                Price = "123.55",
                Id = "ID1",
                Text = "Spirits of the Night",
            };
            
            IValuable valuable2 = new Valuable
            {
                Category = "BOG",
                Price = "321.44",
                Id = "ID2",
                Text = "Spirits of the Night II",
            };
            
            IValuable valuable3 = new Valuable
            {
                Category = "BOG",
                Price = "55.22",
                Id = "ID3",
                Text = "Spirits of the Night III",
            };
            
            var valuables = new List<IValuable>()
            {
                valuable1,
                valuable2,
                valuable3
            };

            ValuableRepository repo = new ValuableRepository(null!);
            
            //repo.Save();
            repo.Load(@"C:\Users\Michagin\Desktop\ValuableRepository.txt");
            foreach (var entry in repo.Repo)
            {
                Console.WriteLine(entry.Id);
            }
        }
    }
}