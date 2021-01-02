namespace MiInterfaceHierarchy
{
    public interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}