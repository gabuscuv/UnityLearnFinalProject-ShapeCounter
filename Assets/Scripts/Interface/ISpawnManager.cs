using System.Collections.Generic;
public interface ISpawnManager
{
    public List<string> GetObjectToSpawnNames();
    public void SetGameActivity(bool status);
}