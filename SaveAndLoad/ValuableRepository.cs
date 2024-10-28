using System.Reflection;

namespace SaveAndLoad;

public class ValuableRepository(List<IValuable> repository) : IPersistable
{
    private string defaultFileName = @"C:\Users\Michagin\Desktop\ValuableRepository.txt";
    public List<IValuable> Repo { get => repository; set => repository = value; }
    private IValuable GetValuable(string id)
    {
        var first = repository.FirstOrDefault(x => x.Id == id);

        return (first ?? null)!;
    }

    public double GetTotalValue()
    {
        try
        {
            return repository.Sum(entry => double.Parse(entry.GetValue()));
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public void Save()
    {
        Save(defaultFileName);
    }

    public void Load()
    {
        Load(defaultFileName);
    }

    public void Save(string fileName)
    {
        var data = "";
        foreach (var valuable in repository)
        {
            data = typeof(Valuable).GetProperties().Aggregate(data, (current, property) => $"{current}{property.GetValue(valuable) + ";"}");
        }
        
        File.WriteAllText(fileName, data);
    }

    /* This approach sucks! It assumes way too much */
    public void Load(string fileName)
    {
        repository ??= new List<IValuable>();
        
        var data = File.ReadAllText(fileName).Split(";");
        for (var i = 0; i < data.Length; i++)   
        {
            if (i % 4 == 0 && i != data.Length -1)
            {
                repository.Add(new Valuable()
                {
                    Id = data[i + 1],
                    Category = data[i + 2],
                    Price = data[i + 3],
                    Text = data[i + 4]
                });
            }

            i++;
        }
    }
}