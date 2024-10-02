using System.Net;

namespace ECommerceWebsite.Helpers
{
    public static class ImageConverter
    {
        public static async Task<string> ImageTobase64(string imageLink)
        {
            HttpClient client = new HttpClient();
            
            byte[] imageBytes = await  client.GetByteArrayAsync(imageLink);
            string base64 = Convert.ToBase64String(imageBytes);

            return base64;
        }
    }
}
