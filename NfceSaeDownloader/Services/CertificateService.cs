using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NfceSaeDownloader.Services
{
    public static class CertificateService
    {
        public static List<X509Certificate2> GetAvailableCertificates(StoreLocation location, StoreName storeName)
        {
            var list = new List<X509Certificate2>();

            using (var store = new X509Store(storeName, location))
            {
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                list.AddRange(store.Certificates
                    .Cast<X509Certificate2>()
                    .Where(c => c.HasPrivateKey)
                    .OrderBy(c => c.Subject));
            }

            return list;
        }

        public static X509Certificate2 FindByThumbprint(StoreLocation location, StoreName storeName, string thumbprint)
        {
            if (string.IsNullOrWhiteSpace(thumbprint))
            {
                return null;
            }

            var normalized = thumbprint.Replace(" ", string.Empty).ToUpperInvariant();
            using (var store = new X509Store(storeName, location))
            {
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                foreach (var cert in store.Certificates)
                {
                    if (string.Equals(cert.Thumbprint, normalized, StringComparison.OrdinalIgnoreCase))
                    {
                        return cert;
                    }
                }
            }

            return null;
        }

        public static string ExtractCnpj(X509Certificate2 certificate)
        {
            if (certificate == null || string.IsNullOrWhiteSpace(certificate.Subject))
            {
                return string.Empty;
            }

            var subject = certificate.Subject.Replace(" ", string.Empty);
            var token = "2.16.76.1.3.3=";
            var index = subject.IndexOf(token, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                var start = index + token.Length;
                var end = subject.IndexOf(',', start);
                if (end < 0)
                {
                    end = subject.Length;
                }

                var value = subject.Substring(start, end - start);
                return OnlyDigits(value);
            }

            token = "CNPJ=";
            index = subject.IndexOf(token, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                var start = index + token.Length;
                var end = subject.IndexOf(',', start);
                if (end < 0)
                {
                    end = subject.Length;
                }

                return OnlyDigits(subject.Substring(start, end - start));
            }

            return string.Empty;
        }

        private static string OnlyDigits(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            return new string(value.Where(char.IsDigit).ToArray());
        }
    }
}
