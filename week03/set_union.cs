public HashSet<T> FindUnion<T>(HashSet<T> setA, HashSet<T> setB)
{
    var union = new HashSet<T>(setA); // Start with all elements from setA

    foreach (var item in setB)
    {
        union.Add(item); // HashSet automatically handles duplicates
    }

    return union;
}