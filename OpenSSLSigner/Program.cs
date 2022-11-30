var messageBytes = await File.ReadAllBytesAsync("request.json");
var signer = new LightSslSigner();
var signedMessage = signer.Sign(messageBytes, "ADD_YOUR_CERTIFICATE.crt", "ADD_YOUR_KEY.key");

var client = new HttpClient();
var httpContent = new ByteArrayContent(signedMessage);

var response = await client.PostAsync("https://test.ofd.uz/emp/receipt", httpContent);

Console.WriteLine(await response.Content.ReadAsStringAsync());
