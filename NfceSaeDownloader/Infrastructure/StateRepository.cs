using System;
using System.IO;
using System.Xml.Linq;
using NfceSaeDownloader.Models;

namespace NfceSaeDownloader.Infrastructure
{
    public sealed class StateRepository
    {
        private readonly string _filePath;

        public StateRepository(string directory)
        {
            _filePath = Path.Combine(directory, "sae-state.xml");
        }

        public DateTime? LoadCursor(SaeAmbiente ambiente, string cnpj)
        {
            if (!File.Exists(_filePath))
            {
                return null;
            }

            var doc = XDocument.Load(_filePath);
            var node = doc.Root.Element("cursor");
            if (node == null)
            {
                return null;
            }

            var attrAmb = (string)node.Attribute("ambiente");
            var attrCnpj = (string)node.Attribute("cnpj");
            var value = (string)node.Attribute("dhUltimaEmissao");
            DateTime parsed;

            if (string.Equals(attrAmb, ((int)ambiente).ToString(), StringComparison.OrdinalIgnoreCase)
                && string.Equals(attrCnpj, cnpj ?? string.Empty, StringComparison.OrdinalIgnoreCase)
                && DateTime.TryParse(value, out parsed))
            {
                return parsed;
            }

            return null;
        }

        public void SaveCursor(SaeAmbiente ambiente, string cnpj, DateTime dhUltimaEmissao)
        {
            var dir = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var doc = new XDocument(
                new XElement("state",
                    new XElement("cursor",
                        new XAttribute("ambiente", (int)ambiente),
                        new XAttribute("cnpj", cnpj ?? string.Empty),
                        new XAttribute("dhUltimaEmissao", dhUltimaEmissao.ToString("s")))));

            doc.Save(_filePath);
        }
    }
}
