public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public Feature[] Features { get; set; } = [];
}

public class Feature
{
    public Properties Properties { get; set; } = new Properties();
}

public class Properties
{
    public string Place { get; set; } = "";
    public double Mag { get; set; }
}