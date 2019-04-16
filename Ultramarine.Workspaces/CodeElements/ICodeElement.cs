namespace Ultramarine.Workspaces.CodeElements
{
    public interface ICodeElementModel
    {
        string Name { get; set; }
        ElementType? Type { get; set; }
        ElementAccess? Access { get; set; }
        ElementOverride Override { get; set; }
    }
}
