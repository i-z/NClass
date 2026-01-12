
using System.Xml;
using NClass.Translations;

namespace NClass.Core
{
    public sealed class RedBox : Element, INestableChild
    {
        public INestable NestingParent { get; set; }
        public string Name { get => Strings.RedBox; set {} }

        public EntityType EntityType => EntityType.RedBox;

        public event SerializeEventHandler Serializing;
        public event SerializeEventHandler Deserializing;

        public INestableChild CloneChild()
        {
            return Clone();
        }

        public void Deserialize(XmlElement node)
        {
            if (node == null)
                throw new System.ArgumentNullException(nameof(node));

            var child = node["RedBox"];
            if (child == null)
                return;

            var args = new SerializeEventArgs(child);
            OnDeserializing(args);
        }

        public void Serialize(XmlElement node)
        {
            if (node == null)
                throw new System.ArgumentNullException(nameof(node));

            var child = node.OwnerDocument.CreateElement("RedBox");
            node.AppendChild(child);

            var args = new SerializeEventArgs(child);
            OnSerializing(args);
        }

        private RedBox Clone()
        {
            return new RedBox();
        }

        private void OnSerializing(SerializeEventArgs e)
        {
            Serializing?.Invoke(this, e);
        }

        private void OnDeserializing(SerializeEventArgs e)
        {
            Deserializing?.Invoke(this, e);
        }

        
    }
}