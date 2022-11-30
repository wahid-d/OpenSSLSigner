var messageBytes = await File.ReadAllBytesAsync("request.json");
var signer = new LightSslSigner();
var signedMessage = signer.Sign(messageBytes, "EZ000000000256.crt", "energymarket.key");

var client = new HttpClient();
var httpContent = new ByteArrayContent(signedMessage);

var response = await client.PostAsync(" https://test.ofd.uz/emp/receipt", httpContent);

Console.WriteLine(await response.Content.ReadAsStringAsync());