using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class LightSslSigner
{
    public byte[] Sign(byte[] messageBytes, string certPemFile, string keyPemFile, bool includeCertificate = false)
    {
        var cert = X509Certificate2.CreateFromPemFile(certPemFile, keyPemFile);
        var signer = new CmsSigner(cert);
        var contentInfo = new ContentInfo(messageBytes);
        var cms = new SignedCms(contentInfo);

        cms.ComputeSignature(signer);

        if(includeCertificate is false)
            cms.RemoveCertificate(cert);

        return cms.Encode();
    }
}