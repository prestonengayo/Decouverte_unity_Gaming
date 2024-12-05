public interface ICheckPoint
{
    void Save();
    void ResetCheckPoint();
    void Load();
}
