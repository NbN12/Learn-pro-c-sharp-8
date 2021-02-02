namespace CustomInterfaces
{
    // This interface defines the behavior of "having points."
    public interface IPointy
    {
        // Implicitly public and abstract.
        // byte GetNumberOfPoints();

        // A read-write property in an interface would look like:
        // string PropName { get; set; }

        // while a write-only property in an interface would be:
        byte Points { get; }
    }
}