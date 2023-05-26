using static Patterns.Map;

namespace Patterns
{
    internal class MapBuilder
    {
        internal MapComposite Root;
        internal MapComposite CurrentComposite;

        internal MapBuilder(string title, string type="City")
        {  
            Root = new MapComposite(type, title);
            CurrentComposite = Root;
        }

        internal MapLeaf AddLeaf(string type, string title)
        {
            MapLeaf leaf = new MapLeaf(type, title);
            CurrentComposite.Add(leaf);
            return leaf;
        }

        internal void RemoveLeaf(string parentTitle, string title)
        {
            string initialCompositeTitle = CurrentComposite.Title;
            SetCurrentComposite(parentTitle);
            CurrentComposite.Remove(CurrentComposite.FindChild(title));
            SetCurrentComposite(initialCompositeTitle);
        }

        internal MapComposite SetCurrentComposite(string setCompositeTitle)
        {
            Stack<MapComposite> compStack = new Stack<MapComposite>();
            compStack.Push(Root);
            while (compStack.Any())
            { 
                MapComposite currentComposite = compStack.Pop();

                if (setCompositeTitle == currentComposite.Title)
                {
                    CurrentComposite = currentComposite;
                    return currentComposite;
                }
 
                foreach (var item in currentComposite.components.OfType<MapComposite>())
                { 
                    compStack.Push(item);
                }
            }
  
            throw new InvalidOperationException($"Composite with title: '{setCompositeTitle}' not found!");
        }

        internal MapComposite AddComposite(string type, string title)
        {
            MapComposite composite = new MapComposite(type, title);
            CurrentComposite.Add(composite);
            CurrentComposite = composite;
            return composite;
        }

        internal void DisplayTree(int indent) 
        {
            Root.Display(indent);
        }
    }
}
