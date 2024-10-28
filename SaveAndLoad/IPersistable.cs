namespace SaveAndLoad;

public interface IPersistable
{
    void Save();
    void Load();
    void Save(string fileName);
    void Load(string fileName);
}