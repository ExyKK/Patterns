namespace Patterns
{
    internal class Map
    {
        public abstract class MapComponent
        {
            public string Type;
            public string Title;

            public MapComponent(string type, string title)
            {
                Type = type;
                Title = title;
            }

            public abstract void Add(MapComponent component);
            public abstract void Remove(MapComponent component);
            public abstract void Display(int indent);

            public virtual MapComponent FindChild(string title)
            {
                return (Title == title) ? this : null;
            }
        }

        public class MapLeaf : MapComponent
        {
            public MapLeaf(string type, string title) : base(type, title) { }

            public override void Add(MapComponent component)
            {
                Console.WriteLine("Cannot add to a MapLeaf");
            }
            public override void Remove(MapComponent component)
            {
                Console.WriteLine("Cannot remove from a MapLeaf");
            }

            public override void Display(int indent)
            {
                Console.WriteLine($"{new String('-', indent)} {Type} '{Title}'");
            }
        }

        public class MapComposite : MapComponent
        {
            public List<MapComponent> components = new List<MapComponent>();

            public MapComposite(string type, string title) : base(type, title) { }

            public override void Add(MapComponent newItem)
            {
                components.Add(newItem);
            }
            public override void Remove(MapComponent deleteItem)
            {
                components.Remove(deleteItem);
            }

            public override void Display(int indent)
            {
                Console.WriteLine($"{new String('-', indent)}+ {Type} '{Title}'");

                foreach (MapComponent item in components)
                {
                    item.Display(indent + 2);
                }
            }

            public override MapComponent FindChild(string title)
            {
                if (Title == title)
                {
                    return this;
                }

                foreach (MapComponent component in this.components)
                {
                    MapComponent found = component.FindChild(title);

                    if (found != null)
                    {
                        return found;
                    }
                }

                return null;
            }
        }
    }
}
