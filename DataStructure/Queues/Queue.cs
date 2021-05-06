namespace DataStructure.Queues
{
    public interface Queue<T>
    {
        int getSize();

        bool isEmpty();

        T getFront();

        void enqueue(T e);

        T dequeue();
    }
}