namespace ObjectPoolings
{
    public interface IPoolObject
    {
        void DequeueSettings();
        void EnqueueSettings();
    }
}
