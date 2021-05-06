using System;

namespace DataStructure.DataStructure
{
    
    public interface Set<T>
    {
        void add(T t);

        void remove(T t);

        bool contains(T t);

        int getSize();

        bool isEmpty();
    }

}