namespace WPFRepetition.Factories;

public interface IViewModelFactory<T>
{
    T Create();
}