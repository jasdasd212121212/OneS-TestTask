using System;

public interface IObservableState 
{
    event Action entered;
    event Action exited;
}