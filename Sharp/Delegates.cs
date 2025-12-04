namespace Sharp
{
    public delegate bool TryHandler<TOutput>(out TOutput? output);
    public delegate bool TryHandler<TInput, TOutput>(TInput source, out TOutput? output);
}
